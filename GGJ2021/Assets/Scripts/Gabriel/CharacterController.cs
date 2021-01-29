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
    private GameObject interaction;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        normalSpeed = speed;
        interaction.SetActive(false);
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
            interaction.SetActive(false);

            // Call any interaction function from other scripts in here.

        }
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.deltaTime);
    }

    public void SetInteract(bool can)
    {
        canInteract = can;

        if (canInteract)
        {
            interaction.SetActive(true);
        }
    }
}
