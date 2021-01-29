using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Memories : MonoBehaviour
{
    private Achievements achievements;

    public int memoriesToWin = 6;

    private bool[] unlockedMemory = { false, false, false, false, false, false, false, false, false, false };
    private bool looking = false;
    private int curMemory, progress;

    private void Awake()
    {
        achievements = FindObjectOfType<Achievements>();
    }

    public void OnMemoryCollect(int id)
    {
        if (!looking && !unlockedMemory[id])
        {
            looking = true;
            curMemory = id;
        }
        else
        {
            if (id == curMemory)
            {
                looking = false;
                unlockedMemory[id] = true;
                progress++;
                achievements.GotMemory(id);
            }
            else
            {
                // Hint stuff goes here
            }
        }

        if (progress >= memoriesToWin)
        {
            // Call win function here
        }
    }
}
