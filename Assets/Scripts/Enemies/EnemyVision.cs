using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AI;

public class EnemyVision : MonoBehaviour
{
    public static event Action OnEnemyDetect;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            //gameObject.GetComponentInParent<Enemy>().enabled = false;
            gameObject.GetComponentInParent<NavMeshAgent>().speed = 4;
            MoveTo._playerSpotted = true;
            Enemy._isSpotted = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            //gameObject.GetComponentInParent<Enemy>().enabled = true;
            gameObject.GetComponentInParent<NavMeshAgent>().speed = 2;
            MoveTo._playerSpotted = false;
            Enemy._isSpotted = false; 
        }
    }
}
