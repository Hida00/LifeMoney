using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FXRateController : MonoBehaviour
{
    [SerializeField]
    Transform[] Contents;

    [SerializeField]
    GameObject ElementPrefab;

    [SerializeField]
    GameController gameController;

    [SerializeField]
    Sprite[] FlagImages;

    [System.NonSerialized]
    public bool isGenerate = false;

    void Start()
    {

    }

    void Update()
    {

    }
    public void GenerateElement()
    { 
        for(int i = 1; i < 7; i++)
		{
            var obj = Instantiate(ElementPrefab, Contents[i % 2]);
            obj.transform.GetChild(1).GetComponent<Image>().sprite = FlagImages[i];
            obj.transform.GetChild(2).GetComponent<Image>().sprite = FlagImages[0];
            Debug.Log(obj.GetComponent<Element>().PriceBid);

            obj.GetComponent<Element>().PriceBid.text =
                gameController.GraphDatas.exDatasOpen[i - 1].ToString() + gameController.GraphDatas.UnitList[i - 1];
        }
        isGenerate = true;
    }
}
