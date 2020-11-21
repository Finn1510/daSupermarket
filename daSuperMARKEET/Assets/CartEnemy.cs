using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CartEnemy : MonoBehaviour
{
    bool Playerdiedbool = false;
    NavMeshAgent Agent;
    [SerializeField] Transform targetPoint;

    // Start is called before the first frame update
    void Start()
    {
        Agent = GetComponent<NavMeshAgent>();    
        
    }

   

    public void setNewTarget()
    {
        if (Playerdiedbool == false)
        {
            Agent.SetDestination(targetPoint.position);
        }
        
    } 

    void Playerdied()
    {
        Playerdiedbool = true;
        
    }
}
