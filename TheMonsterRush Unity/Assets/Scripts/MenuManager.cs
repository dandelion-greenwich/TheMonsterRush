using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    public GameObject MenuPage;
    public GameObject AudioSettingsPanel;
    public GameObject VideoSettingsPanel;
    public GameObject KeybindingsPanel;
    //public GameObject GameOverPanel;

    private void Start()
    {
        MenuPage.SetActive(true);
        VideoSettingsPanel.SetActive(false);
        AudioSettingsPanel.SetActive(false);
        KeybindingsPanel.SetActive(false);
        //GameOverPanel.SetActive(false);
    }

    public void OnMainMenuPress()
    {
        MenuPage.SetActive(true);
        VideoSettingsPanel.SetActive(false);
        AudioSettingsPanel.SetActive(false);
        KeybindingsPanel.SetActive(false);
    }

    public void OnResumePress()
    {
        Time.timeScale = 1;
        canvas.enabled = false;
    }

    public void OnStartGamePress()
    {
        SceneManager.LoadScene("GameScene");
        Debug.Log("Do monster");
    }

    public void OnSettingsPress()
    {
        MenuPage.SetActive(false);
        VideoSettingsPanel.SetActive(true);
    }

    public void OnPauseMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OnVideoPress() 
    {
        MenuPage.SetActive(false);
        VideoSettingsPanel.SetActive(true);
        AudioSettingsPanel.SetActive(false);
        KeybindingsPanel.SetActive(false);
    }
    public void OnAudioPress()
    {
        MenuPage.SetActive(false);
        VideoSettingsPanel.SetActive(false);
        AudioSettingsPanel.SetActive(true);
        KeybindingsPanel.SetActive(false);
    }

    public void OnKeybindsPress()
    {
        MenuPage.SetActive(false);
        VideoSettingsPanel.SetActive(false);
        AudioSettingsPanel.SetActive(false);
        KeybindingsPanel.SetActive(true);
    }

    public void OnQuitPress()
    {
        Application.Quit();
        Debug.Log("Don't monster");
    }
}
