using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructionAudio : MonoBehaviour
{
    public static ConstructionAudio Instance;
    [SerializeField]
    List<AudioSource> powerplantAudio;
    [SerializeField]
    List<AudioSource> woodAudio;

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

    public void PlayPowerPlantConstruction()
    {
        powerplantAudio[Random.Range(0, powerplantAudio.Count)].Play();
    }

    public void PlayWoodConstruction()
    {
        woodAudio[Random.Range(0, woodAudio.Count)].Play();
    }
}
