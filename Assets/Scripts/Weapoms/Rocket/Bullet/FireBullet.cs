using UnityEngine;
using UnityEngine.InputSystem;

public class FireBullet : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float rocketForce = 50f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        
    }
    

    

    public void shootCannon()
    {
        rb.useGravity = true;
        rb.AddForce(transform.right * rocketForce, ForceMode.Impulse);
    }
}
