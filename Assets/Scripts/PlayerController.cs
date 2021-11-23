using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject projectilePrefab;

    private float horizontalInput;
    private float verticalInput;

    private readonly float movementSpeed = 5;

    // Start is called before the first frame update
    void Start()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed * verticalInput);
        transform.Translate(Vector3.right * Time.deltaTime * movementSpeed * horizontalInput);

        if (Input.GetKeyDown(KeyCode.W))
        {
            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");

            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            Debug.Log(transform.position);
            Instantiate(projectilePrefab, transform.position, transform.rotation);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            horizontalInput = Input.GetAxis("Vertical");
            verticalInput = Input.GetAxis("Horizontal");
            transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
            Instantiate(projectilePrefab, transform.position, transform.rotation);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");
            transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
            Instantiate(projectilePrefab, transform.position, transform.rotation);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            horizontalInput = Input.GetAxis("Vertical");
            verticalInput = Input.GetAxis("Horizontal");
            transform.rotation = Quaternion.Euler(new Vector3(0, -90, 0));
            Instantiate(projectilePrefab, transform.position, transform.rotation);
        }
    }
}
