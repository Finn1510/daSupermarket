using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTextSetter : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject Cart;
    Text ScoreText;

    void Start()
    {
        Cart = GameObject.FindGameObjectWithTag("ShoppingCart");
        ScoreText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = "Score: "+ Cart.GetComponent<CartController>().Score;        
    }
}
