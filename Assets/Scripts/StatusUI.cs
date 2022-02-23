using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StatusUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        updateText();
    }
    public void updateText()
    {
        GameObject.Find("StatusUI/MoneyText").GetComponent<Text>().text = "Money: " + GM.money.ToString();
        GameObject.Find("StatusUI/AtkText").GetComponent<Text>().text = "Atk: " + GM.atk.ToString();
        GameObject.Find("StatusUI/HPText").GetComponent<Text>().text = "HP: " + GM.currHP.ToString() + "/" + GM.maxHP.ToString();
        GameObject.Find("StatusUI/BombText").GetComponent<Text>().text = "Bomb: " + GM.bomb.ToString() + "/3";
        GameObject.Find("StatusUI/LevelText").GetComponent<Text>().text = "Level: " + GM.level.ToString();
    }
}
