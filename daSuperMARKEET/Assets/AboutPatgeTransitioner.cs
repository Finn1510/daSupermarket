using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AboutPatgeTransitioner : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Animator PageAnim;

    bool PageDown = false;
    
   

    public void AboutButtonClick()
    {
        if(PageDown == false)
        {
            PageDown = true;
            PageAnim.SetBool("PageDown", true);

        } 
        else if (PageDown == true)
        {
            PageDown = false;
            PageAnim.SetBool("PageDown", false);
        }
    }
}
