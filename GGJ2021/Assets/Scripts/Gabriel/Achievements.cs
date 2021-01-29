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
    private float achTimeOne = 300, achTimeTwo = 600;

    // Achievements: Collecting 5 memories, Collecting 8 memories, Collecting All memories, Complete game in X minutes, Complete game in x minutes, Complete game without making a mistake...
    [HideInInspector]
    public bool[] trophies = { false, false, false, false, false, false };

    // Memories unlocked
    private int curMemories;
    [HideInInspector]
    public bool[] memories = { false, false, false, false, false, false, false, false, false, false };
    [SerializeField]
    private int memoryGoalOne = 5, memoryGoalTwo = 8;

    private void Update()
    {
        if (playing && !paused)
        {
            time += Time.deltaTime;
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
