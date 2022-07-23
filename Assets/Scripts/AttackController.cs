using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    // Start is called before the first frame update
    private Collider gameCollider;
    void Start()
    {
        gameCollider = gameObject.GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        gameCollider.enabled = false;

        if (Input.GetKey(KeyCode.Space))
        {
            gameCollider.enabled = true;
        }
    }
}
