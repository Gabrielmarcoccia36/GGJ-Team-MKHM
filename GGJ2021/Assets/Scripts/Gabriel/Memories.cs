using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Memories : MonoBehaviour
{
    private Achievements achievements;
    private CharacterController player;

    public int memoriesToWin = 6;
    [SerializeField]
    private int memoryTime = 4;
    private float timer = 0;
    private bool gotMemory = false;

    // Memories: 1)Beach  2)Christmas  3)Camping  4)Riding Bike  5)Pets  6)Graduation  7)First Job  8)Stadium  9)Traveling  10)Birthday
    public bool[] unlockedMemory = { false, false, false, false, false, false, false, false, false, false };
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

                gotMemory = true;
                player.canMove = false;
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

    private void Update()
    {
        if (gotMemory)
        {
            timer += Time.deltaTime;
            if (timer >= memoryTime)
            {
                gotMemory = false;
                timer = 0;

                // Either allow the player to move or remove memory from screen and then allow player to move.
                player.canMove = true;
                Debug.Log("Player can now move");
            }
        }
    }
}
