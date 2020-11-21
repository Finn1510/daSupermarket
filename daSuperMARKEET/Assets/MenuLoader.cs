using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class MenuLoader : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] private int MenuSceneindex = 0;
    
    AudioSource audio;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public void LoadMenu()
    {
        audio.Play();
        SceneManager.LoadSceneAsync(MenuSceneindex);    
    }
}
