using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform orientation;
    [SerializeField] private Transform player;
    [SerializeField] private Transform playerObj;

    [SerializeField] private CharacterController controller;

    [SerializeField] private Transform camTransform;

    [SerializeField] private Animator animator;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask groundMask;


    [Header("Variables")]
    [SerializeField] private float moveSpeed = 6f;
    [SerializeField] private float jumpHeight = 3f;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float groundDrag;

    [SerializeField] private float gravity = -9.8f;
    private Vector3 yVelocity;    
    private bool isGrounded;

    private float turnSmoothing = 0.1f;
    private float turnSmoothVelocity;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        PlayerJump();
        PlayerGravity();
        MovePlayer();
        PlayerAttack();
    }

    private void MovePlayer()
    {
        float _hori = Input.GetAxisRaw("Horizontal");
        float _vert = Input.GetAxisRaw("Vertical");

        Vector3 _direction = new Vector3(_hori, 0f, _vert).normalized;

        if (_direction.magnitude >= 0.1f)
        {
            animator.SetFloat("Speed", 0.5f, 0.1f, Time.deltaTime);

            float _targetAngle = Mathf.Atan2(_direction.x, _direction.z) * Mathf.Rad2Deg + camTransform.eulerAngles.y;
            float _angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, _targetAngle, ref turnSmoothVelocity, turnSmoothing);
            transform.rotation = Quaternion.Euler(0f, _angle, 0f);

            Vector3 _moveDir = Quaternion.Euler(0f, _targetAngle, 0f) * Vector3.forward;

            controller.Move(_moveDir.normalized * moveSpeed * Time.deltaTime);
        }
        else
        {
            animator.SetFloat("Speed", 0, 0.1f, Time.deltaTime);
        }
    }

    private void PlayerJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            animator.SetTrigger("Jump");
            yVelocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }

    private void PlayerAttack()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            animator.SetTrigger("Attack");
        }
    }

    private void PlayerGravity()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckDistance, groundMask);

        if (isGrounded && yVelocity.y < 0)
        {
            yVelocity.y = -4f;
        }

        yVelocity.y += gravity * Time.deltaTime;

        controller.Move(yVelocity * Time.deltaTime);
    }
}