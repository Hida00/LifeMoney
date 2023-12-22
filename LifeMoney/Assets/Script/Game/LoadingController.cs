using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using TMPro;
using System.Net.Http;
using System.IO;
using System.Threading.Tasks;
using UnityEngine.Networking;

public class LoadingController : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI[] LOADINGS;

    public GameController gameController;

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
        //StartCoroutine(TextLoad());
        //StartCoroutine(GetAPI());
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

    IEnumerator TextLoad()
    {
        string result;
        string filepath = Application.streamingAssetsPath + "/data.csv";
        if(filepath.Contains("://") || filepath.Contains(":///"))
        {
            UnityWebRequest request = UnityWebRequest.Get(filepath);
            // データをJSONで受け取りたいのでHeaderをセット
            request.SetRequestHeader("Content-Type", "application/json");
            yield return request.SendWebRequest();
            result = request.downloadHandler.text;
            //WWW www = new WWW (filepath);
            //yield return www;
            //var result = www.text;
            Debug.Log(result);

        }
        else
        {
            result = File.ReadAllText(filepath);
            //Debug.Log(result);

            Debug.Log((result.Split('\n').Length));
        }

        int count = 0;
        foreach(var line in result.Split('\n'))
        {
            var temp = new float[line.Length];
            var lines = line.Split(',');
            int index = 0;
            if(count == 6)
                break;
            Debug.Log($"{lines.Length}");
            foreach(var item in lines)
			{
                temp[index++] = float.Parse(item);
			}
            gameController.GraphDatas.data_trans[count++] = temp;
		}
    }
    IEnumerator GetAPI()
    {
        string result;
        string url = "http://www.gaitameonline.com/rateaj/getrate";

        using(UnityWebRequest request = UnityWebRequest.Get(url))
        {
            yield return request.SendWebRequest();
            result = request.downloadHandler.text;
            Debug.Log(result);
        }

        var json = JsonUtility.FromJson<ExchangeJson>(result);

        for(int i = 0; i < 6; i++)
        {
            gameController.GraphDatas.exDatasHigh[i] = float.Parse(json.quotes[i].high);
            gameController.GraphDatas.exDatasOpen[i] = float.Parse(json.quotes[i].open);
        }
    }
}
