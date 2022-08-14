using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsController : MonoBehaviour
{
    public float healthPoints = 10;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.name == "Player")
        {
            player.GetComponent<PlayerController>().AddHealth(healthPoints);
            Destroy(gameObject);
        }
    }
}
