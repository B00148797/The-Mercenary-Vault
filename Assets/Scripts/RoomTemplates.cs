using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
	//List of possibilities according to the available direction
	public GameObject[] topRooms;
	public GameObject[] rightRooms;
	public GameObject[] bottomRooms;
	public GameObject[] leftRooms;

	// 3D GameObjects
	public GameObject closedRoom;
	public GameObject boss;

	//Save the Rooms in order of their appearance
	public List<GameObject> rooms;

	//Time to wait before spawning the boss
	private readonly float waitTimeSpawnBoss = 4;

    private void Start()
    {
		StartCoroutine(SpawnBoss());
    }

    void Update()
	{

	}

	/// <summary>
	/// Wait for the stage to be full loaded before spawning the boss
	/// </summary>
	/// <returns></returns>
	private IEnumerator SpawnBoss()
    {
		yield return new WaitForSeconds(waitTimeSpawnBoss);
		for (int i = 0; i < rooms.Count; i++)
		{
			if (i == rooms.Count - 1)
			{
				Instantiate(boss, rooms[i].transform.position, transform.rotation);
			}
		}
	}
}