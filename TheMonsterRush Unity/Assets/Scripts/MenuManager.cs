using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject MenuPage;
    public GameObject AudioSettingsPanel;
    public GameObject VideoSettingsPanel;
    public GameObject KeybindingsPanel;

    private void Start()
    {
        MenuPage.SetActive(true);
        VideoSettingsPanel.SetActive(false);
        AudioSettingsPanel.SetActive(false);
        KeybindingsPanel.SetActive(false);
    }

    public void OnMainMenuPress()
    {
        MenuPage.SetActive(true);
        VideoSettingsPanel.SetActive(false);
        AudioSettingsPanel.SetActive(false);
        KeybindingsPanel.SetActive(false);
    }

    public void OnStartGamePress()
    {
        Debug.Log("Do monster");
    }

    public void OnSettingsPress()
    {
        MenuPage.SetActive(false);
        VideoSettingsPanel.SetActive(true);
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
