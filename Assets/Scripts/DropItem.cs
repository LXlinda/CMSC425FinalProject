using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    public GameObject Money;
    public GameObject Heart;
    public float moneyDropRate = 0.3f;
    public float heartDropRate = 0.1f;
    private bool moneyDroped;
    public void Drop(Vector3 position, Quaternion rotation)
    {
        moneyDroped = false;
        if (Random.Range(0f, 1f) <= moneyDropRate)
        {
            Instantiate(Money, position, rotation);
            moneyDroped = true;
        }
        if (Random.Range(0f, 1f) <= heartDropRate && !moneyDroped)
        {
            Instantiate(Heart, position, rotation);
        }
    }
}