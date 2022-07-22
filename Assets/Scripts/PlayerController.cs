using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody player;

    public float playerVelocity;

    public float playerRotationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        // Movements vars
        float movH = Input.GetAxis("Horizontal");
        float movV = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(movH, 0.0f, movV);
        if (movement != Vector3.zero)
        {
            print("girando");
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement.normalized), 0.2f);
        }

        if (movement != Vector3.zero) transform.Translate(movement * playerVelocity * Time.deltaTime, Space.World);


    }
}
