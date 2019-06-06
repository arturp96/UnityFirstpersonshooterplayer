/*using UnityEngine;

public class FpsController : MonoBehaviour
{


    public float speed = 3f, sensitivity = 3f;
    public GameObject eyes;


    private float moveFB, moveLR, rotX, rotY, vertVelocity;
    public float jumpForce = 4f;
    CharacterController player;


    private bool hasJumped;





    void Start()
    {
        player = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        Movement();
    }
    void Movement()
    {
        moveFB = Input.GetAxis("Vertical") * speed;
        moveLR = Input.GetAxis("Horizontal") * speed;



        rotX = Input.GetAxis("Mouse X") * sensitivity;
        rotY -= Input.GetAxis("Mouse Y") * sensitivity;
        rotY = Mathf.Clamp(rotY, -60f, 60f);


        Vector3 movement = new Vector3(moveLR, vertVelocity, moveFB);
        transform.Rotate(0, rotX, 0);

        eyes.transform.localRotation = Quaternion.Euler(rotY, 0, 0);
        movement = transform.rotation * movement;
        player.Move(movement * Time.deltaTime);

        if (Input.GetButtonDown("Jump"))
        {
            hasJumped = true;
        }

        ApplyGravity();

    }

    private void ApplyGravity()
    {
        if (player.isGrounded == true)
        {
            if (hasJumped == false)
            {
                vertVelocity = Physics.gravity.y;
            }
            else
            {
                vertVelocity = jumpForce;
            }

        }
        else
        {
            vertVelocity += Physics.gravity.y * Time.deltaTime;
            vertVelocity = Mathf.Clamp(vertVelocity, -50f, jumpForce);
            hasJumped = false;
        }
    }


}
*/
using UnityEngine;

public class FpsController : MonoBehaviour
{

    public static FpsController Instance;

    public float speed = 3f, sensitivity = 3f;
    public GameObject eyes;

    private float moveFB, moveLR, rotX, rotY, vertVelocity;
    public float jumpForce = 4f;
    CharacterController player;

    private bool hasJumped;

    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        player = GetComponent<CharacterController>();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        moveFB = Input.GetAxis("Vertical") * speed;
        moveLR = Input.GetAxis("Horizontal") * speed;

        rotX = Input.GetAxis("Mouse X") * sensitivity;
        rotY -= Input.GetAxis("Mouse Y") * sensitivity;
        rotY = Mathf.Clamp(rotY, -60f, 60f);

        Vector3 movement = new Vector3(moveLR, vertVelocity, moveFB);
        transform.Rotate(0, rotX, 0);

        eyes.transform.localRotation = Quaternion.Euler(rotY, 0, 0);
        movement = transform.rotation * movement;
        player.Move(movement * Time.deltaTime);

        if (Input.GetButtonDown("Jump"))
        {
            hasJumped = true;
        }

        ApplyGravity();

    }

    private void ApplyGravity()
    {
        if (player.isGrounded == true)
        {
            if (hasJumped == false)
            {
                vertVelocity = Physics.gravity.y;
            }
            else
            {
                vertVelocity = jumpForce;
            }

        }
        else
        {
            vertVelocity += Physics.gravity.y * Time.deltaTime;
            vertVelocity = Mathf.Clamp(vertVelocity, -50f, jumpForce);
            hasJumped = false;
        }
    }


}