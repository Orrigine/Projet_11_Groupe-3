using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine.LowLevel;


public class MoveTo : MonoBehaviour
{

    public Transform goal;

    private bool _playerSpotted;

    private void Awake()
    {
        _playerSpotted = false;
    }

    private void OnEnable()
    {
        EnemyVision.OnEnemyDetect += PlayerSpotted;
        EnemyVision.OnEnemyLost += PlayerLost;
    }

    private void OnDisable()
    {
        EnemyVision.OnEnemyDetect -= PlayerSpotted;
        EnemyVision.OnEnemyLost -= PlayerLost;
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

    void PlayerSpotted()
    {
        _playerSpotted = true;
    }

    void PlayerLost()
    {
        _playerSpotted = false;
    }
}