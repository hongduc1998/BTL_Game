using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class LosePoint : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		RaycastHit2D hit2D = Physics2D.Raycast(transform.position, transform.up);
		if (hit2D)
		{
			if (hit2D.collider.CompareTag("Obstacle"))	
			{
				Destroy(hit2D.collider.gameObject);
			}
		}
	}
}
