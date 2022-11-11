using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Doozy.Runtime.UIManager.Containers;

public class UI_InGameController : MonoBehaviour
{
    public UIContainer pauseMenu;
    public CinemachineVirtualCamera _cmInGame;
    public CinemachineVirtualCamera _cmPauseGame;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pauseMenu.gameObject.activeInHierarchy)
                PauseGame();
            else 
                ResumeGame();
        }
    }

    public void PauseGame()
    {
        pauseMenu.Show();
        Time.timeScale = 0;
        _cmInGame.gameObject.SetActive(false);
        _cmPauseGame.gameObject.SetActive(true);
    }

    public void ResumeGame()
    {
        pauseMenu.Hide();
        Time.timeScale = 1;
        _cmInGame.gameObject.SetActive(true);
        _cmPauseGame.gameObject.SetActive(false);
    }
}
