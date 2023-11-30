using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Detonation : MonoBehaviour {
    public AudioClip alarm;
    public AudioSource alarmSource;
    public AudioClip evactuate;
    public AudioSource evacuateSource;
    public bool phase1 = false;
    public int detonationTime = 120;
    public Text detonationText;


    // Use this for initialization
    void Start ()
    {
        alarmSource.clip = alarm;
        evacuateSource.clip = evactuate;
    }
    void Update()
    {
        //detonationText.text = "Time to Detonation: " + detonationTime + " seconds.";
    }

    public void OnMouseDown()
    {
        if(phase1 ==false)
        {
            evacuateSource.Play();
            //alarmSource.Play();
            phase1 = true;
            StartCoroutine(Countdown()); 
        }
        else
        {
            detonationText.text = "The Detonation process has already begun.";
        }
            
    }
    IEnumerator Countdown()
    {
        yield return new WaitForSeconds(detonationTime);
    }
}
