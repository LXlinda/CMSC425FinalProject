using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 3f;
    public Animator animator;
    public float runSpeed = 5f;
    public float dashDistance = 5;
    public float dashCD = 1;
    private Vector3 lastDir;
    Rigidbody rb;
    private float lastDashTime = 0;

    void start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
            Debug.Log("what?");
    }
    void Update()
    {
        handleMovement();
        handleLookDir();
    }

    void FixedUpdate()
    {
        handleDash();
    }

    private void handleMovement()
    {
        float currentSpeed = moveSpeed;
        Vector3 moveDir = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            moveDir += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveDir += Vector3.back;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveDir += Vector3.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveDir += Vector3.right;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            // character is running
            currentSpeed = runSpeed;
        }
        bool isIdle = moveDir == Vector3.zero;
        if (isIdle)
        {
            animator.SetFloat("Speed", 0f);
        }
        else
        {
            animator.SetFloat("Speed", currentSpeed);
        }
        moveDir = moveDir.normalized;
        lastDir = moveDir;
        transform.Translate(currentSpeed * moveDir * Time.deltaTime, Space.World);
    }

    private void handleLookDir()
    {
        // Let player look at mouse position
        Vector3 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.LookAt(new Vector3(point.x, 1, point.z + point.y));
    }

    private void handleDash()
    {
        float currentTime = Time.time;
        if (Input.GetKeyDown(KeyCode.Space) && currentTime - lastDashTime > dashCD)
        {
            rb = GetComponent<Rigidbody>();
            rb.AddForce(lastDir * dashDistance, ForceMode.Impulse);
            lastDashTime = Time.time;
        }
    }
}
