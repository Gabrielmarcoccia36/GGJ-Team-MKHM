using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Menus : MonoBehaviour
{
    public static bool active = false;
    public GameObject sMenu;
    public GameObject tMenu;

    void Update()
    {
        
    }

    public void LoadLevel(string levelName)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(levelName);
    }
    public void QuitGame()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    public void ExtraMenu()
    {
        if (active == false)
        {
            sMenu.SetActive(true);
            active = true;
        }
        else
        {
            sMenu.SetActive(false);
            active = false;
        }
    }
    public void TrophyMenu()
    {
        if (active == false)
        {
            tMenu.SetActive(true);
            active = true;
        }
        else
        {
            tMenu.SetActive(false);
            active = false;
        }
    }

}
