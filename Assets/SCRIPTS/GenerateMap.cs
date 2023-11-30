using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateMap : MonoBehaviour
{
    public GameObject[] buildingArray;
    public Transform door;
    public GameObject[] corridorArray;
    public float[] currentX;
    public int boardSize = 1;
    // Start is called before the first frame update
    void Start()
    {
        currentX = new float[buildingArray.Length];
        for (int i= 0; i < boardSize; i++)
        {
            int number = Random.Range(0, buildingArray.Length);
            GameObject currentObject = buildingArray[number];
            float currentObjecty = currentObject.transform.position.y;
            door = currentObject.transform.Find("Door");
            if (i != 0)
            {
                Instantiate(currentObject, new Vector3(door.transform.position.x, 0 + currentObjecty, 0), transform.rotation);
            }
            else
            {
                Instantiate(currentObject, new Vector3(door.transform.position.x, 0 + currentObjecty, 0), transform.rotation);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
