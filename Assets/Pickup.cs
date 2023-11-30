using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public int keyLevel = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
       // if (Input.GetKeyDown(KeyCode.H))
        {
            if (other.gameObject.CompareTag("Key Level 2"))
            {
                other.gameObject.SetActive(false);
                keyLevel = 2;
                print(keyLevel);
            }
            if (other.gameObject.CompareTag("Key Level 3"))
            {
                other.gameObject.SetActive(false);
                keyLevel = 3;
                print(keyLevel);
            }
            if (other.gameObject.CompareTag("Key Level 4"))
            {
                other.gameObject.SetActive(false);
                keyLevel = 4;
                print(keyLevel);
            }
            if (other.gameObject.CompareTag("Key Level 5"))
            {
                other.gameObject.SetActive(false);
                keyLevel = 5;
                print(keyLevel);
            }
        }
    }
}
