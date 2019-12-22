using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{

    [SerializeField] private float speed;
    public bool allowRotate;

    private void Start()
    {
//        if (Instance==null)
//        {
//            Instance = this;
//        }
//        allowRotate = true;
    }

    private void Update()
    {
        allowRotate = PlayerController.Instance.allowRotate;
        
        Rotate(allowRotate);
    }

    public void Rotate(bool allow)
    {
        if (allow)
        {
            transform.Rotate(0, 0, speed * Time.deltaTime);
        }
    }
}
