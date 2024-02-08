using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float rotationSpeed;
    [SerializeField] private Transform camera;

    private float moveSpeed;
    private float originalStepOffset;
    private float ySpeed;
    private CharacterController characterController;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        originalStepOffset = characterController.stepOffset;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(horizontalInput, 0, verticalInput);
        float magnitude = Mathf.Clamp01(move.magnitude) * moveSpeed;
        move.Normalize();

        move = Quaternion.AngleAxis(camera.rotation.eulerAngles.y, Vector3.up) * move;

        Vector3 velocity = move * magnitude;
        velocity.y = ySpeed;

        characterController.Move(velocity * Time.deltaTime);

        if (move != Vector3.zero)
        {
            animator.SetBool("IsWalking", true);
            Quaternion toRotation = Quaternion.LookRotation(move, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }
    }

    private void OnDisable()
    {
        animator.SetBool("IsWalking", false);
    }
}

