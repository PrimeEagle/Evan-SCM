using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rover : MonoBehaviour {
    public AudioClip roverHello;
    public AudioSource helloSource;
    public bool roverCanSpeak = true;
	// Use this for initialization
	void Start ()
    {
        helloSource.clip = roverHello;
	}
    public void OnMouseDown()
    {
        if (roverCanSpeak)
        {
            helloSource.Play();
            roverCanSpeak = false;
            StartCoroutine(RoverWait());
        }
    }
    IEnumerator RoverWait()
    {
        yield return new WaitForSeconds(3f);
        roverCanSpeak = true;
    }
}
