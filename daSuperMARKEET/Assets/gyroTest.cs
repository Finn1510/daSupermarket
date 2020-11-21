using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gyroTest : MonoBehaviour
{
    bool mobileVersion = false;
    Text debugText;
    
    // Start is called before the first frame update
    void Start()
    {
        debugText = GetComponent<Text>();
        if (Application.isMobilePlatform == true)
        {
            mobileVersion = true;
        } 
        else
        {
            debugText.text = "";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(mobileVersion == true)
        {
            
           
            debugText.text = Input.acceleration.x.ToString(); 

        }    
    }
}
