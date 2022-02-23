using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
     public GameObject enemy;                // The prefab to be spawned.
     public float spawnTime = 6f;            // How long between each spawn.
     private Vector3 spawnPosition;
 
     // Use this for initialization
     void Start () 
     {
         // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
         InvokeRepeating ("Spawn", spawnTime, spawnTime);
     }
 
     void Spawn ()
     {
         spawnPosition = transform.position + transform.forward * Random.Range(0, 2) + transform.right * Random.Range(-4, 4);
         Instantiate(enemy, spawnPosition, Quaternion.identity);
     }
}
