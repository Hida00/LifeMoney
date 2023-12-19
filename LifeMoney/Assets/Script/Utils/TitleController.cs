using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class TitleController : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI test;

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
        test.text = Application.dataPath + "\n" + Application.streamingAssetsPath;
    }
    public void ClickOption()
	{
        option.SetReturnScene(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("Option");
	}
}
