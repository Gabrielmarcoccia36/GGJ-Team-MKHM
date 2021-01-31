using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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


    private void Awake()
    {
        curMemory = FindObjectOfType<Memories>();
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
}
