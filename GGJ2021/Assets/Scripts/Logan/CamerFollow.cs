﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerFollow : MonoBehaviour
{
    public Vector3[] CameraPosition;
    public Vector3[] MemoryPosition;
    public GameObject memoryCanvas;

    public void EnterTrigger(int room)
    {
           transform.position = CameraPosition[room];
        memoryCanvas.transform.position = MemoryPosition[room];
    }

    void Start()
    {
        MemoryPosition = CameraPosition;
        for (int i = 0; i < MemoryPosition.Length; i++)
        {
            MemoryPosition[i].z = -5;
        } 
        transform.position = CameraPosition[0];
        memoryCanvas.transform.position = MemoryPosition[0];
    }
}
