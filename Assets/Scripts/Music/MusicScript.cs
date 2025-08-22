using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicScript : MonoBehaviour
{
    [SerializeField] AudioSource music;
    [SerializeField] AudioClip musicClip;

    private static MusicScript instance;
    private string originalScene;

    private void Awake()
    {
        // Singleton check
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        // Start music
        music.clip = musicClip;
        music.loop = true;
        music.Play();

        // Remember the scene we first spawned in
        originalScene = SceneManager.GetActiveScene().name;

        // Listen for scene changes
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // If we come back to the original scene, kill this music object
        if (scene.name == originalScene)
        {
            Destroy(gameObject);
            instance = null; // reset so if you leave again, new one can spawn
        }
    }
}
