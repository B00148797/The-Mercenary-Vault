using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float projectileSpeed = 10;
    private float destroyObjectsLimit = 50;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * projectileSpeed);
        // TODO : Search for a better destroy condition
        if(transform.position.x > destroyObjectsLimit || transform.position.x < -destroyObjectsLimit || transform.position.z > destroyObjectsLimit || transform.position.z < -destroyObjectsLimit)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(!collision.gameObject.CompareTag("Player")) Destroy(gameObject);
    }
}
