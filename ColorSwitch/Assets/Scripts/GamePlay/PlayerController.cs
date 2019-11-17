using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{

    [SerializeField] private float jumpForce;
    [SerializeField] private float rotateSpeed;
    private Rigidbody2D playerRb;
    // Use this for initialization
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            playerRb.velocity = Vector2.up * jumpForce;
        }
        transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {

    }
    void SetRandomColor()
    {

    }
}
