using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour
{
    public static int score;
    public static GM instance { get; set; }
    // Player Stat
    public static int currHP=1, maxHP=1, atk=10, money=50, bomb=1;
    // Enemy Stat
    public static float slimeAtkRate, turtleAtkRate, slimeHPRate, turtleHPRate;
    // Other
    public static int level=1;
    public static int atkCost=10, maxHPCost=10, healCost=10, bombCost=10;
}
