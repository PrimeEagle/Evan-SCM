using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridTest : MonoBehaviour
{
    public int totalObjects;
    public GameObject[] rooms;
    public GameObject[] corridors;
    public float totalMapLength = 0;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < totalObjects; i++)
        {
            int roomNumber = Random.Range(0, rooms.Length);
            Instantiate(rooms[roomNumber], new Vector3(totalMapLength, 0,0),transform.rotation);
            totalMapLength  += rooms[roomNumber].transform.position.x;
            int corridorNumber = Random.Range(0, corridors.Length);
            Instantiate(corridors[corridorNumber], new Vector3(totalMapLength, 0, 0), transform.rotation);
            totalMapLength += corridors[corridorNumber].transform.position.x;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
