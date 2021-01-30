using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    private CharacterController player;
    [SerializeField]
    private bool memoryInteractable = false;
    [SerializeField]
    private int memoryID = 0;

    private void Awake()
    {
        player = FindObjectOfType<CharacterController>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        player.SetInteract(true, gameObject, memoryInteractable, memoryID);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        player.SetInteract(false, gameObject, memoryInteractable, memoryID);
    }
}
