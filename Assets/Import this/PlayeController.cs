using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayeController : MonoBehaviour
{
    public int walkingPitch = 1;
    public float SprintingPitch = 1.2f;
    public float speed = 10.0f;
    public float maxSprintTime = 10.0f;
    public float sprintCooldownTime = 3.0f;
    public bool playerSprinting;
    public bool canScream;
    public DateTime sprintStartTime; // triggers when Left Shift is pressed down
    public DateTime sprintStopTime;  // triggers when Left Shit is released
    public DateTime cooldownStartTime;  // triggers when Left Shift is already down and sprint time has been too long
    public AudioClip walkingSound;
    public AudioSource screamSource;
    public AudioClip screamSound;
    public GameObject flashLight;
    public AudioSource flashlightSource;
    public AudioSource gunSource;
    public AudioClip gunClip;
    public AudioClip flashlightClip;
    public GameObject BulletPrefab;
    private List<GameObject> Projectiles = new List<GameObject>();
    private float projectileVelocity = 10;
    public int clipSize;
    public Text clipText;
    public bool holdingGun;
    public GameObject gun;
    public Transform firstPersonCharacter;
    public Image gunImage;
    public Image flashlightImage;


    // Use this for initializationa
    void Start()
    {
        gunImage.enabled = false;
        flashlightImage.enabled = false;
        screamSource.clip = screamSound;
        flashlightSource.clip = flashlightClip;
        gunSource.clip = gunClip;
        playerSprinting = false;
        canScream = true;
        Cursor.lockState = CursorLockMode.Locked; //does not show the cursor and locks it in the game window
        sprintStopTime = DateTime.Now.Subtract(new TimeSpan(0, 1, 0));  
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.V) && canScream == true)
        {
            screamSource.Play();
            StartCoroutine(Scream());

        }
        if (Input.GetKeyDown("escape")) // if user presses escape unlock the cursor
        {
            Cursor.lockState = CursorLockMode.None;
        }
        /*if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))                // player starts sprinting
        {
            sprintStartTime = DateTime.Now;

            TimeSpan cooldownTime = sprintStartTime - sprintStopTime;

            if (cooldownTime.TotalSeconds >= sprintCooldownTime)
            {
                Sprint();
            }
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))              // player stops sprinting
        {
            sprintStopTime = DateTime.Now;

            Walk();
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (playerSprinting)                            // player is still sprinting
            {
                TimeSpan sprintingTime = DateTime.Now - sprintStartTime;

                if (sprintingTime.TotalSeconds >= maxSprintTime)
                {
                    cooldownStartTime = DateTime.Now;
                    Walk();
                }
            }
            else                                            // player has Left Shift down, but is walking due to being tired
            {
                TimeSpan restTime = DateTime.Now - cooldownStartTime;

                if(restTime.TotalSeconds >= sprintCooldownTime)
                {
                    sprintStartTime = DateTime.Now;
                    Sprint();
                }
            }
        }*/
           /* if (Input.GetMouseButtonDown(0) && clipSize > 0) //pressed left click
            {
                GameObject bullet = (GameObject)Instantiate(BulletPrefab, transform.position, Quaternion.identity);//create bullet
                Projectiles.Add(bullet); // add bullets to projectiles list
                clipSize = clipSize - 1;
                ClipSizeText();
                Destroy(bullet, 4.0f); // after 4 seconds destroy bullet
            }

            for (int i = 0; i < Projectiles.Count; i++) // if there is less than 0 bullet then it will not loop, otherwise loop
            {
                GameObject goBullet = Projectiles[i]; // count the number of bullets
                if (goBullet != null)
                {
                    goBullet.transform.Translate(new Vector3(1, 0) * Time.deltaTime * projectileVelocity);
                }
            }*/
        
        if (Input.GetKeyUp(KeyCode.R) && gun == true)
        {
            StartCoroutine(Reload());
        }
        if (Input.GetKeyDown(KeyCode.Alpha1) && gun.activeInHierarchy == true)
        {
           
            if (flashLight.activeInHierarchy == false && gun.activeInHierarchy == true) // pull flash light out put gun up (gun out)b4
            {
                gunImage.enabled = false;
                gun.SetActive(false);
                flashlightImage.enabled = true;
                flashLight.SetActive(true);
                flashlightSource.Play();
                print("1");
            }
        
        }
        if (Input.GetKeyDown(KeyCode.Alpha1) && gun.activeInHierarchy == false)     
        {

            if (flashLight.activeInHierarchy == false && gun.activeInHierarchy == false) // pull flash light out put nothing up(hands out)b4
            {
                flashlightImage.enabled = true;
                flashLight.SetActive(true);
                flashlightSource.Play();
                print("2");
            }

        }
        if (Input.GetKeyDown(KeyCode.Mouse1) && flashLight.activeInHierarchy == true)
        {
            if (flashLight.activeInHierarchy == true && gun.activeInHierarchy == false) //pull nothing out put flash light up (flashlight out)b4
            {
                flashlightImage.enabled = false;
                flashLight.SetActive(false);
                print("3");
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && flashLight.activeInHierarchy == true)
        {
            if (flashLight.activeInHierarchy == true && gun.activeInHierarchy == false) //pull gun out put flash light up (flashlight out)b4
            {
                flashLight.SetActive(false);
                gun.SetActive(true);
                gunSource.Play();
                flashlightImage.enabled = false;
                gunImage.enabled = true;
                print("5");
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && flashLight.activeInHierarchy == false)
        {
            if (flashLight.activeInHierarchy == false && gun.activeInHierarchy == false) //pull gun out put nothing up (hands out)b4
            {
                gun.SetActive(true);
                gunSource.Play();
                gunImage.enabled = true;
                print("6");
            }
        }
        if (Input.GetKeyDown(KeyCode.Mouse1) && gun.activeInHierarchy == true)
        {
            if (flashLight.activeInHierarchy == false && gun.activeInHierarchy == true) //put gun up nothing out b4
            {
                gunImage.enabled = false;
                gun.SetActive(false);
                print("7");
            }
        }
    }
    /*void Sprint()
    {
        print("Sprint");

        speed = 12.5f;
        playerSprinting = true;
        audioSource.Play();
        audioSource.pitch = SprintingPitch;
        return;
    }

    void Walk()
    {
        print("Walk");
        speed = 10.0f;
        playerSprinting = false;
        audioSource.Play();
        audioSource.pitch = walkingPitch;
        return;
    }*/

    public void ClipSizeText()
    {
        clipText.text = "Ammo: " + clipSize.ToString();
    }

    IEnumerator Scream()
    {
        canScream = false;
        yield return new WaitForSeconds(6);
        canScream = true;
    }

    IEnumerator Reload() //wait function
    {
        yield return new WaitForSeconds(1.5f);
        clipSize = 12;
        print("Reloaded");
    }
   

}
