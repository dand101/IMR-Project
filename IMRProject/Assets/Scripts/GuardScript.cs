using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardScript : MonoBehaviour
{
    private enum GuardState
    {
        Idle,
        Chasing,
        Attacking,
        Dead
    }


    private bool ragdollActivated = false;

    private GuardState currentState = GuardState.Idle;
    private CharacterController characterController;
    private Animator animator;
    private Transform player;

    public float chaseDistance = 10f;
    public float attackDistance = 4f;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

        player = GameObject.FindGameObjectWithTag("Player").transform;

        Limb[] limbs = GetComponentsInChildren<Limb>();
        foreach (Limb limb in limbs)
        {
            limb.OnHitByWeapon += OnLimbHitByWeapon;
        }
    }
    void OnLimbHitByWeapon()
    {
        if (ragdollActivated == false)
        {
            currentState = GuardState.Dead;
            ActivateRagdoll();
            ragdollActivated = true;
        }

    }

    void ActivateRagdoll()
    {
        ragdollActivated = true;

        DisableCharacterComponents();

        EnableRagdollComponents(transform);

        animator.enabled = false;

        Rigidbody[] ragdollRigidbodies = GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody rb in ragdollRigidbodies)
        {
            rb.AddForce(Vector3.forward * 5f, ForceMode.Impulse);
        }
    }

    void DisableCharacterComponents()
    {
        if (characterController != null)
        {
            characterController.enabled = false;
        }

    }

    void EnableRagdollComponents(Transform parent)
    {
        foreach (Transform child in parent)
        {
            Rigidbody rb = child.GetComponent<Rigidbody>();
            Collider col = child.GetComponent<Collider>();

            if (rb != null)
            {
                rb.isKinematic = false;
            }

            if (col != null)
            {
                col.enabled = true;
            }

            EnableRagdollComponents(child);
        }
    }

    void Update()
    {   
        if(ragdollActivated == false)
        {
            switch (currentState)
            {
                case GuardState.Idle:
                    UpdateIdleState();
                    break;

                case GuardState.Chasing:
                    UpdateChasingState();
                    break;

                case GuardState.Attacking:
                    UpdateAttackingState();
                    break;

                case GuardState.Dead:
                    UpdateDeadState();
                    break;
            }
        }
    }

    void UpdateDeadState()
    {
        animator.ResetTrigger("isAttacking");
        animator.SetTrigger("isChasing");
        animator.enabled = false;
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        if (agent != null)
        {
            agent.isStopped = true;
        }
    }

    void UpdateIdleState()
    {

        //Debug.Log(Vector3.Distance(transform.position, player.position));
        if (Vector3.Distance(transform.position, player.position) < chaseDistance)
        {
            currentState = GuardState.Chasing;
        }
    }


    void UpdateChasingState()
    {
        //Debug.Log("Chase");
        animator.SetTrigger("isChasing");
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        if (agent != null)
        {
            agent.SetDestination(player.position);
        }

        if (Vector3.Distance(transform.position, player.position) < attackDistance)
        {
            currentState = GuardState.Attacking;
        }
    }

    void UpdateAttackingState()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        if (agent != null)
        {
            agent.isStopped = true;
        }

        animator.SetTrigger("isAttacking");

        StartCoroutine(TransitionToChasing(2f));
    }

    IEnumerator TransitionToChasing(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        if (agent != null)
        {
            agent.isStopped = false;
        }

        animator.ResetTrigger("isAttacking");
        animator.SetTrigger("isChasing");

        yield return new WaitForSeconds(0.5f);

        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            animator.ResetTrigger("isChasing");

            currentState = GuardState.Chasing;
        }
    }
}