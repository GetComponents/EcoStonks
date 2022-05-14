using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	public float normalSpeed = 0.36f;
	public float fastSpeed = 1.06f;
	public float movementSpeed;
	public float movementTime = 5f;
	public float rotationAmount = 0.35f;
	
	public Vector3 newPos;
	public Quaternion newRot;
	
	public Transform cameraTransform;
	public Vector3 zoomAmount;
	public Vector3 newZoom;
	public float minZoom = 10f;
	public float maxZoom = 10000f;
	
	public Vector3 dragStartPos;
	public Vector3 dragCurrentPos;
	
    void Start()
    {
		
		newPos = transform.position;
		newRot = transform.rotation;
		newZoom = cameraTransform.localPosition;
		
    }

    
    void Update()
    {
		HandleMouseInput();
		HandleMovementInput();
    }
	
	void HandleMouseInput() 
	{
		// Mouse Scroll
		if(Input.mouseScrollDelta.y != 0) {
			if(minZoom <= (newZoom + Input.mouseScrollDelta.y*zoomAmount*34).z * (-1) && maxZoom >= (newZoom + Input.mouseScrollDelta.y*zoomAmount*34).z * (-1) ) {
				newZoom += Input.mouseScrollDelta.y * zoomAmount * 34;
			}
		}
		// Mouse Movement
		if(Input.GetMouseButtonDown(2)) {
			Plane plane = new Plane(Vector3.up, Vector3.zero);
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			float entry;
			if(plane.Raycast(ray, out entry)) dragStartPos = ray.GetPoint(entry);
		}
		if(Input.GetMouseButton(2)) {
			Plane plane = new Plane(Vector3.up, Vector3.zero);
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			float entry;
			if(plane.Raycast(ray, out entry)) {
				dragCurrentPos = ray.GetPoint(entry);
				newPos = transform.position + dragStartPos - dragCurrentPos;
			}
		}
	}
	
	void HandleMovementInput()
	{
		// Normal/Fast Mode
		if(Input.GetKey(KeyCode.LeftShift)) movementSpeed = fastSpeed;
		else movementSpeed = normalSpeed;
		// Movement
		if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) {
			newPos += (transform.forward * movementSpeed);
		}
		if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) {
			newPos += (transform.forward * -movementSpeed);
		}
		if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
			newPos += (transform.right * movementSpeed);
		}
		if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
			newPos += (transform.right * -movementSpeed);
		}
		// Rotation
		if(Input.GetKey(KeyCode.Q)) {
			newRot *= Quaternion.Euler(Vector3.up * rotationAmount);
		}
		if(Input.GetKey(KeyCode.E)) {
			newRot *= Quaternion.Euler(Vector3.up * -rotationAmount);
		}
		// Zoom
		if(Input.GetKey(KeyCode.R)) {
			newZoom += zoomAmount;
		}
		if(Input.GetKey(KeyCode.F)) {
			newZoom -= zoomAmount;
		}
		
		
		transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime * movementTime);
		transform.rotation = Quaternion.Lerp(transform.rotation, newRot, Time.deltaTime * movementTime);
		cameraTransform.localPosition = Vector3.Lerp(cameraTransform.localPosition, newZoom, Time.deltaTime * movementTime);
		
	}
	
}