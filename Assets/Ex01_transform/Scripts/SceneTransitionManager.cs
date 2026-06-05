using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
    public int sceneIndex = 0;
    public void LoadScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }
    private void OnTriggerEnter(Collider other)
    {
        LoadScene(sceneIndex);
    }
}
