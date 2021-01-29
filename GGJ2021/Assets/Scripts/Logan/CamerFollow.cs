using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerFollow : MonoBehaviour
{
    public Vector3[] CameraPosition;

    public void EnterTrigger(int room)
    {
           transform.position = CameraPosition[room];
    }

    void Start()
    {
        transform.position = CameraPosition[0];
    }
}
