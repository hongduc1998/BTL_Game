using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    
    [SerializeField] private float speed;

    private void Update()
    {
        Rotate(!GameController.Instance.isPausing);
    }

    public void Rotate(bool allow)
    {
        if (allow)
        {
            transform.Rotate(0, 0, speed * Time.deltaTime);
        }
    }
}
