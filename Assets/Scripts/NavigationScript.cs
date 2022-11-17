using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavigationScript : MonoBehaviour
{

    [SerializeField] Transform[] Positions;

    NavMeshAgent Agent;
    GameObject PlayerRef;

    bool HasHitPlayer = false;
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

        if (HasHitPlayer)
        {
            Agent.destination = PlayerRef.transform.position;
            return;
        }

        if (Agent.remainingDistance <= DistanceThreshold)
        {
            Agent.destination = Positions[PositionIndex].position;

            if (PositionIndex + 1 > Positions.Length - 1) PositionIndex = 0;
            else PositionIndex++;        
        }
    }


    private void OnTriggerEnter(Collider collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;

        print("hola");

        PlayerRef = collision.gameObject;
        HasHitPlayer = true;
    }

}
