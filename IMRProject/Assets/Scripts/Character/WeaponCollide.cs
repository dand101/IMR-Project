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
        Debug.Log("COLL");
        if (other.CompareTag("Weapon"))
        {
            Debug.Log("LALALA");
            TriggerDeath();
        }
    }

    void TriggerDeath()
    {
        animator.SetTrigger("DeathTrigger");
    }
}
