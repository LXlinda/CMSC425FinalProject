using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItem : MonoBehaviour
{
    private AudioSource pickupSound;
    void Start() {
        pickupSound = GetComponent<AudioSource>();
    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            // Add money or add heart
            if(gameObject.tag == "Money") { GM.money += 10; }
            if(gameObject.tag == "Heart") { GM.currHP += 10; if (GM.currHP > GM.maxHP) { GM.currHP = GM.maxHP; } }
            // Play pick up sound
            pickupSound.Play();

            // Destory
            Destroy(gameObject, 0.2f);
        }
    }
}
