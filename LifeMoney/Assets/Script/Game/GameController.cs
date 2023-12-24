using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;

public class GameController : MonoBehaviour
{
    [SerializeField]
    GameObject LoadingPanel;
    [SerializeField]
    GameObject GamePanel;
    [SerializeField]
    GameObject PausePanel;
    [SerializeField]
    GameObject HomePanel;
    [SerializeField]
    GameObject FXPanel;

    [SerializeField]
    LoadingController loadingController;
    [SerializeField]
    FXRateController fxRateController;

    [SerializeField]
    GameObject element;
    [SerializeField]
    Transform ScrollContent;

    [SerializeField]
    TextMeshProUGUI FXText;
    [SerializeField]
    TextMeshProUGUI VirtualText;

    public GraphData GraphDatas { get; set; }
    public PlayData PlayDatas { get; set; }

    public Option Options { get; set; }

    bool isPlaying = false;
    bool isPaused = false;

    public State status;
    public PlayState playState;

    void Start()
    {
        status = State.LOADING;
        playState = PlayState.HOME;
        PanelActive();
        loadingController.gameController = this;

        GraphDatas = new GraphData();
        PlayDatas = new PlayData();
    }
    void Update()
    {
        PanelActive();
        switch(status)
        {
            case State.LOADING:
                break;
            case State.PLAYING:
                GamePlay();
                break;
            case State.PAUSING:
                break;
            default:
                break;
        }
    }
    void GamePlay()
	{
        GamePanelActive();
        switch(playState)
        {
            case PlayState.HOME:
                break;
            case PlayState.FX:
                if(!fxRateController.isGenerate)
                    fxRateController.GenerateElement();
                break;
            case PlayState.VIRTUAL:
                break;
            default:
                break;
        }
	}
    void PanelActive()
	{
        LoadingPanel.SetActive(status == State.LOADING);
        GamePanel.SetActive(status == State.PLAYING);
        PausePanel.SetActive(status == State.PAUSING);

        loadingController.isLoading = ( status == State.LOADING );
        isPlaying = ( status == State.PLAYING );
        isPaused = ( status == State.PAUSING );
    }
    void GamePanelActive()
	{
        HomePanel.SetActive(playState == PlayState.HOME);
        FXPanel.SetActive(playState == PlayState.FX);
	}
    public void ClickFX()
	{
        playState = PlayState.FX;

	}
    public void ClickVirtual()
	{
        playState = PlayState.VIRTUAL;
	}
    public void EnterFX() => FXText.text = "<u>" + FXText.text + "</u>";
    public void EnterVirtual() => VirtualText.text = "<u>" + VirtualText.text + "</u>";
    public void ExitFX() => FXText.text = FXText.text.Substring(3, FXText.text.Length - 7);
    public void ExitVirtual() => VirtualText.text = VirtualText.text.Substring(3, VirtualText.text.Length - 7);
}
public enum State
{
    LOADING,
    PLAYING,
    PAUSING,
    OPTION
}
public enum PlayState
{
    HOME,
    FX,
    VIRTUAL
}