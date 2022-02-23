using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class StartUI : MonoBehaviour
{
    public Transform StartCanvas;
    void Start()
    {
        StartCanvas.gameObject.SetActive(true);
    } 
    
    public void gameStart()
    {
        SceneManager.LoadScene("Dungeon");
    }
    public void gameExit()
    {

#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
    public void about()
    {

    }
}
