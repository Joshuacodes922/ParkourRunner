using UnityEngine;

public class NotifyOnExit : StateMachineBehaviour
{
    [SerializeField] GameObject Katana;
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("Animation finished!");

        // Get the parent GameObject of the animator
        GameObject katana = animator.gameObject.GetComponent<KatanaHolder>().katana;
        Debug.Log("Parent: "+katana);
        if (katana != null)
        {
            katana.gameObject.GetComponent<Katana>().setCollider(false);
        }
    }
}
