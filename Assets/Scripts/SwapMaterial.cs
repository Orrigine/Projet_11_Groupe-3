using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapMaterial : MonoBehaviour
{
    [SerializeField] Material _fireEffect;
    [SerializeField] Material _frostEffect;
    Material _self;
    // Start is called before the first frame update
    private void Start()
    {
        _self = gameObject.GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Bite");
        if (collision.gameObject.layer == 8)
        {
            gameObject.GetComponent<Renderer>().material = _fireEffect;
            _self.SetFloat("Burn", 0.3f);
        }
    }
}

