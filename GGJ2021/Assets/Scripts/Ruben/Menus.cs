using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour
{
    public static bool active = false;
    public static bool open = false;
    public static bool open1 = false;

    public bool[] gotAchievement = new bool[6];

    [SerializeField]
    Image[] achFrame = new Image[6];

    [SerializeField]
    Sprite[] imageholder = new Sprite[6];
    [SerializeField]
    Sprite[] imageEarned = new Sprite[6];

    Sprite[,] frameHolder;

    Achievements achivements;

    public GameObject sMenu;
    public GameObject tMenu;
    public GameObject pMenu;
    public GameObject tuMenu;


    private void Awake()
    {
        achivements = FindObjectOfType<Achievements>();
        for (int i = 0; i < 6; i++)
        {
            gotAchievement[i] = achivements.GetUnlockedAchievement(i); 
        }
    }
    private void Start()
    {
        frameHolder = new Sprite[6, 2] { { imageholder[0], imageEarned[0] }, { imageholder[1], imageEarned[1] }, { imageholder[2], imageEarned[2] }, { imageholder[3], imageEarned[3] }, { imageholder[4], imageEarned[4] }, { imageholder[5], imageEarned[5] }, };
        for (int i = 0; i < 6; i++)
        {
            if (gotAchievement[i])
            {
                achFrame[i].sprite = frameHolder[i, 1];
            }
            else
            {
                achFrame[i].sprite = frameHolder[i, 0];

            }
        }
    }

    public void LoadLevel(string levelName)
    {
        Time.timeScale = 1f;
        AudioManager.instance.StopAllSounds();
        SceneManager.LoadScene(1);
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
        if (open == false)
        {
            tMenu.SetActive(true);
            open = true;
            pMenu.SetActive(false);
        }
        else
        {
            tMenu.SetActive(false);
            open = false;
            pMenu.SetActive(true);
        }
    }

    public void TutorialMenu()
    {
        if (open1 == false)
        {
            tuMenu.SetActive(true);
            open1 = true;
            pMenu.SetActive(false);
        }
        else
        {
            tuMenu.SetActive(false);
            open1 = false;
            pMenu.SetActive(true);
        }
    }

}
