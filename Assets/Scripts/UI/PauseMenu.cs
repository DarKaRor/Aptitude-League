using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu instance;
    public bool paused = false;
    [SerializeField] GameObject panel;
    [SerializeField] GameObject settings;
    AudioClip open;
    AudioClip close;

    private void Awake()
    {
        if (instance != null && instance != this) Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            DontDestroyOnLoad(settings);
        }
    }

    void Start(){
        open = Methods.loadAudio("Close Pause");
        close = Methods.loadAudio("Open Pause");
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
        GameManager.sharedInstance.PlayEffect(paused ? open : close);
        if(!paused) settings.SetActive(false);
        panel.SetActive(paused);
    }

    void ToggleOptions(){
        GameManager.sharedInstance.ToggleGameObject(settings);
        panel.SetActive(!settings.activeSelf);
    }

    public void GoToMenu()
    {
        SetPause(false);
        GameManager.sharedInstance.BackToMenu();
    }

    public void Continue() => SetPause(false);

    public void SetPause(bool pause){
        paused = pause;
        Time.timeScale = pause ? 0 : 1f;
        panel.SetActive(paused);
        settings.SetActive(false);
    }

    public void Restart(){
        SetPause(false);
        GameManager.sharedInstance.Restart();
    }

    public void Options() => ToggleOptions();
}
