using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnPrefabInNextScene : MonoBehaviour
{
    public GameObject prefabToSpawn; // The prefab to spawn in the next scene

    private void Start()
    {
        // Subscribe to the scene loaded event
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDestroy()
    {
        // Unsubscribe from the scene loaded event
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void SpawnPrefabAndLoadNextScene()
    {
        // Load the next scene
        SceneManager.LoadScene("Game");
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Check if the loaded scene is the desired next scene
        if (scene.name == "Game")
        {
            // Spawn the prefab at the specified position
            Instantiate(prefabToSpawn, new Vector3(-16f, -14f, 0f), Quaternion.identity);
        }
    }
}