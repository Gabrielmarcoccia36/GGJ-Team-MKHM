using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTrigger : MonoBehaviour
{
    public int RoomNumber;
    public Rigidbody2D rb;
    private CamerFollow camerFollow;

    void Awake()
    {
        camerFollow = FindObjectOfType<CamerFollow>();
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<CharacterController>())
        {
         camerFollow.EnterTrigger(RoomNumber);

        }
    }
 
}
