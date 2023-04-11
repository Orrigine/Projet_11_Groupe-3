using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPointers : MonoBehaviour
{
    public static event Action OnNextPointer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            //Enemy._pointerIndex += 1;
            OnNextPointer?.Invoke();
        }
        //Debug.Log(Enemy._pointerIndex);
    }
}
