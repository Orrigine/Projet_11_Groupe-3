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
    [SerializeField] Material _fireEffect;
    [SerializeField] Material _frostEffect;
    GameObject child;

    float burn;
    private void Awake()
    {
        _pointerIndex = 0;
        _isSpotted = false;
        _enemyLayer = gameObject.layer;
    }

    private void Start()
    {
        child = gameObject.transform.GetChild(0).gameObject;
        burn = 0;
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
        if (collision.gameObject.layer == 8)
        {
            if(collision.gameObject.name == "Fireball(Clone)")
                child.GetComponent<Renderer>().material = _fireEffect;
            if (collision.gameObject.name == "Frozen Spike(Clone)")
            {
                child.GetComponent<Renderer>().material = _frostEffect;
                Destroy(gameObject,3);
            }
        }
    }

    void Update()
    {
        if (!_isSpotted && Pointers.Length >= 2)
        {
            Agent.SetDestination(Pointers[_pointerIndex].transform.position);
        }
        if (child.GetComponent<Renderer>().material.name == "Fire Disolve (Instance)")
        {
            if(burn <= 1.1)
            {
                burn += 0.0025f;
            }
            else
            {
                Destroy(gameObject);
            }
            child.GetComponent<Renderer>().material.SetFloat("_Burn", burn);
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
