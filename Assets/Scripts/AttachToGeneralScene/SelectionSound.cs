using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionSound : MonoBehaviour
{
    AudioSource audioData;

    void Start()
    {
        audioData = GetComponent<AudioSource>();
    }

    public void Play()
    {
        audioData.Play(0);
    }
}
