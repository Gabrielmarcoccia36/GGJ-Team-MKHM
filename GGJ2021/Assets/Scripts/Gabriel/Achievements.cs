using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achievements : MonoBehaviour
{
    public bool playing;
    public bool won;
    public bool paused;

    public float score = 0f;
    public float highScore = 0f;
    public float time = 0f;

    // Times to receive achievements
    [SerializeField]
    private float achTimeOne = 600, achTimeTwo = 300;

    // Achievements: Collecting 5 memories, Collecting 8 memories, Collecting All memories, Complete game in (5) minutes, Complete game in (10) minutes, Complete game without making a mistake...
    //[HideInInspector]
    public bool[] trophies = { false, false, false, false, false, false };

    // Memories unlocked
    private int curMemories;
    [HideInInspector]
    public bool[] memories = { false, false, false, false, false, false, false, false, false, false };

    public int memoryGoalOne { get; private set; }
    public int memoryGoalTwo { get; private set; }

    private void Start()
    {
        memoryGoalOne = 5;
        memoryGoalTwo = 8;
    }

    private void Update()
    {
        if (playing && !paused)
        {
            time += Time.deltaTime;
        }

        // Temporary as this will be replaced with a method that will be called when the game is beaten.
        if (won)
        {
            playing = false;
            paused = false;
            
            if (time <= achTimeTwo)
            {
                trophies[3] = true;
                trophies[4] = true;
            }
            else if (time <= achTimeOne)
            {
                trophies[3] = true;
            }
        }
    }

    public void GotMemory(int memory)
    {
        if (!memories[memory])
        {
            memories[memory] = true;
            curMemories++;
        }

        if (curMemories >= memoryGoalOne)
        {
            trophies[0] = true;

            if (curMemories >= memoryGoalTwo)
            {
                trophies[1] = true;

                if (curMemories == 10)
                {
                    trophies[2] = true;
                }
            }
        }
    }
}
