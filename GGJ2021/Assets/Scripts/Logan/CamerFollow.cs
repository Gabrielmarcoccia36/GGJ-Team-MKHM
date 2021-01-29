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


    // Start is called before the first frame update
    void Start()
    {
        transform.position = CameraPosition[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
