using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu instance;
    public bool paused = false;
    [SerializeField] GameObject panel;

    private void Awake()
    {
        if (instance != null && instance != this) Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Update()
    {
        if (!GameManager.sharedInstance.inGame) return;
        if (Input.GetKeyDown(KeyCode.Escape)) TogglePause();
    }

    void TogglePause()
    {
        Time.timeScale = Time.timeScale == 0 ? 1f : 0;
        paused = !paused;
        GameManager.sharedInstance.ToggleGameObject(panel);
    }

    public void GoToMenu()
    {
        TogglePause();
        GameManager.sharedInstance.BackToMenu();
    }

    public void Continue() => TogglePause();
}
