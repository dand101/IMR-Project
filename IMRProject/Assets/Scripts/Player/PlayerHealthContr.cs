using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerContr : MonoBehaviour
{
    public int health = 100;
    private Dictionary<GameObject, bool> swordCooldowns = new Dictionary<GameObject, bool>();

    public float damageCooldown = 1f;
    private int number= 0;

    public Canvas canvas;
    private Animator animator;

    public string sceneName = "DungeonScene";


    void Start()
    {
        swordCooldowns = new Dictionary<GameObject, bool>();
        animator = canvas.GetComponent<Animator>();

        //AnimationEvent animationEvent = new AnimationEvent();
        //animationEvent.functionName = "OnFadeComplete";
        //animationEvent.time = 1f;
        //animator.GetComponent<Animator>().runtimeAnimatorController.animationClips[0].AddEvent(animationEvent);

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
                Debug.Log("Got hit with" + number);
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
        DeathFade();
    }

    void DeathFade()
    {
        animator.SetTrigger("Dead");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(sceneName);
        animator.SetTrigger("Done");
    }


    IEnumerator ResetDamageCooldown(GameObject sword)
    {
        yield return new WaitForSeconds(damageCooldown);
        swordCooldowns[sword] = true;
    }
}
