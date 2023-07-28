using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PoliceAi : MonoBehaviour
{
    [SerializeField]
    NavMeshAgent agent;

    

    public Transform target;


    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        if (agent == null)
        {
            agent = GetComponent<NavMeshAgent>();
            agent.SetDestination(target.position);
        }
    }

    void Update()
    {
       agent.SetDestination(target.position);
    }
    public void DriveToCorner(Transform t)
    {
        target.position = t.position;
    }
}
