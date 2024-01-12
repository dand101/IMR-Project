using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContr : MonoBehaviour
{
    public int health = 100;
    private Dictionary<GameObject, bool> swordCooldowns = new Dictionary<GameObject, bool>();

    public float damageCooldown = 1f;
    private int number= 0;

    void Start()
    {
        swordCooldowns = new Dictionary<GameObject, bool>();
    }

    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GuardWeapon"))
        {
            if (!swordCooldowns.ContainsKey(other.gameObject) || swordCooldowns[other.gameObject])
            {
                number++;
                //Debug.Log("Got hit with" + number);
                TakeDamage(25);
                swordCooldowns[other.gameObject] = false;
                StartCoroutine(ResetDamageCooldown(other.gameObject));
            }
        }
    }

    void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Player died!");
    }

    IEnumerator ResetDamageCooldown(GameObject sword)
    {
        yield return new WaitForSeconds(damageCooldown);
        swordCooldowns[sword] = true;
    }
}
