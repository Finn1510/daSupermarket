using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{

    [Header("References")]
    [SerializeField] GameObject[] Slots;
    
    [Space]

    [SerializeField] GameObject RedFood;
    [SerializeField] GameObject GreenFood;
    [SerializeField] GameObject BlueFood;
    [SerializeField] GameObject YellowFood;

    [Header("Parameters")]
    [SerializeField] private float RestockTickRate = 5f;

    GameObject[] Food;


    // Start is called before the first frame update
    void Start()
    {
        Food = new GameObject[Slots.Length];
        Debug.Log(Slots.Length);

        

        InvokeRepeating("CheckFoodStock", 0f, RestockTickRate);
    }

    

    
    
    void CheckFoodStock()
    {
        int CurrentIndex2 = 0;

        foreach (GameObject Slot in Slots)
        {
            
            Debug.Log("Slot " + CurrentIndex2 + " Visability: " + Slots[CurrentIndex2].GetComponent<Renderer>().isVisible);

            if (Food[CurrentIndex2] == null && Slots[CurrentIndex2].GetComponent<Renderer>().isVisible == false)
            {
                RestockFood(CurrentIndex2, Slot);
            }
            
            CurrentIndex2 = CurrentIndex2 + 1;
        }

        
    }
    
    
    void RestockFood(int Index, GameObject Slot)
    {

        float RandomChoice = Random.Range(1, 4);

        if (RandomChoice == 1)
        {
            GameObject ourFood = Instantiate(RedFood, Slot.transform.position, Quaternion.identity);
            Food[Index] = ourFood;
        }
        if (RandomChoice == 2)
        {
            GameObject ourFood = Instantiate(GreenFood, Slot.transform.position, Quaternion.identity);
            Food[Index] = ourFood;
        }
        if (RandomChoice == 3)
        {
            GameObject ourFood = Instantiate(BlueFood, Slot.transform.position, Quaternion.identity);
            Food[Index] = ourFood;
        }
        if (RandomChoice == 4)
        {
            GameObject ourFood = Instantiate(YellowFood, Slot.transform.position, Quaternion.identity);
            Food[Index] = ourFood;
        }

    }
}
