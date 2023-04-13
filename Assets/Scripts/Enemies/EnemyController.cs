using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;


public class MoveTo : MonoBehaviour
{

    public Transform goal;

    public static bool _playerSpotted;

    private void Awake()
    {
        _playerSpotted = false;
    }

    private void Update()
    {
        if (_playerSpotted)
        {
            MoveEnemyToPlayer();
        }   
    }
    void MoveEnemyToPlayer()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.position;
    }
}