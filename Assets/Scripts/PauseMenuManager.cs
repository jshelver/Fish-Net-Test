using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GameObject pauseMenu;

    void Update()
    {
        pauseMenu.SetActive(InputManager.gameIsPaused);
    }

    public void ResumeGame()
    {
        InputManager.gameIsPaused = false;
        InputManager.SwitchActionMap(InputManager.playerControls.Player);
    }

    public void ReturnToMenu()
    {
        // SceneManager.LoadScene(0);
    }
}
