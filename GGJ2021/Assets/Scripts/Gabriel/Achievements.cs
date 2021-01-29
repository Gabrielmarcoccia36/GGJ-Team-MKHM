using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achievements : MonoBehaviour
{
    private bool playing;
    private bool won;
    private bool pause;

    private float score = 0f;
    private float time = 0f;

    // Times to receive achievements
    [SerializeField]
    private float achTimeOne, achTimeTwo;

    // Achievements: Collecting 5 memories, Collecting 8 memories, Collecting All memories, Complete game in X minutes, Complete game in x minutes, Complete game without making a mistake...
    private bool[] trophies = { false, false, false, false, false, false };

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
