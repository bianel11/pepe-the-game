using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossController : MonoBehaviour
{
    public GameObject player;
    public float distance;
    public bool isAngered;
    public bool isAttacking = false;
    public NavMeshAgent _agent;
    private bool isNormal = true;
    private Animator animator;

    public float focusDistance = 5f;
    public float attackDistance = 1f;
    private IEnumerator coroutine;
    public float attackDelay = 1.0f;
    public float damage = 20.0f;


    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();

    }
    void resetAnimations()
    {
        animator.SetBool("isAttacking", isAttacking);

        animator.SetBool("isRunning", isAngered);

    }
    // Update is called once per frame
    void Update()
    {

        resetAnimations();
        if (!player) return;
        distance = Vector3.Distance(player.transform.position, this.transform.position);

        if (distance <= focusDistance)
        {
            isAngered = true;

            if (distance <= attackDistance && !isAttacking)
            {
                AttackPlayer();
            }
            // else
            // {
            //     animator.SetBool("isRunning", true);
            // }

        }
        if (distance > focusDistance)
        {
            isAngered = false;
        }

        if (isAngered)
        {
            _agent.isStopped = false;
            if (isNormal)
                _agent.SetDestination(player.transform.position);
        }
        if (!isAngered)
        {
            _agent.isStopped = true;
            animator.SetBool("isRunning", false);

        }

    }

    void AttackPlayer()
    {
        isAttacking = true;
        animator.SetBool("isAttacking", true);

        coroutine = WaitForAttack(attackDelay); // time to attack 
        StartCoroutine(coroutine);

    }


    private IEnumerator WaitForAttack(float waitTime)
    {
        while (isAttacking == true)
        {
            yield return new WaitForSeconds(waitTime);
            isAttacking = false;
            print("Atacando");
            player.GetComponent<PlayerController>().RemoveHealth(damage);


        }
    }
}
