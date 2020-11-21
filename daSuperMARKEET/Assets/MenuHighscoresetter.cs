using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuHighscoresetter : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Text ScoreText;

    float highscore;
    
    // Start is called before the first frame update
    void Start()
    {
        highscore = ES3.Load<float>("highscore");
        ScoreText.text = "Highscore: " + highscore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
