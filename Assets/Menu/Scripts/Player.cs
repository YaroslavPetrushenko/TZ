using System;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float gravity = -9.8f;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpHeight = 2f;
    [SerializeField] private Animator animator;
    [SerializeField] private CharacterController controller;
    private bool isGrounded;
    private Vector3 velocity;
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        isGrounded = controller.isGrounded;
    }

    void Update()
    {
        animator.SetBool("Grounded", isGrounded);
        animator.SetBool("Jump", false);
        
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            animator.SetBool("Jump", true);
        }
        controller.Move(speed * Time.deltaTime * Vector3.right * Input.GetAxis("Horizontal"));
        animator.SetFloat("Speed", controller.velocity.magnitude);

        //animator.SetBool("Jump", false);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    void OnFootstep()
    {
        
    }

    void OnLand()
    {
        Debug.Log("land");
    }
}
