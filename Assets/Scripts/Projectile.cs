using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * 10);

        if(transform.position.x > 200 || transform.position.x < -200 || transform.position.z > 200 || transform.position.z < -200)
        {
            Destroy(gameObject);
        }
    }
}
