using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScenceController : MonoBehaviour
{

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip pressButton;
    public void PlayButton()
    {
        audioSource.PlayOneShot(pressButton);
        SceneManager.LoadScene("GamePlay");
    }
}
