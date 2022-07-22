using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerController : MonoBehaviour
{
    private Rigidbody player;
    private Animator anim;
    public float playerVelocity;

    public float playerRotationSpeed;

    // private string iddle = "Idle_Normal_SwordAndShield";
    // private string running = "MoveBWD_Battle_InPlace_SwordAndShield";

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody>();
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        // Movements vars
        anim.SetBool("isRunning", false);
        anim.SetBool("isAttack", false);

        float movH = Input.GetAxis("Horizontal");
        float movV = Input.GetAxis("Vertical");


        Vector3 movement = new Vector3(movH, 0.0f, movV);
        if (movement != Vector3.zero)
        {
            anim.SetBool("isRunning", true);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement.normalized), 0.2f);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            print("Attaque");
            anim.SetBool("isRunning", false);
            anim.SetBool("isAttack", true);
        }
        if (movement != Vector3.zero) transform.Translate(movement * playerVelocity * Time.deltaTime, Space.World);
    }
}
