using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] string sceneToSwitch;
    public void LoadScene(string sceneToSwitch)
    {
        SceneManager.LoadScene(sceneToSwitch);
    }

    public void Quit()
    {
        Application.Quit();
    }

}
