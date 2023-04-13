using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (Player.hasKey == true && other.gameObject.CompareTag("Player"))
        {
            Debug.Log("changing scene");
            SceneManager.LoadScene("Win");
        }
    }
}
