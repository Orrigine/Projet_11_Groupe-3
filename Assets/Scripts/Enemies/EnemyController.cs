using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;


public class MoveTo : MonoBehaviour
{

    public Transform goal;

    private bool _isSpotted;

    private void Awake()
    {
        _isSpotted = false;
    }
    private void OnEnable()
    {
        EnemyVision.OnEnemyDetect += MoveEnemyToPlayer;
    }
    private void OnDisable()
    {
        EnemyVision.OnEnemyDetect -= MoveEnemyToPlayer;
    }

    private void Update()
    {
        MoveEnemyToPlayer(_isSpotted);
    }
    void MoveEnemyToPlayer(bool temp)
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.position;
    }
}