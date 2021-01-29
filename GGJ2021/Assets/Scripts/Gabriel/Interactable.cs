using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    private CharacterController player;

    private void Awake()
    {
        player = FindObjectOfType<CharacterController>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        player.SetInteract(true, gameObject);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        player.SetInteract(false, gameObject);
    }
}
