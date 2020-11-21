using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CartController : MonoBehaviour
{
    Rigidbody Cartrigid;
    [Header("References")]
    [SerializeField] Text Scoretext;
    [SerializeField] Text Highscoretext;
    [SerializeField] Text ColorObjectivetext;
    [SerializeField] private GameObject GameOverCanvas;
    [SerializeField] private GameObject ScoreParticle;
    [SerializeField] private CinemachineImpulseSource Impulze;
    AudioSource CollectSoundAudio;
    [Space]

    [Header("Parameters")]
    [SerializeField] private float CartSpeed = 2;
    [SerializeField] private float turnspeed = 5; 
    [SerializeField] private float ScoreSpeedDividor = 20;
    [SerializeField] private float ColorSwitchInterval = 20;

    string currentColor;


    
    public float Score;
    float highScore;
    float oldScore;
    bool Playerdiedbool = false;
    Transform foodPoint;
    bool dieDelay = true;
    bool mobileVersion = false;

    Vector3 velocity = Vector3.zero;
    Vector3 steervelocity;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DieDelay());
        
        Cartrigid = GetComponent<Rigidbody>();
        CollectSoundAudio = GetComponent<AudioSource>();
        foodPoint = GameObject.FindGameObjectWithTag("FoodPoint").transform;
        
        GameOverCanvas.SetActive(false);
        
        
        InvokeRepeating("switchColorObjective", 0f, ColorSwitchInterval);

        Impulze = GetComponent<CinemachineImpulseSource>();
        
        if (ES3.KeyExists("highscore"))
        {
            highScore = ES3.Load<float>("highscore");
        }
        else
        {
            highScore = 0; 
        } 

        if (Application.isMobilePlatform == true)
        {
            mobileVersion = true;
            Application.targetFrameRate = 60;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Score > oldScore)
        {
            CartSpeed = CartSpeed + (Score / ScoreSpeedDividor);
            Scoretext.text = "Score: " + Score.ToString();
            
            oldScore = Score; 
            
        }

        if (Cartrigid.velocity.magnitude < 1 && Playerdiedbool == false && dieDelay == false)
        {
            Debug.Log("Player Died");
            Playerdiedbool = true;
            GameObject[] gos = (GameObject[])GameObject.FindObjectsOfType(typeof(GameObject));
            foreach (GameObject go in gos)
            {
                
                go.SendMessage("Playerdied");
            }
        } 


    } 

    IEnumerator DieDelay()
    {
        yield return new WaitForSeconds(2);
        dieDelay = false;
    }

    private void FixedUpdate()
    {
        
        if(Playerdiedbool == false)
        {
            velocity = transform.forward * CartSpeed;
            Cartrigid.velocity = velocity;

            if(mobileVersion == true)
            {
                steervelocity = new Vector3(0, Input.acceleration.x * turnspeed, 0);
            }
            else
            {
                steervelocity = new Vector3(0, Input.GetAxis("Horizontal") * turnspeed, 0);
            }
            
            
            Quaternion deltaSteel = Quaternion.Euler(steervelocity * Time.deltaTime);
            Cartrigid.MoveRotation(deltaSteel * Cartrigid.rotation);

        }

    } 

    void ScorePoints(Hashtable tempstorage)
    {
        
        if(Playerdiedbool == false && (string)tempstorage["foodColor"] == currentColor)
        {
            //Score Callculation
            Score = Score + (float)tempstorage["Scoreamount"];
            
            //Particle
            Instantiate(ScoreParticle, foodPoint.position, Quaternion.identity);

            //Screenshake 
            Impulze.GenerateImpulse();

            //Collect Sound 
            CollectSoundAudio.Play();
        }
        
    } 

    void Playerdied()
    {
        velocity = Vector3.zero;
        if (Score > highScore)
        {
            highScore = Score;
            ES3.Save<float>("highscore", highScore);
        }
        Highscoretext.text = "Highscore: " + highScore;

        GameOverCanvas.SetActive(true);
    } 

    void switchColorObjective()
    {
        int randomChoice = UnityEngine.Random.Range(1, 4);

        if (randomChoice == 1)
        {
            currentColor = "red";
            ColorObjectivetext.text = "collect red food";
            ColorObjectivetext.color = Color.red;
        } 
        if(randomChoice == 2)
        {
            currentColor = "green";
            ColorObjectivetext.text = "collect green food";
            ColorObjectivetext.color = Color.green;
        }
        if (randomChoice == 3)
        {
            currentColor = "blue";
            ColorObjectivetext.text = "collect blue food";
            ColorObjectivetext.color = Color.blue;
        }
        if (randomChoice == 4)
        {
            currentColor = "yellow";
            ColorObjectivetext.text = "collect yellow food";
            ColorObjectivetext.color = Color.yellow;
        }
    }
}
