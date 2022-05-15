using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventCardAudio : MonoBehaviour
{
    [SerializeField]
    AudioSource jingle;

    [SerializeField]
    List<AudioSource> paper;
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
        paper[Random.Range(0, paper.Count)].Play();
    }

    public void PlayJingleSFX()
    {
        jingle.Play();
    }
}
