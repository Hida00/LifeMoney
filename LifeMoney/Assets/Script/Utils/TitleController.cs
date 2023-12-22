using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class TitleController : MonoBehaviour
{
    [SerializeField]
    GameObject TitlePanel;
    [SerializeField]
    GameObject OptionPanel;
    [SerializeField]
    AudioSource audioSource;

    Option option;

    string playerName = "";

    void Start()
    {
        Application.targetFrameRate = 60;
        option = new Option(playerName);
    }
    void Update()
    {

    }
    public void ClickGameStart()
	{
        SceneManager.LoadScene("Game");
	}
    public void ClickPanelChange()
	{
        TitlePanel.SetActive(!TitlePanel.activeSelf);
        OptionPanel.SetActive(!OptionPanel.activeSelf);
	}
    public void ClickSave()
	{

	}
}
