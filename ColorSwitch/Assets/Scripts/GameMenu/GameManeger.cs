using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManeger : MonoBehaviour
{

	public static GameManeger Instance;

	private void OnEnable()
	{
		if (Instance!=null)
		{
			Destroy(gameObject);
		}
		else
		{
			Instance = this;
			DontDestroyOnLoad(this.gameObject);
		}
	}

	public void SetHighScore(int score)
	{
		PlayerPrefs.SetInt("HighScore",score);
	}

	public int GetHighScore()
	{
		return PlayerPrefs.GetInt("HighScore");
	}
}
