using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            int next = (SceneManager.GetActiveScene().buildIndex + 1) % SceneManager.sceneCountInBuildSettings;
            SceneManager.LoadScene(next);
            Debug.Log($"[SceneChanger] {next}번 씬으로 이동");
        }
    }
}