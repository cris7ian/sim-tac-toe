using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardController : MonoBehaviour
{
    public static TicTacToe game = new TicTacToe();
    private AudioSource audioSource;
    private bool won = false;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (game.Winner() != '-' && !won)
        {
            audioSource.Play();
            Debug.Log("Winner is " + game.Winner());
            won = true;
        }
    }
}
