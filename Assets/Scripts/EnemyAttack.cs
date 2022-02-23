using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float attackCooldown = 1;
    public Transform attackPos;
    public float attackRange = 2;
    public float attackCastTime = 0.7f;
    public float attackAnimationFinishTime = 1.27f;
    public LayerMask playerLayer;
    public Animator animator;
    public int baseAtkDamage = 5;
    public int attackDamage;
    public Coroutine attackCorutine;
    public bool canAttack;
    private Transform playerTransform;
    void Start()
    {
        attackDamage = GM.level * baseAtkDamage;
        playerTransform = GameObject.Find("Player").transform;
        canAttack = true;
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, playerTransform.position) <= 2 && canAttack)
        {
            attackCorutine = StartCoroutine(Attack());
        }
    }

    public IEnumerator Attack()
    {
        canAttack = false;

        // let enemy stop moving while attacking
        float initialSpeed = gameObject.GetComponent<EnemyMovement>().speed;
        gameObject.GetComponent<EnemyMovement>().speed = 0;

        // play attack animation
        animator.SetTrigger("Attack");

        // cast time
        yield return new WaitForSeconds(attackCastTime);

        // start collision test
        Collider[] playerHit = Physics.OverlapSphere(attackPos.position, attackRange, playerLayer);
        foreach (Collider player in playerHit)
        {
            StartCoroutine(player.GetComponent<PlayerDamaged>().TakeDamage(attackDamage));
        }

        // wait for animation to finish 0.5f(total) - 0.23f(cast time) + 1f(exit time)
        yield return new WaitForSeconds(attackAnimationFinishTime);

        // return to original speed
        gameObject.GetComponent<EnemyMovement>().speed = initialSpeed;

        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
