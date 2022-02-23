using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDamaged : MonoBehaviour
{
    public Animator animator;

    void Start()
    {
        
    }

    public IEnumerator TakeDamage(int damage)
    {
        GM.currHP -= damage;
        // play hurt animation
        animator.SetTrigger("TakeDamage");

        if (GM.currHP <= 0)
        {
            StartCoroutine(Die());
            Die();
        }

        yield return null;
    }

    IEnumerator Die()
    {
        // play some animation
        animator.SetTrigger("Die");
        yield return new WaitForSeconds(2);
        // freeze the game
        SceneManager.LoadScene("ResultScene");
    }
}
