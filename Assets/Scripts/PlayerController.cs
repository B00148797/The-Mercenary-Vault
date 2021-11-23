using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject projectilePrefab;

    private float horizontalInput;
    private float verticalInput;

    private readonly float movementSpeed = 5;

    // For the rotation while throwing projectiles
    private string direction = "up";
    private Vector3 lookingForward = new Vector3(0, 0, 0);
    private Vector3 lookingBackward = new Vector3(0, 180, 0);
    private Vector3 lookingRight = new Vector3(0, 90, 0);
    private Vector3 lookingLeft = new Vector3(0, -90, 0);

    // Variables avoiding spamming
    public bool throwableProjectiles = true;

    // Update is called once per frame
    void Update()
    {

        // Movement based on QASD keys
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");


        // Translate direction according to the rotation of the player
        switch (direction)
        {
            case "up":
                transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed * verticalInput);
                transform.Translate(Vector3.right * Time.deltaTime * movementSpeed * horizontalInput);
                break;
            case "down":
                transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed * -verticalInput);
                transform.Translate(Vector3.right * Time.deltaTime * movementSpeed * -horizontalInput);
                break;
            case "left":
                transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed * -horizontalInput);
                transform.Translate(Vector3.right * Time.deltaTime * movementSpeed * verticalInput);
                break;
            case "right":
                transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed * horizontalInput);
                transform.Translate(Vector3.right * Time.deltaTime * movementSpeed * -verticalInput);
                break;

        }

        // Throw a projectile toward the top of the screen
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.rotation = Quaternion.Euler(lookingForward);
            ThrowProjectile("up");
        }

        // Throw a projectile toward the left of the screen
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.rotation = Quaternion.Euler(lookingLeft);
            ThrowProjectile("left");
        }

        // Throw a projectile toward the bottom of the screen
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.rotation = Quaternion.Euler(lookingBackward);
            ThrowProjectile("down");
        }

        // Throw a projectile toward the right of the screen
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.rotation = Quaternion.Euler(lookingRight);
            ThrowProjectile("right");
        }
    }

    private void ThrowProjectile(string directionToThrow)
    {
        if (throwableProjectiles)
        {
            Instantiate(projectilePrefab, transform.position, transform.rotation);
            direction = directionToThrow;
            throwableProjectiles = false;
        }
    }
}
