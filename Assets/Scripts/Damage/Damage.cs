using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] ObstacleDamageSO obstacleDamageSO;
    

    private void OnTriggerEnter(Collider other)
    {
        
        if (!other.CompareTag("Player")) return;

        PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();
        playerHealth.decreaseHealth(obstacleDamageSO.damage);
    }
}
