using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public Image memory;
    public Image item;
    public Image item1;

    int[] collectibles;

    public GameObject mMenu;
    public static bool active = false;

    private void Update()
    {
        
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
