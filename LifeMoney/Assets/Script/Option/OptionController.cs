using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class OptionController : MonoBehaviour
{
    Option option;

    void Start()
    {
        option = new Option();
    }

    void Update()
    {
    }
    public void ClickSave()
	{

	}
    public void ClickBack()
	{
        var scene = option.GetReturnScene();
        option.RefreshReturnScene();
        SceneManager.LoadScene(scene);
	}
}
