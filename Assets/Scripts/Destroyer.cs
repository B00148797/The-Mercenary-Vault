using UnityEngine;

public class Destroyer : MonoBehaviour
{
    void Start()
    {
        Physics.IgnoreCollision(GameObject.Find("Player").GetComponent<Collider>(), GetComponent<Collider>());
    }

    void OnCollisionEnter(Collision collision)
    {
        //Allows you to delete the CloseRooms only located on the four openings of the starting RoomMain
        if (collision.gameObject.CompareTag("CloseRoom"))
        {
            Destroy(collision.gameObject);
        }
    }
}
