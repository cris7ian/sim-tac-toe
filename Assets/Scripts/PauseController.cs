using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pauseMenu;
    private bool isPaused = false;
    void OnMenu()
    {
        pauseMenu.SetActive(isPaused = !isPaused);
    }
}
