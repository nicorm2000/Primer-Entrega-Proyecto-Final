using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    Animator animator;
    private int isWalkingHash;
    private int isRunningHash;
    [SerializeField] float speedWalking = 4f;
    [SerializeField] float speedRunning = 7f;
    [SerializeField] float jumpForce = 10f;
    [SerializeField] float mouseXAxis;
    private bool isCollide = false;
    [SerializeField] float countTime = 0;
    [SerializeField] GameObject[] spawnerArray;
    private Rigidbody rb;
    [SerializeField] LayerMask groundLayer;
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");

    }

    void Update()
    {
        AnimateCharacter();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (IsGrounded())
            {
                Jump();
                
            }
            

        }
    }

    private void AnimateCharacter()
    {
        bool isWalking = animator.GetBool(isWalkingHash);
        bool forwardPressed = Input.GetKey("w");
        bool backwardPressed = Input.GetKey("s");
        bool isRunning = animator.GetBool(isRunningHash);
        bool runningPressed = Input.GetKey("left shift");

        if (forwardPressed || backwardPressed)
        {
            Move(speedWalking);
        }
        if (forwardPressed && runningPressed)
        {
            Move(speedRunning);
        }

        RotatePlayer();

        if (!isWalking && (forwardPressed || backwardPressed))
        {
            animator.SetBool(isWalkingHash, true);
        }
        else if (isWalking && (!forwardPressed || !backwardPressed))
        {
            animator.SetBool(isWalkingHash, false);
        }

        if (!isRunning && (runningPressed && forwardPressed))
        {
            animator.SetBool(isRunningHash, true);
            Move(speedRunning);
        }
        else if (isRunning && (!runningPressed || !forwardPressed))
        {
            animator.SetBool(isRunningHash, false);
        }
    }
    private void Move(float speed)
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(horizontal, 0, vertical) * speed * Time.deltaTime);
    }

    private void RotatePlayer()
    {
        mouseXAxis += Input.GetAxis("Mouse X");
        Quaternion newrotation = Quaternion.Euler(0, mouseXAxis, 0);
        transform.rotation = newrotation;
    }

    private void Jump()
    {
        rb.AddForce(0, 1 * jumpForce, 0);
    }


    private bool IsGrounded()
    {
        if (Physics.Raycast(transform.position, Vector3.down, 0.5f, groundLayer))
        {
            return true;
        }
        else return false;
    }
    private void OnCollisionStay(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Spawner") && !isCollide)
        {
            countTime += Time.deltaTime;
            if (countTime > 2 && collision.gameObject.name == "Spawner")
            {
                countTime = 0;
                Destroy(spawnerArray[0]);
            }
            if (countTime > 2 && collision.gameObject.name == "Spawner1")
            {
                countTime = 0;
                Destroy(spawnerArray[1]);
            }
        }
        if (collision.gameObject.CompareTag("Spawner1") && !isCollide)
        {
            countTime += Time.deltaTime;
            if (countTime > 2 && collision.gameObject.name == "Spawner2")
            {
                countTime = 0;
                Destroy(spawnerArray[2]);
            }
            if (countTime > 2 && collision.gameObject.name == "Spawner3")
            {
                countTime = 0;
                Destroy(spawnerArray[3]);
            }
        }
        if (collision.gameObject.CompareTag("Spawner2") && !isCollide)
        {
            countTime += Time.deltaTime;
            if (countTime > 2 && collision.gameObject.name == "Spawner4")
            {
                countTime = 0;
                Destroy(spawnerArray[4]);
            }
            if (countTime > 2 && collision.gameObject.name == "Spawner5")
            {
                countTime = 0;
                Destroy(spawnerArray[5]);
            }
        }
        
    }
}