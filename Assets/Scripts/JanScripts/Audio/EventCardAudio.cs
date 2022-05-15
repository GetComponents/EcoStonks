using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventCardAudio : MonoBehaviour
{
    //[SerializeField]
    //AudioSource 
    public static EventCardAudio Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    public void PlayPaperSFX()
    {

    }
}
