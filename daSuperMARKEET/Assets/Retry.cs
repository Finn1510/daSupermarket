using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(AudioSource))]
public class Retry : MonoBehaviour
{
    
    AudioSource audio;
    
    [Header("Parameters")]
    [SerializeField] private int LevelSceneIndex = 1;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public void RetryGame()
    {
        audio.Play();
        SceneManager.LoadSceneAsync(LevelSceneIndex);
    }
}
