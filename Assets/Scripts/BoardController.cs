using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardController : MonoBehaviour
{
    public static TicTacToe game = new TicTacToe();
    public GameObject confetti;
    private AudioSource victorySound;
    private AudioSource backgroundMusic;
    private bool won = false;
    // Start is called before the first frame update
    void Start()
    {
        victorySound = GetComponents<AudioSource>()[0];
        backgroundMusic = GetComponents<AudioSource>()[1];
        confetti.GetComponent<ParticleSystem>().Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (game.Winner() != '-' && !won)
        {
            confetti.GetComponent<ParticleSystem>().Play();
            victorySound.Play();
            StartCoroutine(FadeOut(backgroundMusic, 1));
            Debug.Log("Winner is " + game.Winner());
            won = true;
        }
    }

    private IEnumerator FadeOut(AudioSource audioSource, float fadeDuration)
    {
        float startVolume = audioSource.volume;

        while (audioSource.volume > 0)
        {
            // Reduce the volume over time
            audioSource.volume -= startVolume * Time.deltaTime / fadeDuration;
            
            yield return null; // Wait for the next frame
        }

        // Stop the audio and reset the volume to its original level
        audioSource.Stop();
        audioSource.volume = startVolume;
    }
}
