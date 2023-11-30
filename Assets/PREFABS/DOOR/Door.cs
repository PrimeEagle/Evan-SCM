using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    public GameObject door;
    public DateTime keypadUsedTime;
    public float keypadDelay = 2.0f;
    public AudioClip doorOpenSound;
    public AudioClip pressButtonSound;
    public AudioSource doorSource;
    public AudioSource buttonSource;
    public void Start()
    {
        doorSource.clip = doorOpenSound;
        buttonSource.clip = pressButtonSound;
    }
    public void OnMouseDown()
    {

        TimeSpan timeSinceUsed = DateTime.Now - keypadUsedTime;

        if (timeSinceUsed.TotalSeconds >= keypadDelay)
        {
            if (door.activeInHierarchy == true)
            {
                door.SetActive(false);
                keypadUsedTime = DateTime.Now;
                doorSource.Play();
                buttonSource.Play();
            }
            else
            {
                door.SetActive(true);
                keypadUsedTime = DateTime.Now;
                doorSource.Play();
                buttonSource.Play();
            }
        }
    }
}
