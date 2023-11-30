using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {

    public float speed = 4f;
    public float speedVariancePercent = 35.0f;
    public bool right;
    public Rigidbody rigidBody;
    public GameObject asteroid;

    void Start()
    {
        right = true;

        Vector3 vector = Random.Range(0f, 1f) < 0.5f ? Vector3.left : Vector3.right;

        float randomSpeed = speed + Random.Range(-0.01f * speedVariancePercent, 0.01f * speedVariancePercent) * speed;
        rigidBody.velocity = vector * randomSpeed;
    }

    void FixedUpdate()
    {
        //rigidBody.velocity = Vector3.right * speed * Time.deltaTime;
        if (right)
        {
            //transform.position = transform.position + (Vector3.right * speed * Time.deltaTime);
            //rigidBody.MovePosition(rigidBody.position + (Vector3.right * speed * Time.deltaTime));
            //rigidBody.velocity = Vector3.right * speed;
        }
        if (right == false)
        {
            //transform.position = transform.position + (Vector3.left * speed * Time.deltaTime);
            //rigidBody.MovePosition(rigidBody.position + (Vector3.left * speed * Time.deltaTime));
            //rigidBody.velocity = Vector3.left * speed;
        }

    }
    //void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Bounce") && right == true)
    //    {
    //        right = false;
    //        print("collided");
    //        Vector3 rotationY = new Vector3();
    //        rotationY.Set(0f, 180f, 0f);
    //        rotationY = rotationY.normalized * speed;
    //        Quaternion deltaRotation = Quaternion.Euler(rotationY);
    //        //transform.Rotate(0, 180, 0);
    //        rigidBody.MoveRotation(deltaRotation);
    //    }
    //    if (collision.gameObject.CompareTag("Bounce") && right == false)
    //    {
    //        //transform.Rotate(0, 180, 0);
    //        Vector3 rotationY = new Vector3();
    //        rotationY.Set(0f, 180f, 0f);
    //        rotationY = rotationY.normalized * speed;
    //        Quaternion deltaRotation = Quaternion.Euler(rotationY);
    //        rigidBody.MoveRotation(deltaRotation);

    //        right = true;
    //    }
    //}
 
}

