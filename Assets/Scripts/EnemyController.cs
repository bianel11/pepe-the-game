using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float healthQty;
    private Animator animator;
    private IEnumerator coroutine;
    private bool isNormal = true;


    public GameObject player;
    public float distance;
    public bool isAngered;
    public NavMeshAgent _agent;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(player.transform.position, this.transform.position);

        if (distance <= 5)
        {
            isAngered = true;
        }
        if (distance > 5f)
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
        }
    }

    void OnTriggerEnter(Collider espada)
    {

        if (espada.name == "clavicle_r")
        {
            healthQty--;
            if (healthQty <= 0)
            {
                Destroy(gameObject);
                return;
            }

            if (isNormal)
            {
                // Back position after hit
                Vector3 direction = transform.position - player.transform.position;
                direction.Normalize();
                gameObject.transform.position = gameObject.transform.position + direction;

                // Animations
                isNormal = false;
                animator.Play("GetHit", -1, 0f);
                coroutine = WaitAnimation(1.0f);
                StartCoroutine(coroutine);
            }
        }

    }

    private IEnumerator WaitAnimation(float waitTime)
    {
        while (isNormal == false)
        {
            yield return new WaitForSeconds(waitTime);
            // print("WaitAnimation " + Time.time);
            isNormal = true;

        }
    }

}
