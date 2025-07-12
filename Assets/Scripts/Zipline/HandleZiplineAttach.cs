using UnityEngine;

public class HandleZiplineAttach : MonoBehaviour
{
    bool jumped = true;
    [SerializeField] Transform childHandle;
    
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (!other.gameObject.CompareTag("Player")) return;
        Debug.Log("Player is ready to enter the zipline");
        if (jumped)
        {
            transform.parent = null;
            
            //Call attach method for player.
            other.gameObject.GetComponent<Movement>()?.AttachToRope(childHandle,gameObject);
            animator.enabled = true;
        }

        
    }

   
}
