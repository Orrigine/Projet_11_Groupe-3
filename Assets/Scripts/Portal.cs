using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collide with portal");
        if (other.gameObject.layer == 6)
        {
            Debug.Log("changing scene");
            SceneManager.LoadScene("Win");
        }
    }
}
