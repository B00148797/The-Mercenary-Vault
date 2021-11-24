using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject projectilePrefab;
    public GameObject cameraGameObject;
    private Vector3 positionCameraComparedPlane = new Vector3(0, 8, 0);

    private float horizontalInput;
    private float verticalInput;

    private readonly float movementSpeed = 5;

    // For the rotation while throwing projectiles
    private string direction = "up";
    private Vector3 lookingForward = new Vector3(0, 0, 0);
    private Vector3 lookingBackward = new Vector3(0, 180, 0);
    private Vector3 lookingRight = new Vector3(0, 90, 0);
    private Vector3 lookingLeft = new Vector3(0, -90, 0);

    // Boolean to avoid spamming
    public bool throwableProjectiles = true;

    // Health
    public int health = 3;

    // Reach the end of the level boolean
    public bool win = false;

    // Start is called before the first frame update
    void Start()
    {
        
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

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Plane")
        {
            positionCameraComparedPlane.x = collision.transform.position.x;
            positionCameraComparedPlane.z = collision.transform.position.z;

            cameraGameObject.transform.position = positionCameraComparedPlane;
        }

        if (collision.gameObject.CompareTag("Boss"))
        {
            win = true;
        }
    }

    private void ThrowProjectile(string throwDirection)
    {
        if (throwableProjectiles)
        {
            Instantiate(projectilePrefab, transform.position + transform.forward, transform.rotation);
            direction = throwDirection;
            throwableProjectiles = false;
        }
    }
}
