using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

	[SerializeField] private Transform target;
	
	private void Update()
	{
//		Vector3 currentPosition = transform.position;
		if (target.position.y > transform.position.y)
		{
			transform.position = new Vector3(transform.position.x, target.position.y, transform.position.z);
		}
	}
}
