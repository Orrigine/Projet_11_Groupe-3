using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;


public class Enemy : MonoBehaviour
{
    public static bool _isSpotted;

    public NavMeshAgent Agent;
    public GameObject[] Pointers;

    private int _pointerIndex;

    private void Awake()
    {
        _pointerIndex = 0;
        _isSpotted = false;
    }

    private void OnEnable()
    {
        EnemyPointers.OnNextPointer += NextPointer;
    }

    private void OnDisable()
    {
        EnemyPointers.OnNextPointer -= NextPointer;
    }
    void Update()
    {
        if (!_isSpotted)
        {
            Agent.SetDestination(Pointers[_pointerIndex].transform.position);
        }
    }

    void NextPointer()
    {
        if (_pointerIndex < Pointers.Length - 1)
        {
            _pointerIndex += 1;
        }
        else if (_pointerIndex >= Pointers.Length - 1)
        {
            _pointerIndex = 0;
        }
    }
}
