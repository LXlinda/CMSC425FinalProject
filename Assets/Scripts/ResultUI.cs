using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultUI : MonoBehaviour
{
    public Transform ResultCanvas;
    void Start()
    {
        ResultCanvas.gameObject.SetActive(true);
        GameObject.Find("ResultCanvas/ScoreText").GetComponent<Text>().text = 
            "Score: " + GM.score.ToString()+"\nMax Level Achieved: "+GM.level.ToString()
            +"\n\nCurrent Stat: \nMaxHP: "+GM.maxHP.ToString()
            +"\nAtk: "+GM.atk.ToString()
            +"\nMoney: "+GM.money.ToString();
    }     
    public void gameRestart()
    {
        SceneManager.LoadScene("StartMenu");
    }
    public void gameExit()
    {

#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
}
