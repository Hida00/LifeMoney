using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class TitleController : MonoBehaviour
{
    [SerializeField]
    GameObject TitlePanel;
    [SerializeField]
    GameObject OptionPanel;
    [SerializeField]
    GameObject SaveText;
    [SerializeField]
    GameObject COIN;

    [SerializeField]
    AudioSource MusicAudioSource;
    [SerializeField]
    AudioSource SEAudioSource;

    [SerializeField]
    Slider MusicSlider;
    [SerializeField]
    Slider SESlider;

    [SerializeField]
    Image MusicVolumeImage;
    [SerializeField]
    Image SEVolumeImage;

    [SerializeField]
    Sprite[] volumeSprite;

    [SerializeField]
    AudioClip[] SE;

    public static Option OPTION;

    string playerName = "";

    int insCount = 0;

    void Start()
    {
        Application.targetFrameRate = 60;

        OPTION = new Option();
        MusicSlider.onValueChanged.AddListener(MusicSliderChange);
        SESlider.onValueChanged.AddListener(SESliderChange);
    }
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
		{
            SEAudioSource.clip = SE[0];
            SEAudioSource.Play();
		}
        if(insCount >= 30)
        {
            var force = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));
            var qua = new Vector3(Random.Range(-90.0f, 90.0f), Random.Range(-90.0f, 90.0f), Random.Range(-90.0f, 90.0f));
            var obj = Instantiate(COIN, new Vector3(0, 10, 100), Quaternion.Euler(qua));
            obj.GetComponent<Rigidbody>().AddForce(force * 10f, ForceMode.Impulse);
        }
        insCount++;
    }
    public void ClickGameStart()
	{
        SceneManager.LoadScene("Game");
	}
    public void ClickPanelChange()
	{
        TitlePanel.SetActive(!TitlePanel.activeSelf);
        OptionPanel.SetActive(!OptionPanel.activeSelf);
	}
    public void ClickSave()
	{
        OPTION.SetOption(
            MusicSlider.value,
            SESlider.value
        );
        MusicAudioSource.volume = MusicSlider.value / 10f;
        SEAudioSource.volume = SESlider.value / 10f;
        SaveText.SetActive(false);
    }
    public void MusicSliderChange(float value)
    {
        SaveText.SetActive(true);
        MusicVolumeImage.sprite = volumeSprite[(int)( value / 3 )];
    }
    public void SESliderChange(float value)
    {
        SaveText.SetActive(true);
        SEVolumeImage.sprite = volumeSprite[(int)( value / 3 )];
    }
}
