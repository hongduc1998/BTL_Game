using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{

    private Rigidbody2D playerRb;
    [SerializeField] private float jumpForce;
    [SerializeField] private float rotateSpeed;
    private string currentColor;
    [SerializeField] private SpriteRenderer playerSr;
    [SerializeField] private Color cyanColor;
    [SerializeField] private Color yellowColor;
    [SerializeField] private Color magentaColor;
    [SerializeField] private Color pinkColor;
    int temp;
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        SetRandomColor();
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
        int index = Random.Range(0, 4);
        while (temp == index)
        {
            index = Random.Range(0, 4);
        }
        index = temp;
        switch (index)
        {
            case 0:
                currentColor = "Cyan";
                playerSr.color = cyanColor;
                break;
            case 1:
                currentColor = "Yellow";
                playerSr.color = yellowColor;
                break;
            case 2:
                currentColor = "Magenta";
                playerSr.color = magentaColor;
                break;
            case 3:
                currentColor = "Pink";
                playerSr.color = pinkColor;
                break;
        }
    }
}
