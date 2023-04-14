using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPointers : MonoBehaviour
{
    public static event Action OnNextPointer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == Enemy._enemyLayer)
        {
            OnNextPointer?.Invoke();
        }
        //Debug.Log(Enemy._pointerIndex);
    }
}
