using UnityEngine;
using UnityEngine.InputSystem;

public class OnShooting : MonoBehaviour
{


    public GameObject currentWeapon;
    public WeaponSO weaponSO;


    

    private void Start()
    {
     
    }
    void OnShoot(InputValue value)
    {
        Debug.Log("Shooting before current weapon");
        if (!currentWeapon) return;
        Debug.Log("Shooting after current weapon");
        if (weaponSO.slashWeapon)
        {
            currentWeapon.gameObject.GetComponent<Katana>().Slash();
        }
        else {
            currentWeapon.gameObject.GetComponent<RocketFire>().Fire();
        }
            
        
    }
}
