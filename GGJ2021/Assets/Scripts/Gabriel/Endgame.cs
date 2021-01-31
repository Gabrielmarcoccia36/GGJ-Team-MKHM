using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Endgame : MonoBehaviour
{
    private Achievements achievements;
    private CharacterController player;
    private Animator anim;

    private void Awake()
    {
        achievements = FindObjectOfType<Achievements>();
        anim = GetComponent<Animator>();
        player = FindObjectOfType<CharacterController>();
    }
    private void Start()
    {
        achievements.SetPlaying(true);
        AudioManager.instance.Play("0m");
    }

    private void Update()
    {
        if (player.win)
        {
            anim.SetBool("won", true);
            achievements.won = true;
        }
        if(player.canWin && Input.GetKeyDown(KeyCode.Space) && !player.win)
        {
            anim.SetBool("won", true);
            achievements.won = true;
        }
    }

    public void EndOfCredits()
    {
        SceneManager.LoadScene(0);
    }
}
