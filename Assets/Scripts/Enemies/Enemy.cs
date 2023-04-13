using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using System;

public class Enemy : MonoBehaviour
{
    public static bool _isSpotted;
    public static int _enemyLayer;

    public static event Action OnHit;

    public NavMeshAgent Agent;
    public GameObject[] Pointers;

    private int _pointerIndex;

    private void Awake()
    {
        _pointerIndex = 0;
        _isSpotted = false;
        _enemyLayer = gameObject.layer;
    }

    private void OnEnable()
    {
        EnemyPointers.OnNextPointer += NextPointer;
    }

    private void OnDisable()
    {
        EnemyPointers.OnNextPointer -= NextPointer;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == Player._playerLayer)
        {
            Destroy(gameObject);
            OnHit?.Invoke();
        }
    }
    void Update()
    {
        if (!_isSpotted && Pointers.Length >= 2)
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
