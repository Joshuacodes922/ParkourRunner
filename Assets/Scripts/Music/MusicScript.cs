using UnityEngine;

public class MusicScript : MonoBehaviour
{
    [SerializeField] AudioSource music;
    [SerializeField] AudioClip musicClip;

    private void Awake()
    {
        music.clip = musicClip;
        music.loop = true;
        music.Play();
        DontDestroyOnLoad(gameObject);
    }
}
