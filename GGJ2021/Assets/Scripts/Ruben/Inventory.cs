using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Inventory : MonoBehaviour
{

    public Image memory;
    public Image item;
    public Image item1;

    Memories curMemory;

    public GameObject mMenu;
    [SerializeField]
    GameObject[] check = new GameObject[10];

    public static bool active = false;

    // Hinting System
    public GameObject hintUI;
    public Image curHint;
    public TextMeshProUGUI hintText;

    public bool dissapear;
    private float timer;

    public Sprite[] icons;

    private void Awake()
    {
        curMemory = FindObjectOfType<Memories>();
        /*curHint = hintUI.GetComponentInChildren<Image>();
        hintText = hintUI.GetComponentInChildren<TextMeshProUGUI>();*/
    }

    private void Start()
    {
        if (hintUI != null)
        {
            hintUI.SetActive(false);
        }
    }

    private void Update()
    {
        for (int i = 0; i < check.Length; i++)
        {
            if (curMemory.unlockedMemory[i])
            {
                check[i].SetActive(true);
            }
        }

        if (dissapear)
        {
            timer += Time.deltaTime;
            if(timer >= 1f)
            {
                dissapear = false;
                timer = 0;
                hintUI.SetActive(false);
            }
        }
    }

    public void MemoriesMenu()
    {
        if (active == false)
        {
            mMenu.SetActive(true);
            active = true;
        }
        else
        {
            mMenu.SetActive(false);
            active = false;
        }
    }

    public void OnMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
