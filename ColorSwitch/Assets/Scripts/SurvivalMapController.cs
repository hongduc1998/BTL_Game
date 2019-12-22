using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class SurvivalMapController : MonoBehaviour
{

	public static SurvivalMapController Instance;
	
	[SerializeField] private GameObject[] obstaclePrefab;
	[SerializeField] private Transform obstacleTransform;
	private GameObject obstacle;
	

//	private Transform currentTransform;
	// Use this for initialization
	private void Start ()
	{
		if (Instance==null)
		{
			Instance = this;
		}
		InstantiateObstacle();
	}

	public void InstantiateObstacle()
	{
		int randomValue = Random.Range(0, obstaclePrefab.Length);
		obstacle = (GameObject) Instantiate(obstaclePrefab[randomValue], obstacleTransform.position,
			Quaternion.identity, obstacleTransform);
	}

	public GameObject GetObstacle(GameObject obstacleGo)
	{
		obstacle = (GameObject) Instantiate(obstacleGo, obstacleTransform.position, Quaternion.identity,
			obstacleTransform);
		return obstacle;
	}
}
