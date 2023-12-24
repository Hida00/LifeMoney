using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerController : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI HomeTimer;
    [SerializeField]
    TextMeshProUGUI FXTimer;
    [SerializeField]
    TextMeshProUGUI VirtualTimer;

    [SerializeField]
    GameController gameController;

    float time = 15 * 60;
    float startTime = 0;

    bool isCounting = false;
    void Start()
    {
        StartTimer();
    }

    void Update()
    {
        if(isCounting)
        {
            time = time - Time.deltaTime;
            switch(gameController.playState)
            {
                case PlayState.HOME:
                    HomeTimer.text = $"{(int)(time / 60)}:{(int)(time % 60)}";
                    break;
                case PlayState.FX:
                    FXTimer.text = $"{(int)( time / 60 )}:{(int)( time % 60 )}";
                    break;
                case PlayState.VIRTUAL:
                    VirtualTimer.text = $"{(int)( time / 60 )}:{(int)( time % 60 )}";
                    break;
                default:
                    break;
            }
        }
    }
    public void StartTimer()
	{
        isCounting = true;
	}
    public void StopTimer()
    { 
        isCounting = false;
    }
}
