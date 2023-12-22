using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class GameController : MonoBehaviour
{
    [SerializeField]
    GameObject LoadingPanel;
    [SerializeField]
    GameObject GamePanel;
    [SerializeField]
    GameObject PausePanel;
    [SerializeField]
    LoadingController loadingController;

    [SerializeField]
    GameObject element;
    [SerializeField]
    Transform ScrollContent;

    public GraphData GraphDatas { get; set; }

    bool isPlaying = false;
    bool isPaused = false;

    Play status;

    void Start()
    {
        status = Play.PLAYING;
        PanelActive();
        loadingController.gameController = this;

        GraphDatas = new GraphData();
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
		{
            SettingGame();
		}
        PanelActive();
        switch(status)
        {
            case Play.LOADING:
                break;
            case Play.PLAYING:
                break;
            case Play.PAUSING:
                break;
            default:
                break;
        }
    }
    void PanelActive()
	{
        LoadingPanel.SetActive(status == Play.LOADING);
        GamePanel.SetActive(status == Play.PLAYING);
        PausePanel.SetActive(status == Play.PAUSING);

        loadingController.isLoading = ( status == Play.LOADING );
        isPlaying = ( status == Play.PLAYING );
        isPaused = ( status == Play.PAUSING );
    }
    public void SettingGame()
	{

	}
}
enum Play
{
    LOADING,
    PLAYING,
    PAUSING,
    OPTION
}