using UnityEngine;

public class WeaponCollide : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Weapon"))
        {
            TriggerDeath();
        }
    }

    void TriggerDeath()
    {
        animator.SetTrigger("DeathTrigger");
    }
}
