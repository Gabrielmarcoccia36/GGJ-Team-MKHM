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

    // Interaction

    private bool canInteract = false;
    [SerializeField]
    private GameObject interactionTT;
    private GameObject interactionObj;

    // Achievement and memories stuff

    private Memories memories;
    private int memoryID;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        memories = FindObjectOfType<Memories>();
    }

    private void Start()
    {
        normalSpeed = speed;
        interactionTT.SetActive(false);
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

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
            canInteract = false;
            interactionTT.SetActive(false);

            // Call any interaction function from other scripts in here.
            interactionObj.GetComponent<CircleCollider2D>().enabled = false;
            memories.OnMemoryCollect(memoryID);
        }
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.deltaTime);
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
