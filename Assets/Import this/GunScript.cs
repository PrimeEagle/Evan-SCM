using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public GameObject gun;
    public Transform player;

    void OnMouseDown()
    {
        gameObject.SetActive(false);
        GameObject newgun = Instantiate(gun, transform.position, Quaternion.identity);
        newgun.transform.parent = player.transform;
    }
}
