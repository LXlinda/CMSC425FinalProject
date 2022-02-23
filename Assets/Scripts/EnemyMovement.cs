using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 5;
    public Animator animator;
    private Transform playerTransform;
    void Start()
    {
        playerTransform = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = playerTransform.position - transform.position;
        direction.y = 0;
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
        transform.LookAt(new Vector3(playerTransform.position.x, 1, playerTransform.position.z));
        animator.SetFloat("Speed", speed);
    }
}
