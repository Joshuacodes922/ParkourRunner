using UnityEngine;
using UnityEngine.InputSystem;

public class RocketFire : MonoBehaviour
{
    [SerializeField] Transform InstantiationPoint;
    [SerializeField] GameObject Bullet;
    [SerializeField] WeaponSO weaponSO;
    AmmoCount ammoCount;
    int shotsFired;

    private void Start()
    {
        ammoCount = GetComponent<AmmoCount>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player")) return;

        Debug.Log("Player has entered");

        var weaponManager = other.GetComponent <WeaponManager>();
        weaponManager.setCurrentWeapon(gameObject);
        weaponManager.attachToPlayer();
        weaponManager.weaponSO = weaponSO;
        

    }

    public void Fire()
    {
        

        GameObject bulletObj = Instantiate(Bullet, InstantiationPoint.position, InstantiationPoint.rotation);
        FireBullet fireBullet = bulletObj.GetComponent<FireBullet>();
        fireBullet.shootCannon();

        shotsFired++;

        if (shotsFired >= ammoCount.getAmmoCount())
        {
            Destroy(gameObject);
            return;
        }
    }
}
