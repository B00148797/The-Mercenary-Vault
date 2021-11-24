using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject projectilePrefab;
    public GameObject cameraGameObject;
    private Vector3 positionCameraComparedPlane = new Vector3(0, 8, 0);

    private float horizontalInput;
    private float verticalInput;

    private Rigidbody playerRb;
    private readonly float movementSpeed = 5;

    // For the rotation while throwing projectiles
    private string direction = "up";
    private Vector3 lookingForward = new Vector3(0, 0, 0);
    private Vector3 lookingBackward = new Vector3(0, 180, 0);
    private Vector3 lookingRight = new Vector3(0, 90, 0);
    private Vector3 lookingLeft = new Vector3(0, -90, 0);

    // Boolean to avoid spamming
    public bool throwableProjectiles = true;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

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
                playerRb.AddForce(Vector3.forward * Time.deltaTime * movementSpeed * verticalInput, ForceMode.Force);
                playerRb.AddForce(Vector3.right * Time.deltaTime * movementSpeed * horizontalInput, ForceMode.Force);
                break;
            case "down":
                playerRb.AddForce(Vector3.forward * Time.deltaTime * movementSpeed * -verticalInput, ForceMode.Force);
                playerRb.AddForce(Vector3.right * Time.deltaTime * movementSpeed * -horizontalInput, ForceMode.Force);
                break;
            case "left":
                playerRb.AddForce(Vector3.forward * Time.deltaTime * movementSpeed * -horizontalInput, ForceMode.Force);
                playerRb.AddForce(Vector3.right * Time.deltaTime * movementSpeed * verticalInput, ForceMode.Force);
                break;
            case "right":
                playerRb.AddForce(Vector3.forward * Time.deltaTime * movementSpeed * horizontalInput, ForceMode.Force);
                playerRb.AddForce(Vector3.right * Time.deltaTime * movementSpeed * -verticalInput, ForceMode.Force);
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

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Plane")
        {
            positionCameraComparedPlane.x = collision.transform.position.x;
            positionCameraComparedPlane.z = collision.transform.position.z;

            cameraGameObject.transform.position = positionCameraComparedPlane;
        }
    }

    private void ThrowProjectile(string throwDirection)
    {
        if (throwableProjectiles)
        {
            Instantiate(projectilePrefab, transform.position, transform.rotation);
            direction = throwDirection;
            throwableProjectiles = false;
        }
    }
}
