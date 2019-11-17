using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenuController : MonoBehaviour
{

    private const string COIN_KEY = "Coin";
    public static GameMenuController instance;
    // Use this for initialization
    void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void SetCoin(int coin)
    {
        PlayerPrefs.SetInt(COIN_KEY, coin);
    }
    public int getCoin()
    {
        return PlayerPrefs.GetInt(COIN_KEY);
    }
}
