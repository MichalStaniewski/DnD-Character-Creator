using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform orientation;
    [SerializeField] private Transform player;
    [SerializeField] private Transform playerObj;
    [SerializeField] private Rigidbody rb;

    [SerializeField] private CharacterController controller;

    [SerializeField] private Transform camTransform;

    [SerializeField] private Animator animator;

    [Header("Variables")]
    [SerializeField] private float moveSpeed = 6f;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float groundDrag;
    
    private float turnSmoothing = 0.1f;
    private float turnSmoothVelocity;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void FixedUpdate()
    {        
        float _hori = Input.GetAxisRaw("Horizontal");
        float _vert = Input.GetAxisRaw("Vertical");

        Vector3 _direction = new Vector3(_hori, 0f, _vert).normalized;

        if (_direction.magnitude >= 0.1f)
        {
            animator.SetBool("IsRunning", true);

            float _targetAngle = Mathf.Atan2(_direction.x, _direction.z) * Mathf.Rad2Deg + camTransform.eulerAngles.y;
            float _angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, _targetAngle, ref turnSmoothVelocity, turnSmoothing); 
            transform.rotation = Quaternion.Euler(0f, _angle, 0f);

            Vector3 _moveDir = Quaternion.Euler(0f, _targetAngle, 0f) * Vector3.forward;

            controller.Move(_moveDir.normalized * moveSpeed * Time.deltaTime);
        }
        else
        {
            animator.SetBool("IsRunning", false);
        }

        
        /*
        Vector3 _viewDirection = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
        orientation.forward = _viewDirection.normalized;

        float _hori = Input.GetAxisRaw("Horizontal");
        float _vert = Input.GetAxisRaw("Vertical");

        Vector3 _direction = orientation.forward * _vert + orientation.right * _hori;

        if (_direction != Vector3.zero)
        {
            playerObj.forward = Vector3.Slerp(playerObj.forward, _direction.normalized, Time.deltaTime * rotationSpeed);
        }

        rb.AddForce(_direction.normalized * moveSpeed * 10f, ForceMode.Force);
        rb.drag = groundDrag;
        */
    }
}