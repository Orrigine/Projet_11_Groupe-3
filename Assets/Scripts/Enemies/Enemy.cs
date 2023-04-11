using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;


public class Enemy : MonoBehaviour
{
    
    public NavMeshAgent Agent;
    public GameObject[] Pointers;
    public static int _pointerIndex;

    private void Awake()
    {
        _pointerIndex = 0;
    }

    void Update()
    {
        Agent.SetDestination(Pointers[_pointerIndex].transform.position);
    }
}