using UnityEngine;

public class GameActionAudio : MonoBehaviour
{
    [SerializeField] AudioSource SFXSource;
    [SerializeField] AudioSource runSource;
    public PlayerAnimationChecker playerAnimationChecker;
    public AudioClip run;
    public AudioClip slash;
    public AudioClip slide;
    public bool gameNotOver = true;

    private void Start()
    {
        runSource.clip = run;
        gameNotOver = true;
    }
    private void Update()
    {
        if (!gameNotOver)
        {
            runSource.Stop();
            return;
        }
        if (runSource.isPlaying) return;

        
        
        runSource.loop = true;
        runSource.Play();

        //if (!playerAnimationChecker.isRunning) { runSource.Stop(); }

        //if (playerAnimationChecker.isRunning  && !runSource.isPlaying) {
        //    runSource.loop = true;
        //    runSource.Play();
        //}
    }
    public void playSfx(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
