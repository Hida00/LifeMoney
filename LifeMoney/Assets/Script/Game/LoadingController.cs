using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadingController : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI[] LOADINGS;

    float[] positionArray = new float[10]
    {
        -500f, -400f, -300f, -100f, 0f,
        100f, 200f, 300f, 400f, 500f
    };
    float[] moveArray = new float[9]
    {
        0f, 30f, 40f, 45f, 50f, 45f, 40f, 30f, 0f
    };

    int frameCount = 0;
    int arrayCount = 0;
    int moveCount  = 0;

    public bool isLoading = false;

    void Start()
    {
        Application.targetFrameRate = 60;   
    }

    void Update()
    {
        if(isLoading)
        {
            LOADINGS[arrayCount].rectTransform.anchoredPosition = Vector2.right * positionArray[arrayCount] + Vector2.up * moveArray[moveCount];
            moveCount++;
            if(moveCount >= 9)
            {
                moveCount = 0;
                arrayCount++;
                if(arrayCount >= 10)
                {
                    arrayCount = 0;
                }
            }
        }
    }

    int LoadingData()
	{
        string path = Application.streamingAssetsPath;

        return 0;
	}
}
