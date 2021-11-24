using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int life;
    public int speed = 0;
    Camera camera;

    void Start()
    {
        camera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    void Update()
    {
        if (life <= 0)
        {
            Destroy(gameObject);
        }

        if (IsTargetVisible(camera, gameObject))
        {
            print("Je suis visible !");
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

    bool IsTargetVisible(Camera camera, GameObject gameObject)
    {
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(camera);
        Vector3 point = gameObject.transform.position;
        foreach (Plane plane in planes)
        {
            if (plane.GetDistanceToPoint(point) < 0)
            {
                return false;
            }
        }
        return true;
    }
}