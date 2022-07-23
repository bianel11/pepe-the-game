using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float healthQty = 500;
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

            if (isNormal)
            {
                isNormal = false;
                animator.Play("GetHit", -1, 0f);
                coroutine = WaitAndPrint(2.0f);
                StartCoroutine(coroutine);
            }
        }

    }

    private IEnumerator WaitAndPrint(float waitTime)
    {
        while (isNormal == false)
        {
            yield return new WaitForSeconds(waitTime);
            print("WaitAndPrint " + Time.time);
            isNormal = true;

        }
    }

}
