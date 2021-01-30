using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Memories : MonoBehaviour
{
    private Achievements achievements;
    private CharacterController player;

    public int memoriesToWin = 6;

    // Memories: 
    private bool[] unlockedMemory = { false, false, false, false, false, false, false, false, false, false };
    private bool looking = false;
    private int curMemory, progress;

    private void Awake()
    {
        achievements = FindObjectOfType<Achievements>();
        player = FindObjectOfType<CharacterController>();
    }

    public void OnMemoryCollect(int id)
    {
        if (!looking && !unlockedMemory[id])
        {
            looking = true;
            curMemory = id;
            player.interactionObj.GetComponent<CircleCollider2D>().enabled = false;
            player.canInteract = false;
            player.interactionTT.SetActive(false);
        }
        else
        {
            if (id == curMemory)
            {
                looking = false;
                unlockedMemory[id] = true;
                progress++;
                player.interactionObj.GetComponent<CircleCollider2D>().enabled = false;
                player.canInteract = false;
                player.interactionTT.SetActive(false);
                achievements.GotMemory(id);
            }
            else
            {
                // Hint stuff goes here
                Debug.Log("Tried Grabbing wrong memory");
                player.canInteract = false;
                player.interactionTT.SetActive(false);
            }
        }

        if (progress >= memoriesToWin)
        {
            // Call win function here
        }
    }
}
