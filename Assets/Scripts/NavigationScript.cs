using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavigationScript : MonoBehaviour
{

    [SerializeField] Transform[] Positions;

    NavMeshAgent Agent;

    [SerializeField] float DistanceThreshold;


    private int PositionIndex = 0;    
    

    // Start is called before the first frame update
    void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Agent.remainingDistance <= DistanceThreshold)
        {
            Agent.destination = Positions[PositionIndex].position;

            if (PositionIndex + 1 > Positions.Length - 1) PositionIndex = 0;
            else PositionIndex++;        
        }
    }
}
