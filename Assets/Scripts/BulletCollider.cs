using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollider : MonoBehaviour
{
    void Start()
    {
        Destroy(this.gameObject, 5);
    }

    void Update()
    {

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == Player._playerLayer) return;
        Destroy(this.gameObject);

        if (other.gameObject.layer == Enemy._enemyLayer)
        {
            Destroy(other.gameObject);
        }
    }
}
