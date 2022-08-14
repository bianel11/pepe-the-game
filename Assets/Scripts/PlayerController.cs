using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    private Rigidbody player;
    private Animator anim;
    public float playerVelocity;
    public float health;
    public float playerRotationSpeed;
    public Text label;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody>();
        anim = gameObject.GetComponent<Animator>();
        ReloadLabel();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddHealth(float qty)
    {
        health += qty;
        ReloadLabel();
    }

    public void RemoveHealth()
    {
        health = health - 10;
        if (health <= 0)
        {
            Destroy(gameObject);
            ShowLossGame();
        }
        else
        {
            ReloadLabel();
        }
    }
    void ShowLossGame()
    {
        label.text = "PERDISTE EL JUEGO";
    }
    void ReloadLabel()
    {
        label.text = "Salud: " + health.ToString();
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
            anim.SetBool("isRunning", false);
            anim.SetBool("isAttack", true);
        }
        if (movement != Vector3.zero) transform.Translate(movement * playerVelocity * Time.deltaTime, Space.World);
    }
}
