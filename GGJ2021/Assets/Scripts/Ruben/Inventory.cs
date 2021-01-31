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

    // Hinting System
    public Sprite[] activeItems;
    public Sprite[] inactiveItems;
    public Sprite asd;
    public Sprite[,,] hintItems;

    private void Awake()
    {
        curMemory = FindObjectOfType<Memories>();
    }

    private void Start()
    {
         hintItems = new Sprite[10, 2, 2] { { { inactiveItems[0], activeItems[0] }, { inactiveItems[1], activeItems[1] } }, { { inactiveItems[2], activeItems[2] }, { inactiveItems[3], activeItems[3] } }, { { inactiveItems[4], activeItems[4] }, { inactiveItems[5], activeItems[5] } }, { { inactiveItems[6], activeItems[6] }, { inactiveItems[7], activeItems[7] } }, { { inactiveItems[8], activeItems[8] }, { inactiveItems[9], activeItems[9] } }, { { inactiveItems[10], activeItems[10] }, { inactiveItems[11], activeItems[11] } }, { { inactiveItems[12], activeItems[12] }, { inactiveItems[13], activeItems[13] } }, { { inactiveItems[14], activeItems[14] }, { inactiveItems[15], activeItems[15] } }, { { inactiveItems[16], activeItems[16] }, { inactiveItems[17], activeItems[17] } }, { { inactiveItems[18], activeItems[18] }, { inactiveItems[19], activeItems[19] } } };
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
