using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private Transform cameraTarget;
    [SerializeField] private float speed = 4f;
    [SerializeField] private float rotationSpeed = 4f;
    [SerializeField] private float gravityScale = -9f;
    [SerializeField] private float jumpForce = 1.5f;
    [Space]
    [SerializeField] private int frameRate = 30;
    private bool jump;

    private CharacterController cc;
    private Animator animator;
    private float gravity;
    private bool airCheck;

    public float JumpHeight { get { return Mathf.Sqrt(jumpForce * -2f * gravityScale); } }

    private void Awake()
    {
        // Variables on any Service should be SET in Awake()
        ServiceLocator.Current.Get<PlayerManager>().Player = gameObject;
    }

    // Start is called before the first frame update
    void Start()
    {
        // Variables on any service should GET in Start()
        cameraTarget = ServiceLocator.Current.Get<PlayerManager>().CameraTarget.transform;
        cc = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Testing to make sure everything is frame independant
        Application.targetFrameRate = frameRate;

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 inputVector = new Vector3(horizontalInput, 0, verticalInput);

        var fwdVector = Vector3.Cross(cameraTarget.right, transform.up) * verticalInput;
        var rightVector = cameraTarget.right * horizontalInput;

        var movementVector = fwdVector + rightVector;
        movementVector *= speed;

        if(cc.velocity.magnitude > 0)
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(movementVector.normalized), Time.deltaTime * rotationSpeed);

        if (cc.isGrounded) {
            gravity = gravityScale;
            if (jump)
            {
                gravity = JumpHeight;

                jump = false;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                animator.SetTrigger("Jump");
            }
            if (airCheck)
            {
                airCheck = false;
                animator.SetTrigger("LandedJump");
            }
        }
        else
        {
            gravity += gravityScale * Time.deltaTime;
            airCheck = true;
        }

        movementVector.y = gravity;
        cc.Move(movementVector * Time.deltaTime);

        animator.SetFloat("Speed", inputVector.magnitude);
        animator.SetBool("IsGrounded", cc.isGrounded);
    }

    // This is called by the jump animation on the player
    // This could probably just call a jump function
    public void Jump()
    {
        jump = true;
    }


    // This was just some test code 
    //private void OnGUI()
    //{
    //    GUILayout.Label(gravity.ToString());
    //    GUILayout.Label(cc.isGrounded.ToString());
    //}
}
