using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterMovement : MonoBehaviour
{
    Vector3 playerVelocity;
    Vector3 move;

    public float walkSpeed = 5;
    public float runSpeed = 8;
    public float jumpHeight = 2;
    public float gravity = -9.81f;
    public float turnSmoothTime = 2f;
    public float rotationMinY = -90;
    public float rotationMaxY = 90;
    public float rotationMinX = -90;
    public float rotationMaxX = 90;
    public bool gotDoubleBoost;
    public bool canDoubleJump = false;

    private GameManager gameManager;
    private CharacterController controller;
    private Animator animator;
    public Transform orientation;
    public GameObject camera;
    public ParticleSystem ps;


    private void Start()
    {
        move = new Vector3(0, 0, 0);
        gameManager = GameManager.Instance;
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        DisableRootMotion();
    }

    private void Update()
    {
        ProcessRotation();
        ProcessGravity();
        ProcessMovement();


    }


    public void LateUpdate()
    {
        UpdateAnimator();
    }

    void DisableRootMotion()
    {
        animator.applyRootMotion = false;

    }

    void UpdateAnimator()
    {
        bool isGrounded = controller.isGrounded;
        Debug.Log("(" + move.x + "), " + "(" + move.y + "), " + "(" + move.y + "), ");

        if (move.x != 0)
        {
            if (GetMovementSpeed() == runSpeed)
            {
                animator.SetFloat("move", 1f);
            }
            else
            {
                animator.SetFloat("move", 0.5f);

            }
        }
        else
        {
            animator.SetFloat("move", 0.0f);
        }

        if (Input.GetButtonDown("Jump"))
        {
            animator.SetBool("isJump", true);
        }
        else
        {
            animator.SetBool("isJump", false);
        }

        if (canDoubleJump && gotDoubleBoost && Input.GetButtonDown("Jump"))
        {
            animator.SetBool("isDoubleJump", true);
        }
        else
        {
            animator.SetBool("isDoubleJump", false);

        }

        animator.SetBool("isGrounded", isGrounded);
    }

    void ProcessRotation()
    {
        float mouseX  = Input.GetAxisRaw("Mouse X");
        float mouseY  = Input.GetAxisRaw("Mouse Y");

        Vector3 currentRotation = transform.localEulerAngles;
        currentRotation.y += mouseX;
        Vector3 currentCameraRotation = camera.gameObject.transform.localEulerAngles;
        currentCameraRotation.x -= mouseY;

        transform.localRotation = Quaternion.AngleAxis(currentRotation.y, Vector3.up);

        if (currentCameraRotation.x > 30f && currentCameraRotation.x < 180f)
        {
            currentCameraRotation.x = 30f;
        }
        if (currentCameraRotation.x < 340f && currentCameraRotation.x > 180f)
        {
            currentCameraRotation.x = 340f;
        }

        camera.gameObject.transform.localRotation = Quaternion.AngleAxis(currentCameraRotation.x, Vector3.right);
    }

    void ProcessMovement()
    {
        float Horizontal = Input.GetAxis("Horizontal") * GetMovementSpeed() * Time.deltaTime;
        float Vertical = Input.GetAxis("Vertical") * GetMovementSpeed() * Time.deltaTime;

        move = camera.transform.right * Horizontal + camera.transform.forward * Vertical + playerVelocity * Time.deltaTime;

        controller.Move(move);

    }


    public void ProcessGravity()
    {
        bool isGrounded = controller.isGrounded;

        if (isGrounded)
        {
            canDoubleJump = false;
            if (playerVelocity.y < 0.0f)
            {
                playerVelocity.y = -1.0f;
            }
            if (Input.GetButtonDown("Jump")) // Code to jump
            {

                playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravity);
                canDoubleJump = true;
            }

        }
        else // if not grounded
        {
            if (canDoubleJump && gotDoubleBoost && Input.GetButtonDown("Jump"))
            {
                animator.SetBool("isDoubleJump", true);

                playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravity);

                gameManager.SetDoubleJump(false);
            }
            else
            {
                animator.SetBool("isDoubleJump", false);

            }
            playerVelocity.y += gravity * Time.deltaTime;
        }

        controller.Move(move * Time.deltaTime * GetMovementSpeed() + playerVelocity * Time.deltaTime);
    }



    float GetMovementSpeed()
    {
        if (Input.GetKey(KeyCode.Mouse0))// Left shift
        {
            return runSpeed;
        }
        else
        {
            return walkSpeed;
        }
    }

    public void setDoubleJump(bool jump)
    {
        gotDoubleBoost = jump;
    }
}
