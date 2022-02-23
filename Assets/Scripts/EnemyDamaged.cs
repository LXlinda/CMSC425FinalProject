using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamaged : MonoBehaviour
{
    public int baseHealth = 10;
    public Animator animator;
    public float recoverTime = 1;
    private int currentHealth;
    public int maxHealth;
    public AudioSource DamageSound;
    void Start()
    {
        maxHealth = GM.level*baseHealth;
        currentHealth = maxHealth;
    }

    public IEnumerator TakeDamage(int damage)
    {
        if (currentHealth <= 0)
            yield break;

        currentHealth -= damage;

        // play hurt animation
        animator.SetTrigger("TakeDamage");
        DamageSound.Play();

        // stop enemy movement
        float initialSpeed = gameObject.GetComponent<EnemyMovement>().speed;
        gameObject.GetComponent<EnemyMovement>().speed = 0;

        // stop attacking if enemy is attacking
        if (gameObject.GetComponent<EnemyAttack>().attackCorutine != null)
        {
            StopCoroutine(gameObject.GetComponent<EnemyAttack>().attackCorutine);
        }

        if (currentHealth <= 0)
        {
            StartCoroutine(Die());
            yield break;
        }

        // wait for enemy to recover
        yield return new WaitForSeconds(recoverTime);
        // resume enemy action
        gameObject.GetComponent<EnemyMovement>().speed = initialSpeed;
        gameObject.GetComponent<EnemyAttack>().canAttack = true;
    }

    IEnumerator Die()
    {
        // play some animation
        animator.SetTrigger("Die");
        // Die time
        yield return new WaitForSeconds(2);
        gameObject.GetComponent<DropItem>().Drop(transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
