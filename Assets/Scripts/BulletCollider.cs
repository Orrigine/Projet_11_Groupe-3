using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollider : MonoBehaviour
{
    [SerializeField] string bulletName;
    Material _fireEffect;
    Material _frostEffect;

    void Start()
    {
        _fireEffect = Resources.Load("Materials/FireEffect", typeof(Material)) as Material;
        _frostEffect = Resources.Load("Materials/Frost Effect/Frost", typeof(Material)) as Material;
        Destroy(this.gameObject, 5);
    }

    void Update()
    {

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == Player._playerLayer) return;
        if (other.gameObject.layer == 8) return;
        if (other.gameObject.layer == 6)
        {
            Material enemyMat = other.transform.Find("default").gameObject.GetComponent<Renderer>().material;
            if (bulletName == "Fire")
            {
                Debug.Log(enemyMat.name);
                enemyMat = _fireEffect;
                enemyMat.SetFloat("Burn", 0.3f);
            }
            else if(bulletName == "Frost")
            {

            }
            //Destroy(other.gameObject, 3);
        }
        Destroy(this.gameObject);
    }
}
