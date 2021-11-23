using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRoom : MonoBehaviour
{

    public int needRoomDirection;

    public GameObject[] topRooms;
    public GameObject[] rightRooms;
    public GameObject[] bottomRooms;
    public GameObject[] leftRooms;

    private GameObject closedRoom;

    public List<GameObject> rooms;
    private float waitTime = 4;
    private bool spawnedBoss;
    private GameObject bossRoom;


    private int rand;
    /*
     1 - TOP
     2 - RIGHT
     3 - BOTTOM
     4 - LEFT   
     */

    void Start()
    {
        Destroy(gameObject, waitTime);
        Invoke("Spawn", 0.1f);
        bossRoom = GameObject.Find("Boss");
    }

    void Spawn()
    {
        switch (needRoomDirection)
        {
            case 0:
                break;
            case 1:
                rand = Random.Range(0, topRooms.Length);
                Instantiate(topRooms[rand], transform.position, topRooms[rand].transform.rotation);
                break;
            case 2:
                rand = Random.Range(0, rightRooms.Length);
                Instantiate(rightRooms[rand], transform.position, rightRooms[rand].transform.rotation);
                break;
            case 3:
                rand = Random.Range(0, bottomRooms.Length);
                Instantiate(bottomRooms[rand], transform.position, bottomRooms[rand].transform.rotation);
                break;
            case 4:
                rand = Random.Range(0, leftRooms.Length);
                Instantiate(leftRooms[rand], transform.position, leftRooms[rand].transform.rotation);
                break;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);

        if (collision.gameObject.CompareTag("SpawnPoint"))
        {
            closedRoom = GameObject.Find("CloseRoom");
            Instantiate(closedRoom, transform.position, transform.rotation);
        }
    }
}