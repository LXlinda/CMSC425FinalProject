using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator animator;
    public float attackCooldown;
    public Transform attackPos;
    public float attackRange = 2;
    public LayerMask enemy;

    private bool isAttacking;
    private AudioSource attackSound;
    void Start()
    {
        isAttacking = false;
        attackSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            StartCoroutine(Attack());
    }

    
    IEnumerator Attack(){
        if (isAttacking)
            yield break;
        isAttacking = true;

        attackSound.Play();
        // play attack animation
        animator.SetTrigger("Attack");
        // attack animation time
        yield return new WaitForSeconds(0.3f);

        Collider[] enemiesHit = Physics.OverlapSphere(attackPos.position, attackRange, enemy);
        foreach(Collider enemy in enemiesHit){
            StartCoroutine(enemy.GetComponent<EnemyDamaged>().TakeDamage(GM.atk));
        }

        yield return new WaitForSeconds(attackCooldown);
        isAttacking = false;
    }

    void OnDrawGizmosSelected(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
