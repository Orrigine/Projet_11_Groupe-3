using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AI;

public class EnemyVision : MonoBehaviour
{
    public static event Action OnEnemyDetect;
    public static event Action OnEnemyLost;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == Player._playerLayer)
        {
            //gameObject.GetComponentInParent<Enemy>().enabled = false;
            gameObject.GetComponentInParent<NavMeshAgent>().speed = 4;
            OnEnemyDetect?.Invoke();
            Debug.Log("yio");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == Player._playerLayer)
        {
            //gameObject.GetComponentInParent<Enemy>().enabled = true;
            gameObject.GetComponentInParent<NavMeshAgent>().speed = 2;
            OnEnemyLost?.Invoke();
        }
    }
}
