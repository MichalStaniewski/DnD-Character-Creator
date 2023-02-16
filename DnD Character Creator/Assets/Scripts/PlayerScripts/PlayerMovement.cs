using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("References")]    
    [SerializeField] private Transform player;
    [SerializeField] private Transform playerObj;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private Transform camTransform;

    [SerializeField] private CharacterController controller;

    [SerializeField] private Animator animator;

    [SerializeField] private LayerMask groundMask;

    [SerializeField] private PlayerCombat playerCombat;

    [Header("Variables")]
    [SerializeField] private float moveSpeed = 6f;
    [SerializeField] private float jumpHeight = 3f;

    [SerializeField] private float groundCheckDistance;
    [SerializeField] private float gravity = -9.8f;

    private Vector3 fallingVelocity;
    private bool isGrounded;

    private float turnSmoothing = 0.1f;
    private float turnSmoothVelocity;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        playerCombat = GetComponent<PlayerCombat>();
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

    private void PlayerAiming()
    {
        //move camera behind shoulder
        //rotate player to look in direction they're aiming
        //come up with a crosshair idea or a way to help aiming
    }

    private void PlayerJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            animator.SetTrigger("Jump");
            fallingVelocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }

    private void PlayerAttack()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            playerCombat.Attack();
            animator.SetTrigger("Attack");            
        }
    }

    private void PlayerGravity()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckDistance, groundMask);

        if (isGrounded && fallingVelocity.y < 0)
        {
            fallingVelocity.y = -4f;
        }

        fallingVelocity.y += gravity * Time.deltaTime;

        controller.Move(fallingVelocity * Time.deltaTime);
    }
}