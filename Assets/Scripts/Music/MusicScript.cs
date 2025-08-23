using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicScript : MonoBehaviour
{
    [SerializeField] AudioSource music;
    [SerializeField] AudioClip musicClip;

    private static MusicScript instance;
    private string originalScene;
    private bool firstLoad = true; // <--- new flag

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        if (music == null)
            music = gameObject.AddComponent<AudioSource>();

        if (musicClip != null)
        {
            music.clip = musicClip;
            music.loop = true;
            music.Play();
        }

        originalScene = SceneManager.GetActiveScene().name;
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (firstLoad)
        {
            firstLoad = false;
            return; // ignore the initial scene load
        }

        if (scene.name == originalScene)
        {
            Destroy(gameObject);
            instance = null;
        }
    }
}
