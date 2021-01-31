using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    // Movement

    public float speed = 2.5f;
    private float normalSpeed;
    private bool doit = true;
    private Rigidbody2D rb;
    Vector2 movement;
    private Animator animator;
    public bool canMove = true;

    // Interaction

    public bool canInteract = false;
    public GameObject interactionTT;
    public GameObject interactionObj;

    // Achievement and memories stuff

    private Memories memories;
    private int memoryID;
    public bool memoryInteract = false;
    public bool canWin = false;
    public bool win = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        memories = FindObjectOfType<Memories>();
    }

    private void Start()
    {
        normalSpeed = speed;
        interactionObj = null;
        if(interactionTT != null)
        {
            interactionTT.SetActive(false);
        }
        else
        {
            interactionTT = GetComponentInChildren<Animator>().gameObject;
            interactionTT.SetActive(false);
        }
    }

    void Update()
    {
        if (canMove)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
        }
        else
        {
            movement.x = 0;
            movement.y = 0;
        }
        
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.SqrMagnitude());

        if ((movement.x != 0 && movement.y != 0) && doit)
        {
            doit = false;
            speed = speed / 1.5f;
        }
        else if ((movement.x == 0 && movement.y != 0) && !doit || (movement.x != 0 && movement.y == 0) && !doit)
        {
            doit = true;
            speed = normalSpeed;
        }

        if (canInteract && Input.GetKeyDown(KeyCode.E))
        {
            // Call any interaction function from other scripts in here.
            memories.OnMemoryCollect(memoryID);
        }
        // Interaction with active memory
        else if (memoryInteract && Input.GetKeyDown(KeyCode.E))
        {
            memoryInteract = false;
            memories.ToolTip.SetActive(false);
            memories.frameAnim.SetBool("memoryOff", true);
            canMove = true;
            AudioManager.instance.StopAllSounds();
            AudioManager.instance.Play(memories.gameSongs[memories.progress + 1]);
            if (speed <= 7.5)
            {
                speed += 0.5f;
            }
            else
            {
                speed += 0.1f;
            }
        }
    }
    private void FixedUpdate()
    {
        if (canMove)
        {
            rb.MovePosition(rb.position + movement * speed * Time.deltaTime);
        }
    }

    // This will set the interaction Tooltip active and inactive.
    public void SetInteract(bool can, GameObject obj, bool memoryI, int id)
    {
        canInteract = can;

        if (can && memoryI)
        {
            interactionTT.SetActive(true);
            interactionObj = obj;
            memoryID = id;
        }
        else
        {
            interactionTT.SetActive(false);
            interactionObj = null;
        }
    }
}
