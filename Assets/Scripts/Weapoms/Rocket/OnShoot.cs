using UnityEngine;
using UnityEngine.InputSystem;

public class OnShooting : MonoBehaviour
{

    [SerializeField] AudioSource audioSource;
    public GameObject currentWeapon;
    public WeaponSO weaponSO;

    [SerializeField] GameObject animatorBase;

    Animator animator;


    private void Awake()
    {
        animator = animatorBase.GetComponent<Animator>();
        
    }

    private void Start()
    {
     
    }
    void OnShoot(InputValue value)
    {

        if (!currentWeapon) return;

        if (weaponSO.slashWeapon)
        {
            animator.Play("Slash");
            audioSource.GetComponent<GameActionAudio>().playSfx(audioSource.GetComponent<GameActionAudio>().slash);
            currentWeapon.GetComponent<Katana>().setCollider(true);
        }
        else {
            currentWeapon.gameObject.GetComponent<RocketFire>().Fire();
        }
            
        
    }
}
