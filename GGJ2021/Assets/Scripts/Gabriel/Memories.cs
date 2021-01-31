using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Memories : MonoBehaviour
{
    private Achievements achievements;
    private CharacterController player;

    public int memoriesToWin = 6;
    [SerializeField]
    private int memoryTime = 1;
    private float timer = 0;
    private bool gotMemory = false;

    private float timerTwo = 0;
    private bool startTimerTwo = false;

    // Memories: 1)Beach  2)Christmas  3)Camping  4)Riding Bike  5)Pets  6)Graduation  7)First Job  8)Stadium  9)Traveling  10)Birthday
    public bool[] unlockedMemory = { false, false, false, false, false, false, false, false, false, false };
    private bool looking = false;
    public int curMemory, progress;

    private GameObject frame;
    public Animator frameAnim;
    [SerializeField]
    private Sprite[] frameImg;
    public GameObject ToolTip;

    // Sound Stuff
    public string[] gameSongs = new string[] { "", "0m", "1m", "2m", "3m", "4m", "5m", "6m", "7m", "8m", "9m" };
    public string[] sfx = new string[] { "beach", "christmas", "camping", "riding", "pets", "graduation", "first", "stadium", "traveling", "birthday" };

    // Hint stuff
    private Inventory hints;

    private void Awake()
    {
        achievements = FindObjectOfType<Achievements>();
        player = FindObjectOfType<CharacterController>();
        frame = GetComponentInChildren<Animator>().gameObject;
        frameAnim = frame.GetComponent<Animator>();
    }

    public void OnMemoryCollect(int id)
    {
        if (!looking && !unlockedMemory[id])
        {
            looking = true;
            curMemory = id;
            player.interactionObj.GetComponent<CircleCollider2D>().enabled = false;
            player.canInteract = false;
            player.interactionTT.SetActive(false);
        }
        else
        {
            if (id == curMemory)
            {
                looking = false;
                unlockedMemory[id] = true;
                progress++;

                player.interactionObj.GetComponent<CircleCollider2D>().enabled = false;
                player.canInteract = false;
                player.interactionTT.SetActive(false);

                achievements.GotMemory(id);

                frame.GetComponent<SpriteRenderer>().sprite = frameImg[id];
                frameAnim.SetBool("memoryOn", true);
                frameAnim.SetBool("memoryOff", false);
                gotMemory = true;
                player.canMove = false;
                AudioManager.instance.StopAllSounds();
                AudioManager.instance.Play(sfx[id]);
            }
            else
            {

                // Hint stuff goes here
                Debug.Log("Tried Grabbing wrong memory");


                player.canInteract = false;
                player.interactionTT.SetActive(false);
            }
        }

        if (progress == 10)
        {
            player.win = true;
        }
        if (progress >= memoriesToWin)
        {
            // Call win function here
            player.canWin = true;
        }
    }

    private void Update()
    {
        if (gotMemory)
        {
            timer += Time.deltaTime;
            if (timer >= memoryTime)
            {
                gotMemory = false;
                timer = 0;
                startTimerTwo = true;

                frameAnim.SetBool("memoryOn", false);
                // Either allow the player to move or remove memory from screen and then allow player to move.
                //player.canMove = true;
            }
        }
        if (startTimerTwo)
        {
            timerTwo += Time.deltaTime;
            if (timerTwo >= 2)
            {
                player.memoryInteract = true;
                startTimerTwo = false;
                ToolTip.SetActive(true);
            }
        }
    }
}
