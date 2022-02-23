// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.SceneManagement;

// public class Pause : MonoBehaviour
// {
//     public static bool GameIsPaused = false;
//     public static bool isMute = false;
//     public GameObject pauseMenuUI;

//     // Update is called once per frame
//     void Update()
//     {
//         if (Input.GetKeyDown(KeyCode.Escape))
//         {
//             if (GameIsPaused)
//             {
//                 Resume();
//             } else
//             {
//                 Pause();
//             }
//         }
//     }

//     public void Resume ()
//     {
//         pauseMenuUI.SetActive(false);
//         Time.timeScale = 1f;
//         GameIsPaused = false;

//     }

//     void Pause ()
//     {
//         pauseMenuUI.SetActive(true);
//         Time.timeScale = 0f;
//         GameIsPuased = true;
//     }

//     public void Menu()
//     {
//         SceneManager.LoadScene("StartMenu");
//     }

//     public void Mute()
//     {
//         if (!isMute)
//         {
//             GameObject.Find("BGM").audio.mute = true;
//             GameObject.Find("Mute").GetComponentInChildren<Text>().text = "Unmute";
//             isMute = true;
//         }

//         if (isMute)
//         {
//             GameObject.Find("BGM").audio.mute = false;
//             GameObject.Find("Mute").GetComponentInChildren<Text>().text = "Mute";
//             isMute = false;
//         }
        
//     }
// }
