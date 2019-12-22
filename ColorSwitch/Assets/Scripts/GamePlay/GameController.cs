using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

	public static GameController Instance;

	[SerializeField] private PlayerController playerController;
	[SerializeField] private Transform mainCam;

	[SerializeField] private GameObject[] levelPrefab;
	[SerializeField] private Transform levelTransform;
	[SerializeField] private int currentLevel;

	[SerializeField] private GameObject winPanel;
	[SerializeField] private GameObject losePanel;

	private GameObject level;

	public bool isPausing;
	
	private void Start () {
		if (Instance==null)
		{
			Instance = this;
		}

		currentLevel = 0;
//		GetLevel(levelPrefab[currentLevel]);

	}

	public GameObject GetLevel(GameObject levelGo)
	{
		level = (GameObject) Instantiate(levelGo, levelTransform.position,Quaternion.identity,levelTransform);
		return level;
	}
	
	//-------------

	public void PauseButton()
	{
		isPausing = true;
	}

	public void ResumeButton()
	{
		isPausing = false;
	}

	public void Win()
	{
		winPanel.SetActive(true);
		losePanel.SetActive(false);
		Destroy(level);
		currentLevel += 1;
		isPausing = true;
	}

	public void Lose()
	{
		losePanel.SetActive(true);
		winPanel.SetActive(false);
		Destroy(level);
		isPausing = true;
	}

	public void Next()
	{
		winPanel.SetActive(false);
		isPausing = false;
		GetLevel(levelPrefab[currentLevel]);
		ResetPlayerPosition();
		ResetCam();
	}

	public void Restart()
	{
		losePanel.SetActive(false);
		isPausing = false;
		GetLevel(levelPrefab[currentLevel]);
		ResetPlayerPosition();
		ResetCam();
	}

	private void ResetPlayerPosition()
	{
		playerController.ResetPlayer();
	}

	private void ResetCam()
	{
		mainCam.position = new Vector3(0, 0, -10);
	}
	
}
