using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyCounter : MonoBehaviour
{
    public string enemyTag = "Enemy"; // Tag of the enemy objects
    public string sceneToLoad = "NextLevel"; // Name of the scene to load when there are no enemies

    void Update()
    {
        int enemyCount = GameObject.FindGameObjectsWithTag(enemyTag).Length;

        if (enemyCount == 0)
        {
            LoadNextScene();
        }
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
