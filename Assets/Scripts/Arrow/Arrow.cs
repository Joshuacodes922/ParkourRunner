using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] ObstacleDamageSO ObstacleDamageSO;
    Animator animator;
    bool animationNotDone;
    private void Start()
    {
        animator = GetComponent<Animator>();
        animationNotDone = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && animationNotDone)
        {
            PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();
            playerHealth.decreaseHealth(ObstacleDamageSO.damage);
        }
        if (!other.gameObject.CompareTag("Platform"))
        {
            return;
        }
        animator.enabled = false;
       
        Vector3 originalPosition = transform.position;
        Quaternion originalRotation = transform.rotation;

        transform.SetParent(other.transform, true); 
        animationNotDone = false;

        transform.position = originalPosition;
        transform.rotation = originalRotation;

    }

}
