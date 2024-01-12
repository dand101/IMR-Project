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
        Blocked,
        Dead
    }

    public Collider guardWeaponCollider;


    private bool ragdollActivated = false;

    private GuardState currentState = GuardState.Idle;
    private CharacterController characterController;
    private Animator animator;
    private Transform player;
    private NavMeshAgent navigationAgent;

    public float chaseDistance = 10f;
    public float attackDistance = 2f;
    

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

        player = GameObject.FindGameObjectWithTag("Player").transform;
        navigationAgent = GetComponent<NavMeshAgent>();

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
        //transform.LookAt(player.position);

        if (ragdollActivated == false)
        {
            switch (currentState)
            {
                case GuardState.Idle:
                    UpdateIdleState();
                    break;

                case GuardState.Chasing:
                    //Debug.Log("chasing");
                    UpdateChasingState();
                    break;

                case GuardState.Attacking:
                    //Debug.Log("attac");
                    UpdateAttackingState();
                    break;

                case GuardState.Blocked:
                    UpdateBlockingState();
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

        navigationAgent.isStopped = true;
    }
    bool CanSeePlayer()
    {
        Vector3 directionToPlayer = player.position - transform.position;
        float distanceToPlayer = directionToPlayer.magnitude;

        Ray ray = new Ray(transform.position, directionToPlayer.normalized);

        int layerMask = LayerMask.GetMask("Obstacle");

        if (Physics.Raycast(ray, distanceToPlayer, layerMask))
        {
            return false;
        }

        return true;
    }

    void UpdateIdleState()
    {
        //transform.LookAt(player.position);
        //Debug.Log(Vector3.Distance(transform.position, player.position));
        bool canSeePlayer = CanSeePlayer();

        if (Vector3.Distance(transform.position, player.position) < chaseDistance && canSeePlayer)
        {
            currentState = GuardState.Chasing;
        }
    }

 
    void UpdateChasingState()
    {
        navigationAgent.isStopped = false;
        animator.SetBool("isChase", true);
        navigationAgent.SetDestination(player.position);

        bool canSeePlayer = CanSeePlayer();
        if (!canSeePlayer)
        {
            animator.SetBool("isChase", false);
            navigationAgent.isStopped = true;
            currentState = GuardState.Idle;
        }

        if (Vector3.Distance(transform.position, player.position) < attackDistance)
        {
            currentState = GuardState.Attacking;
        }
    }

    

    void UpdateAttackingState()
    {
        transform.LookAt(player.position);
        //Debug.Log("Stop");
        navigationAgent.isStopped = true;
        animator.SetBool("isChase", false);



        animator.SetBool("isAttack",true);

        if (IsAttackBlocked())
        {
            animator.SetTrigger("Blocked");
            animator.SetBool("isAttack", false);
            currentState = GuardState.Blocked;
        }

        if (Vector3.Distance(transform.position, player.position) < attackDistance)
        {
            currentState = GuardState.Attacking;
            //animator.ResetTrigger("isAttacking");
        } else
        {
            animator.SetBool("isAttack", false);
            //StartCoroutine(TransitionToChasing(2f));
            currentState = GuardState.Chasing;
        }
    }

    bool IsAttackBlocked()
    {
        Collider[] colliders = Physics.OverlapBox(
            guardWeaponCollider.bounds.center,
            guardWeaponCollider.bounds.extents,
            guardWeaponCollider.transform.rotation
        );

        foreach (var collider in colliders)
        {
            if (collider.CompareTag("Shield"))
            {
                return true;
            }
        }

        return false;
    }


    void UpdateBlockingState()
    {

        if (Vector3.Distance(transform.position, player.position) < attackDistance)
        {
            currentState = GuardState.Attacking;
        }
        else
        {
            currentState = GuardState.Chasing;
        }
    }

}