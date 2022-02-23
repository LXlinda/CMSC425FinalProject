using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyBGM : MonoBehaviour
{
    static bool created = false;
   void Awake() 
   {
       if (!created)
       {
           DontDestroyOnLoad(transform.gameObject);
           created = true;
       }
       else
       {
           Destroy(gameObject);
       }
       
   }
}
