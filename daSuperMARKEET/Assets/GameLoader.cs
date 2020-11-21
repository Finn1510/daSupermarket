using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class GameLoader : MonoBehaviour
{
    [SerializeField] private int GameSceneindex = 1;
    [SerializeField] private Slider loadingbar;

    AudioSource audio;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public void LoadGame()
    {
        audio.Play();
        StartCoroutine(LoadGameAsync());
    } 

    IEnumerator LoadGameAsync()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(GameSceneindex); 
        while (!operation.isDone)
        {
            loadingbar.value = Mathf.Clamp01(operation.progress / .9f);
            Debug.Log(operation.progress);
            yield return null;
        }
    }
}
