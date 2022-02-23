using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopUI : MonoBehaviour
{
    private bool ShopOn = false;
    private string noMoney = "You don't have enough money!";
    //public Transform PauseUI;
    public Transform ShopCanvas;
    void Start()
    {
        //PauseUI.gameObject.SetActive(false);
        ShopCanvas.gameObject.SetActive(true);
        //GameObject.Find("Canvas/HP").GetComponent<Text>().text = "HP: " + GM.currHP.ToString() + "/" + GM.maxHP.ToString();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) { Pause(); }
        //if (Input.GetKeyDown("z")) { Shop(); }
        updateText();
    }

    public void Pause()
    {
        //if (Paused) { Paused = false; PauseUI.gameObject.SetActive(false); Time.timeScale = 1f;  }
        //else { Paused = true; PauseUI.gameObject.SetActive(true); Time.timeScale = 0f; }
    }

    public void Shop()
    {
        if (ShopOn)
        {
            ShopOn = false;
            ShopCanvas.gameObject.SetActive(false);
        } else
        {
            ShopOn = true;
            ShopCanvas.gameObject.SetActive(true);
        }
    }
    public void buyAtk()
    {
        if (GM.money < GM.atkCost) {
            GameObject.Find("Shop/NoMoney").GetComponent<Text>().text = noMoney;
        } else
        {
            GameObject.Find("Shop/NoMoney").GetComponent<Text>().text = " ";
            GM.money -= GM.atkCost;
            GM.atkCost++;
            GM.atk++;
        }
    }
    public void buyMaxHP()
    {
        if (GM.money < GM.maxHPCost)
        {
            GameObject.Find("Shop/NoMoney").GetComponent<Text>().text = noMoney;
        }
        else
        {
            GameObject.Find("Shop/NoMoney").GetComponent<Text>().text = " ";
            GM.money -= GM.maxHPCost;
            GM.maxHPCost++;
            GM.maxHP += 10;
            GM.currHP += 10;
        }
    }
    public void buyHeal()
    {
        if (GM.money < GM.healCost)
        {
            GameObject.Find("Shop/NoMoney").GetComponent<Text>().text = noMoney;
        } else if (GM.currHP >= GM.maxHP)
        {
            GameObject.Find("Shop/NoMoney").GetComponent<Text>().text = "Your HP is full!";
        }
        else
        {
            GameObject.Find("Shop/NoMoney").GetComponent<Text>().text = " ";
            GM.money -= GM.healCost;
            GM.currHP += (GM.maxHP / 3);
            if (GM.currHP > GM.maxHP)
            {
                GM.currHP = GM.maxHP;
            }
        }
    }
    public void buyBomb()
    {
        if (GM.money < GM.bombCost)
        {
            GameObject.Find("Shop/NoMoney").GetComponent<Text>().text = noMoney;
        }
        else if (GM.bomb >= 3)
        {
            GameObject.Find("Shop/NoMoney").GetComponent<Text>().text = "Your can't hold more bomb!";
        }
        else
        {
            GameObject.Find("Shop/NoMoney").GetComponent<Text>().text = " ";
            GM.money -= GM.bombCost;
            GM.bomb++;
        }
    }

    public void updateText()
    {
        /*
        GameObject.Find("Canvas/Money").GetComponent<Text>().text = "Money: " + GM.money.ToString();
        GameObject.Find("Canvas/Atk").GetComponent<Text>().text = "Atk: " + GM.atk.ToString();
        GameObject.Find("Canvas/HP").GetComponent<Text>().text = "HP: " + GM.currHP.ToString()+"/"+ GM.maxHP.ToString();
        GameObject.Find("Canvas/Bomb").GetComponent<Text>().text = "Bomb: " + GM.bomb.ToString()+"/3";
        */
        //if (ShopOn)
        //{
        GameObject.Find("Shop/MoneyText").GetComponent<Text>().text = "Money: " + GM.money.ToString();
        GameObject.Find("Shop/AtkText").GetComponent<Text>().text = "Atk: " + GM.atk.ToString();
        GameObject.Find("Shop/HPText").GetComponent<Text>().text = "HP: " + GM.currHP.ToString() + "/" + GM.maxHP.ToString();
        GameObject.Find("Shop/BombText").GetComponent<Text>().text = "Bomb: " + GM.bomb.ToString() + "/3";
        GameObject.Find("Shop/LevelText").GetComponent<Text>().text = "Level: " + GM.level.ToString();

        GameObject.Find("Shop/Atk/Cost").GetComponent<Text>().text = "cost: " + GM.atkCost.ToString();
        GameObject.Find("Shop/MaxHP/Cost").GetComponent<Text>().text = "cost: " + GM.maxHPCost.ToString();
        GameObject.Find("Shop/Heal/Cost").GetComponent<Text>().text = "cost: " + GM.healCost.ToString();
        GameObject.Find("Shop/Bomb/Cost").GetComponent<Text>().text = "cost: " + GM.bombCost.ToString();
        //}
    }

    public void nextStage()
    {
        GM.level++;
        SceneManager.LoadScene("Dungeon");
    }
}
