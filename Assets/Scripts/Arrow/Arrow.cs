using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] ObstacleDamageSO ObstacleDamageSO;
    Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Platform")) return;
        animator.enabled = false;
        Debug.Log("Hit: " + other.name);
        
        Debug.Log("Hit: " + other.name);
        Vector3 originalPosition = transform.position;
        Quaternion originalRotation = transform.rotation;

        transform.SetParent(other.transform, true); 


        transform.position = originalPosition;
        transform.rotation = originalRotation;

    }

}
