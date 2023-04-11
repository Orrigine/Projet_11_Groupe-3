using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyVision : MonoBehaviour
{
    public static event Action<bool> OnEnemyDetect;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            gameObject.GetComponentInParent<Enemy>().enabled = false;
            OnEnemyDetect?.Invoke(true);
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            gameObject.GetComponentInParent<Enemy>().enabled = true;
            OnEnemyDetect?.Invoke(false);
        }
    }
}
