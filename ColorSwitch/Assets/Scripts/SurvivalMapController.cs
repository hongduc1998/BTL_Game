using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class SurvivalMapController : MonoBehaviour
{

	public static SurvivalMapController Instance;

	[SerializeField] private Text scoreTextInGame;

	[SerializeField] private Text scoreTextEndGame;
	[SerializeField] private Text highScoreText;
	
	[SerializeField] private GameObject[] obstaclePrefab;
	[SerializeField] private GameObject starPrefab;
	[SerializeField] private GameObject colorChangerPrefab;
	
	[SerializeField] private Transform obstacleTransform;
	
	private GameObject currentColorChanger;
	
	[SerializeField] private GameObject losePanel;
	

//	private Transform currentTransform;
	// Use this for initialization
	private void Start ()
	{
		if (Instance==null)
		{
			Instance = this;
		}
		
		highScoreText.text = GameManeger.Instance.GetHighScore().ToString();
		
		int randomValue = Random.Range(0, obstaclePrefab.Length);
		GetGameObject(obstaclePrefab[randomValue]);
		GetGameObject(starPrefab);
		
		GameObject colorChanger = GetGameObject(colorChangerPrefab);
		colorChanger.transform.position=new Vector3(0,2.5f,0);
		currentColorChanger = colorChanger;

	}

	private void Update()
	{
		scoreTextInGame.text = PlayerController.Instance.star.ToString();
		scoreTextEndGame.text = PlayerController.Instance.star.ToString();
		highScoreText.text = GameManeger.Instance.GetHighScore().ToString();
	}

	public void InstantiateObstacle()
	{
		Vector3 newPosition = transform.position;
		newPosition.y += 5;
		transform.position = newPosition;
		
		int randomValue = Random.Range(0, obstaclePrefab.Length);
		GameObject obstacle = GetGameObject(obstaclePrefab[randomValue]);
		obstacle.transform.position = transform.position;
		
		GameObject star = GetGameObject(starPrefab);
		star.transform.position = transform.position;
	}

	public void InstantiateColorChanger()
	{
		Vector3 newPosition = currentColorChanger.transform.position;
		newPosition.y += 5f;
		currentColorChanger.transform.position = newPosition;
		
		GameObject colorChanger = GetGameObject(colorChangerPrefab);
		colorChanger.transform.position = currentColorChanger.transform.position;
		currentColorChanger = colorChanger;
	}

	public GameObject GetGameObject(GameObject instantiateGo)
	{
		GameObject newGo = (GameObject) Instantiate(instantiateGo);
		newGo.transform.SetParent(obstacleTransform);
		return newGo;
	}
	
	public void PauseButton()
	{
		PlayerController.Instance.allowRotate = false;
	}

	public void ResumeButton()
	{
		PlayerController.Instance.allowRotate = true;
	}

	public void Lose()
	{
		losePanel.SetActive(true);
	}

	public void Restart()
	{
		SceneManager.LoadScene("Survival");
	}

	public void Home()
	{
		SceneManager.LoadScene("MainMenu");
	}
	
}
