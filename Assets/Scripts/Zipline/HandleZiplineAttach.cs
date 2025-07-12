using UnityEngine;

public class HandleZiplineAttach : MonoBehaviour
{
    [SerializeField] Transform childHandle;
    Animator animator;
    float animationSpeed = 1;

    GameObject player;
    bool entered = false;
    bool attached = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Debug.Log("Animation speed: " + animationSpeed);
        if (!entered || attached) return;

        var movement = player?.GetComponent<Movement>();
        
        if (movement == null) return;

        if (movement.jumpedNearZipline)
        {
            movement.jumpedNearZipline = false; // reset after use
            attached = true;
            animationSpeed *= movement.animationMultiplier;
            animator.speed *= animationSpeed;
            animator.enabled = true;
            transform.parent = null;
            movement.AttachToRope(childHandle, gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        player = other.gameObject;
        player.GetComponent<Movement>().isNearZipline = true;
        entered = true;
        Debug.Log("Player is ready to enter the zipline");
    }
}
