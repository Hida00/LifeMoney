using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FXController : MonoBehaviour
{
    [SerializeField]
    GameObject RateFrame;
    [SerializeField]
    GameObject GraphFrame;
    [SerializeField]
    GameObject TransactionFrame;

    [SerializeField]
    Image RateTag;
    [SerializeField]
    Image GraphTag;
    [SerializeField]
    Image TransactionTag;

    [SerializeField]
    GameController gameController;

    FXTabs tabs;

    void Start()
    {
        tabs = FXTabs.GRAPH;
    }

    void Update()
    {
        if(gameController.playState == PlayState.FX)
		{
            ChangeFrame();
		}
    }
    public void ClickTag(BaseEventData data)
	{
        if(( (PointerEventData)data ).pointerClick.name == "RateTagImage")
        {
            tabs = FXTabs.RATES;
        }
        else if(( (PointerEventData)data ).pointerClick.name == "GraphTagImage")
        {
            tabs = FXTabs.GRAPH;
        }
        else if(( (PointerEventData)data ).pointerClick.name == "TransactionTagImage")
        {
            tabs = FXTabs.TRANSACTION;
        }
	}
    void ChangeFrame()
	{
        RateFrame.SetActive(tabs == FXTabs.RATES);
        GraphFrame.SetActive(tabs == FXTabs.GRAPH);
        TransactionFrame.SetActive(tabs == FXTabs.TRANSACTION);

        var rateColor = RateTag.color;
        var graphColor = RateTag.color;
        var transactionColor = RateTag.color;

        switch(tabs)
        {
            case FXTabs.RATES:
                rateColor.a = 1.0f;
                RateTag.color = rateColor;
                graphColor.a = 0.6f;
                GraphTag.color = graphColor;
                transactionColor.a = 0.6f;
                TransactionTag.color = transactionColor;
                break;
            case FXTabs.GRAPH:
                rateColor.a = 0.6f;
                RateTag.color = rateColor;
                graphColor.a = 1.0f;
                GraphTag.color = graphColor;
                transactionColor.a = 0.6f;
                TransactionTag.color = transactionColor;
                break;
            case FXTabs.TRANSACTION:
                rateColor.a = 0.6f;
                RateTag.color = rateColor;
                graphColor.a = 0.6f;
                GraphTag.color = graphColor;
                transactionColor.a = 1.0f;
                TransactionTag.color = transactionColor;
                break;
            default:
                break;
        }
	}
}
enum FXTabs
{
    RATES,
    GRAPH,
    TRANSACTION,
}