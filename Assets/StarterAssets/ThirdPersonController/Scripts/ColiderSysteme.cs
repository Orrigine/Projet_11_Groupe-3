using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColiderSysteme : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == 6) return;
        Destroy(this.gameObject);
    }
}
