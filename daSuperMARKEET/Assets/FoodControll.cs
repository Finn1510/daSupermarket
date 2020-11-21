using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SocialPlatforms.Impl;
using System;

public class FoodControll : MonoBehaviour
{
    Transform foodpoint;
    GameObject Cart;
    Rigidbody foodRigid;

    Vector3 CurrentFoodPointPos;
    bool isClicked = false;
    bool Playerdiedbool = false;
    [SerializeField] float foodVelocity = 10;
    [SerializeField] float ScorePoints = 1;
    [SerializeField] string Color;
    

    // Start is called before the first frame update
    void Start()
    {
        foodpoint = GameObject.FindGameObjectWithTag("FoodPoint").transform;
        Cart = GameObject.FindGameObjectWithTag("ShoppingCart");
        foodRigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        CurrentFoodPointPos = foodpoint.position;

       

        if (isClicked == true)
        {
            transform.LookAt(foodpoint);
            
            foodRigid.velocity = transform.forward * foodVelocity;
            
            if (Vector3.Distance(transform.position, foodpoint.position) < 1)
            {
                Hashtable tempstorage = new Hashtable();
                tempstorage.Add("Scoreamount",ScorePoints);
                tempstorage.Add("foodColor", Color);
                Cart.SendMessage("ScorePoints", tempstorage);
                Destroy(this.gameObject);
            }
        }
        
    }


    private void FixedUpdate()
    {
        if (isClicked == true)
        {
            foodVelocity = foodVelocity + 2; 
            
        }
    }

    private void OnMouseDown()
    {
        if (Playerdiedbool == false)
        {
            isClicked = true;
        }
        
    } 

    void Playerdied()
    {
        Playerdiedbool = true;
    }

    
}
