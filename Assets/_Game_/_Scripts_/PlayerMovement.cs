using UnityEngine;
using UnityEngine.Rendering;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;


    public float GroundDrag;
    public float playerHeight;
    public LayerMask whatIsGround;
    [SerializeField]bool grounded;


    public Transform oriantation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDir;

    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame

    
    void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.33f, whatIsGround);
        Debug.DrawRay(transform.position, Vector3.down * (playerHeight * 0.5f + 0.33f), Color.red);
        MyInput();
        if (grounded)
        {
            rb.linearDamping = GroundDrag;
        }
        else
        {
            rb.linearDamping = 0;
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }
    void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    void MovePlayer()
    {
        moveDir = oriantation.forward * verticalInput + oriantation.right * horizontalInput;

        rb.AddForce(moveDir.normalized * moveSpeed * 10f,ForceMode.Force);
    }
}
