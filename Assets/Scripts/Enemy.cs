using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int life;
    public int speed = 0;

    void Start()
    {
        
    }

    void Update()
    {
        if (life <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Projectile")
        {
            life--;
            Destroy(collision.gameObject);
        }
    }
}