using Unity.VisualScripting;
using UnityEngine;

public class AmmoCount : MonoBehaviour
{
    [SerializeField] int ammoCount = 5;

    public int getAmmoCount()
    {
        return ammoCount;
    }

    public void destroyObjectOnZero()
    { 
        Destroy(gameObject);
    }
    
}
