using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPointers : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (Enemy._pointerIndex < other.gameObject.GetComponent<Enemy>().Pointers.Length - 1)
        {
            Enemy._pointerIndex += 1;

        }
        else if (Enemy._pointerIndex >= other.gameObject.GetComponent<Enemy>().Pointers.Length - 1)
        {
            Enemy._pointerIndex = 0;
        }
        //Debug.Log(Enemy._pointerIndex);
    }
}
