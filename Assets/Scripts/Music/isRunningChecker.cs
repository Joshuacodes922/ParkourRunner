using UnityEngine;

public class PlayerAnimationChecker : MonoBehaviour
{
    Animator animator;
    public bool isRunning=true;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

        if (stateInfo.IsName("Run")) 
        {
            isRunning = true;
            
        }
        else
        {
            isRunning = false;
        }
        Debug.Log("IsRunning: " + isRunning);
    }
}
