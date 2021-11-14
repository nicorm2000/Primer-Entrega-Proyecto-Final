using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    Animator animator;
    int isWalkingHash;
    int isRunningHash;
    [SerializeField] float speedWalking = 5f;
    [SerializeField] float speedRunning = 10f;
    [SerializeField] float mouseXAxis;
    [SerializeField] float rotationSpeed = 10f;
    void Start()
    {
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
    }

    // Update is called once per frame
    void Update()
    {
        AnimateCharacter();
    }

    private void AnimateCharacter()
    {
        bool isWalking = animator.GetBool(isWalkingHash);
        bool forwardPressed = Input.GetKey("w");
        bool isRunning = animator.GetBool(isRunningHash);
        bool runningPressed = Input.GetKey("left shift");
        Move(speedWalking);
        RotatePlayer();

        if (!isWalking && forwardPressed)
        {
            animator.SetBool(isWalkingHash, true);
            Move(speedWalking);
        }
        else if (isWalking && !forwardPressed)
        {
            animator.SetBool(isWalkingHash, false);
            //Move(0);
        }
        else if (!isRunning && (runningPressed && forwardPressed))
        {
            animator.SetBool(isRunningHash, true);
            Move(speedRunning);
        }
        else if (isRunning && (!runningPressed || !forwardPressed))
        {
            animator.SetBool(isRunningHash, false);
            //Move(0);
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
}
