using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

	public static GameController Instance;

//	[SerializeField] private PlayerController playerController;
	[SerializeField] private Transform mainCam;

	[SerializeField] private GameObject[] levelPrefab;
	[SerializeField] private Transform levelTransform;
	[SerializeField] private int currentLevel;

	[SerializeField] private GameObject winPanel;
	[SerializeField] private GameObject losePanel;

	private GameObject level;

	private void Start () {
		if (Instance==null)
		{
			Instance = this;
		}

		currentLevel = 0;
		GetLevel(levelPrefab[currentLevel]);

	}

	public GameObject GetLevel(GameObject levelGo)
	{
		level = (GameObject) Instantiate(levelGo, levelTransform.position,Quaternion.identity,levelTransform);
		return level;
	}
	
	//-------------

	public void PauseButton()
	{
		PlayerController.Instance.allowRotate = false;
//		ObstacleController.Instance.allowRotate = false;
	}

	public void ResumeButton()
	{
		PlayerController.Instance.allowRotate = true;
//		ObstacleController.Instance.allowRotate = true;
	}

	public void Win()
	{
		winPanel.SetActive(true);
		losePanel.SetActive(false);
		Destroy(level);
		currentLevel += 1;
	}

	public void Lose()
	{
		losePanel.SetActive(true);
		winPanel.SetActive(false);
		Destroy(level);
	}

	public void Next()
	{
		winPanel.SetActive(false);
		GetLevel(levelPrefab[currentLevel]);
		Reset();
	}

	public void RestartWhenLose()
	{
		losePanel.SetActive(false);
		GetLevel(levelPrefab[currentLevel]);
		Reset();
	}

	public void RestartWhenWin()
	{
		winPanel.SetActive(false);
		currentLevel -= 1;
		GetLevel(levelPrefab[currentLevel]);
		Reset();
	}

	private void Reset()
	{
		PlayerController.Instance.ResetPlayer();
		PlayerController.Instance.allowRotate = true;
		mainCam.position = new Vector3(0, 0, -10);
	}
	
}
