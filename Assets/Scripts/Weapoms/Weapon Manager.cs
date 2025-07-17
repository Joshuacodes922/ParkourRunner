using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    GameObject currentWeapon;
    [SerializeField] GameObject katana;
    public WeaponSO weaponSO;
    OnShooting onShooting;
    [SerializeField] GameObject instantiationPoint;

    private void Awake()
    {
        currentWeapon = katana;
        weaponSO = katana.gameObject.GetComponent<Katana>().weaponSO;
        onShooting = GetComponent<OnShooting>();
        attachToPlayer();
    }

   

    public void setCurrentWeapon(GameObject weapon)
    {
        currentWeapon = weapon;
    }
    public void attachToPlayer()
    {
        currentWeapon.gameObject.transform.SetParent(instantiationPoint.transform); // parent to the empty
        currentWeapon.gameObject.transform.localPosition = Vector3.zero;  // snap exactly to it
        currentWeapon.gameObject.transform.localRotation = Quaternion.identity; // optional: align rotation
        onShooting.weaponSO = weaponSO;
        onShooting.currentWeapon = currentWeapon;
    }
}
