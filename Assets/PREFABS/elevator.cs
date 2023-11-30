using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elevator : MonoBehaviour
{
    private bool pressedButton = false;
    private bool isElevatorUp = false;
    private Animation anim;
    public GameObject theElevator;

    // Start is called before the first frame update
    void Start()
    {
        anim = theElevator.gameObject.GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnMouseDown()
    {
        if(isElevatorUp == false)
        {
            StartCoroutine(Example());
            anim.Play("ElevatorUp");
            isElevatorUp = true;
        }
        else
        {
            StartCoroutine(Example());
            anim.Play("ElevatorDown");
            isElevatorUp = false;
        }
    }
    IEnumerator Example()
    {
        yield return new WaitForSeconds(5);
    }
}
