using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AI;

public class EnemyVision : MonoBehaviour
{
    public static event Action<bool> OnEnemyDetect;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            //gameObject.GetComponentInParent<Enemy>().enabled = false;
            gameObject.GetComponentInParent<NavMeshAgent>().speed = 4;
            OnEnemyDetect?.Invoke(true);
            Enemy._isSpotted = true;
            Debug.Log("Found you");
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            //gameObject.GetComponentInParent<Enemy>().enabled = true;
            gameObject.GetComponentInParent<NavMeshAgent>().speed = 2;
            OnEnemyDetect?.Invoke(false);
            Enemy._isSpotted = false; 
        }
    }
}
