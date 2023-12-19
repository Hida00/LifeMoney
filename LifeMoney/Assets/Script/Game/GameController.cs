using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    GameObject LoadingPanel;
    [SerializeField]
    LoadingController loadingController;

    Play status;

    void Start()
    {
        status = Play.LOADING;
        LoadingPanel.SetActive(false);
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
		{
            if(status == Play.LOADING)
                status = Play.PLAYING;
            else
                status = Play.LOADING;
		}
        switch(status)
        {
            case Play.LOADING:
                if(LoadingPanel.activeSelf == false)
                    LoadingPanel.SetActive(true);
                    loadingController.isLoading = true;
                break;
            case Play.PLAYING:
                if(LoadingPanel.activeSelf == true)
                    LoadingPanel.SetActive(false);
                break;
            case Play.PAUSING:
                if(LoadingPanel.activeSelf == true)
                    LoadingPanel.SetActive(false);
                break;
            default:
                if(LoadingPanel.activeSelf == true)
                    LoadingPanel.SetActive(false);
                break;
        }
    }
}
enum Play
{
    LOADING,
    PLAYING,
    PAUSING
}