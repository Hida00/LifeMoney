using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Option
{
	public static string PlayerName { get; private set; }
	public static float MusicVolume { get; private set; } = 6.0f;
	public static float SEVolume { get; private set; } = 6.0f;

	public static string ReturnScene { get; private set; } = string.Empty;
	public static bool IsLoadSceneName { get; private set; } = false;
	public static string[] SceneNames { get; private set; }

	public Option()
	{
		if(!IsLoadSceneName)
			LoadSceneNames();
	}
	public Option(string name)
	{
		if(PlayerName == string.Empty)
			PlayerName = name;

		if(!IsLoadSceneName)
			LoadSceneNames();
	}
	public Option(string name, float music, float SE)
	{
		if(PlayerName == string.Empty)
			PlayerName = name;
		MusicVolume = music;
		SEVolume = SE;

		if(!IsLoadSceneName)
			LoadSceneNames();
	}
	void LoadSceneNames()
	{
		int count = SceneManager.sceneCount;
		SceneNames = new string[count];
		for(int i = 0; i < count; i++)
		{
			var scene = SceneManager.GetSceneAt(i);
			SceneNames[i] = scene.name;
		}
		if(SceneNames.Length > 0)
			IsLoadSceneName = true;
	}
	public int SetOption(float music, float SE)
	{
		if(music >= 0.0f && music <= 10.0f)
			MusicVolume = music;
		else
			return -1;
		if(SE >= 0.0f && SE <= 10.0f)
			SEVolume = SE;
		else
			return -2;
		return 0;
	}
	public int SetReturnScene(string scene)
	{
		if(Array.IndexOf(SceneNames, scene) >= 0)
			ReturnScene = scene;
		else
			return -1;
		return 0;
	}
	public void RefreshReturnScene()
	{
		ReturnScene = string.Empty;
	}
	public string GetReturnScene() => ReturnScene;

}
