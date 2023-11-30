using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour {

    public GameObject waterEffect;
    public AudioClip waterSound;
    public AudioSource waterSource;
     void Start()
    {
        waterSource.clip = waterSound;
    }
    void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            Pickup(other);

        }
        else
        {
            //waterSource.mute;
        }
    }
    void Pickup(Collider player)
    {
        Instantiate(waterEffect, transform.position, transform.rotation);
        PlayeController stats = player.GetComponent<PlayeController>();
        waterSource.Play();

        UnityStandardAssets.Characters.FirstPerson.FirstPersonController speed = player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();
        speed.m_WalkSpeed = 5f;
        speed.m_RunSpeed = 10f;
    }
}

