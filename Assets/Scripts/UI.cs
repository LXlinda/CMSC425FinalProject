using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UI : MonoBehaviour
{
    // Start is called before the first frame update
    public float hp = 200, maxHp = 200;
    public int money=100;
    public Font statusFont;
    private float heightChange = 120;
    private float hpUiWidth = 150, hpUiHeight = 15, statusWidth=200, statusHeight=40, hpWidth;
    public Texture2D hpForeGround, hpBackGround;
    void Start()
    {
        maxHp = 200;
        hp = 200;
        money = 100;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnGUI()
    {
        Vector3 worldCoor = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Vector2 screenCoor = Camera.main.WorldToScreenPoint(worldCoor);
        screenCoor = new Vector2(screenCoor.x, Screen.height - screenCoor.y);
        if (hp > maxHp) { hp = maxHp; }
        hpWidth = hp / maxHp*hpUiWidth;
        GUI.DrawTexture(new Rect(screenCoor.x - hpUiWidth / 2, screenCoor.y - hpUiHeight - heightChange, hpUiWidth, hpUiHeight),hpBackGround);
        GUI.DrawTexture(new Rect(screenCoor.x - hpUiWidth / 2, screenCoor.y - hpUiHeight - heightChange, hpWidth, hpUiHeight), hpForeGround);
        GUI.color = Color.black;
        GUI.skin.label.font = statusFont;
        GUI.skin.label.fontSize = 20;
        if (money < 0) { money = 0; }
        GUI.Label(new Rect(30, 30, statusWidth, statusHeight), "Money: "+money.ToString());
    }
}
