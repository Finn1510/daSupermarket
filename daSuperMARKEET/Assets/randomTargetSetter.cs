using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomTargetSetter : MonoBehaviour
{
    Vector3 randomPos;

    [SerializeField] float PosDuration = 4;
    [SerializeField] GameObject Cart;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("setRandomPos", 0f, PosDuration);
    }

    // Update is called once per frame
    void Update()
    {
           
    } 

    void setRandomPos()
    {
        randomPos = new Vector3(Random.Range(-15, 182), 0, Random.Range(-100, 93));
        transform.position = randomPos;
        Cart.SendMessage("setNewTarget");

    }

    void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "Regal")
        {
            setRandomPos();
        }
    }
}
