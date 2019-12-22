using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{

    public static PlayerController Instance;

    private Rigidbody2D playerRb;
    
    [SerializeField] private float jumpForce;
    [SerializeField] private float rotateSpeed;
    
    private string currentColor;
    
    [SerializeField] private SpriteRenderer playerSr;
    
    [SerializeField] private Color cyanColor;
    [SerializeField] private Color yellowColor;
    [SerializeField] private Color magentaColor;
    [SerializeField] private Color pinkColor;

    public bool allowJump;
    public bool allowRotate;

    private int temp;
    
    private void Start()
    {
        if (Instance==null)
        {
            Instance = this;
        }
        playerRb = GetComponent<Rigidbody2D>();
        SetRandomColor();
        allowRotate = true;
    }

    private void Update()
    {
        Jump();

        if (allowRotate)
        {
           transform.Rotate(0, 0, rotateSpeed * Time.deltaTime); 
        }
        
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("ColorChanger"))
        {
            SetRandomColor();
            Destroy(other.gameObject);
            return;
        }
        
        if (!other.CompareTag(currentColor))
        {
            playerRb.simulated = false;

            allowRotate = false;
            
            GameController.Instance.Lose();
        }

        if (other.CompareTag("FinishLine"))
        {
            playerRb.simulated = false;

            allowRotate = false;
            
            GameController.Instance.Win();
        }

        if (other.CompareTag("LosePoint"))
        {
            playerRb.simulated = false;

            allowRotate = false;
            
            GameController.Instance.Lose();
        }

        if (other.CompareTag("Star"))
        {
            SurvivalMapController.Instance.InstantiateObstacle();
        }
        
    }

    private void Jump()
    {
        if (allowJump)
        {
            allowJump = false;
            playerRb.velocity = Vector2.up * jumpForce;
        }
    }

    public void JumpButton()
    {
        allowJump = true;
    }
    
    private void SetRandomColor()
    {
        int index = Random.Range(0, 4);
//        int temp = index;
        while (temp == index)
        {
            index = Random.Range(0, 4);
        }
//        index = temp;
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

        temp = index;
    }

    public void ResetPlayer()
    {
        transform.position = new Vector3(0, -3, 0);
        playerRb.simulated = true;
        allowJump = false;
    }
    
}
