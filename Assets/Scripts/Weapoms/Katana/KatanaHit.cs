using UnityEngine;

public class KatanaHit : MonoBehaviour
{
    [SerializeField] GameObject rosevinesBroken;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Katana"))
        {
            Debug.Log("It has entered yuh");
            GameObject obj = Instantiate(rosevinesBroken,transform.position,Quaternion.identity,transform.parent);
            Destroy(gameObject);
        }
        
    }
}
