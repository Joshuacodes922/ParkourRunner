using UnityEngine;

public class NotifyOnExit : StateMachineBehaviour
{
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("Animation finished!");

        // Get the parent GameObject of the animator
        GameObject parent = animator.transform.parent?.gameObject;
        Debug.Log("Parent: "+parent);
        if (parent != null)
        {
            parent.gameObject.GetComponent<Katana>().setCollider(false);
        }
    }
}
