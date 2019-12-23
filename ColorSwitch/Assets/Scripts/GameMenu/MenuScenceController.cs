using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScenceController : MonoBehaviour
{

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip pressButton;
    public void PlayLevelButton()
    {
        audioSource.PlayOneShot(pressButton);
        SceneManager.LoadScene("GamePlay");
    }
    public void PlaySurvivalButton()
    {
        audioSource.PlayOneShot(pressButton);
        SceneManager.LoadScene("Survival");
    }
}
