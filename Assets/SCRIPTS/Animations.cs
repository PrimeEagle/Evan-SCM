using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Animations : MonoBehaviour {
    
    public bool isRunning =false;
    public bool isWalking =false;
    public bool onMelee = false;
    public bool onRoll = false;
    public bool onKick = false;
    public bool onJump = false;
    public bool onCrouch = false;
    public bool ableToSprint = true;
    public Camera mainCamera;

    private Animator anim;
    private FirstPersonController fpController;

    // Use this for initialization
    void Start ()
    {
        anim = GetComponent<Animator>();
        fpController = GetComponent<FirstPersonController>();    
	}
	
	// Update is called once per frame
	void Update ()
    {
        float verticalMove = Input.GetAxis("Vertical");
        anim.SetFloat("Speed", verticalMove);
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
        {
            anim.SetBool("isWalking", isWalking= true);
            anim.SetBool("isRunning", isRunning = false);
            anim.SetBool("onJump", onJump = false);
        }
        if ((Input.GetKeyDown(KeyCode.W) && Input.GetKeyDown(KeyCode.LeftShift) & ableToSprint == true) || (Input.GetKeyDown(KeyCode.A) && Input.GetKeyDown(KeyCode.LeftShift) & ableToSprint == true) || (Input.GetKeyDown(KeyCode.S) && Input.GetKeyDown(KeyCode.LeftShift) & ableToSprint == true) || (Input.GetKeyDown(KeyCode.D) && Input.GetKeyDown(KeyCode.LeftShift) & ableToSprint == true))
        {
            anim.SetBool("isWalking", isWalking = false);
            anim.SetBool("isRunning", isRunning = true);
            anim.SetBool("onJump", onJump = false);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            anim.SetBool("isWalking", isWalking = false);
            anim.SetBool("isRunning", isRunning = false);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            anim.SetBool("isWalking", isWalking = false);
            anim.SetBool("isRunning", isRunning = false);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            anim.SetBool("isWalking", isWalking = false);
            anim.SetBool("isRunning", isRunning = false);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            anim.SetBool("isWalking", isWalking = false);
            anim.SetBool("isRunning", isRunning = false);
        }
        if (Input.GetKey(KeyCode.Mouse0))
        {
            anim.SetBool("onMelee", onMelee = true);
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            anim.SetBool("onMelee", onMelee = false);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("onJump", onJump = true);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            anim.SetBool("onJump", onJump = false);
        }
        if (Input.GetKey(KeyCode.Mouse1))
        {
            anim.SetBool("onKick", onKick = true);
        }
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            anim.SetBool("onKick", onKick = false);
        }
        if (Input.GetKey(KeyCode.E))
        {
            anim.SetBool("onRoll", onRoll = true);
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            anim.SetBool("onRoll", onRoll = false);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            ableToSprint = false;
            anim.SetBool("onCrouch", onCrouch = true);
            anim.SetFloat("Speed", .2f);
            Vector3 newPosition = new Vector3(mainCamera.transform.position.x, mainCamera.transform.position.y - .9f, mainCamera.transform.position.z);
            mainCamera.transform.position = newPosition;
            fpController.m_WalkSpeed = fpController.m_WalkSpeed / 2f;
        }
        if (Input.GetKeyUp(KeyCode.C))
        {
            ableToSprint = true;
            anim.SetBool("onCrouch", onCrouch = false);
            anim.SetFloat("Speed", 1f);
            Vector3 newPosition = new Vector3(mainCamera.transform.position.x, mainCamera.transform.position.y + .9f, mainCamera.transform.position.z);
            mainCamera.transform.position = newPosition;
            fpController.m_WalkSpeed = fpController.m_WalkSpeed * 2f;
        }
        if(onCrouch == true)
        {
            isWalking = false;
            isRunning = false;
        }

    }
}
