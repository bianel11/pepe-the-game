using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneManagment : MonoBehaviour
{
    public Text playerPoints;

    // Start is called before the first frame update
    void Start()
    {
        RefreshText();
    }

    public void AddPoints(float points)
    {
        playerPoints.text = "Puntos: " + points;
        GameManagment.Instance.sumPoints(points);
        RefreshText();
    }

    private void RefreshText()
    {
        playerPoints.text = "Puntos: " + GameManagment.Instance.playerPoints.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void LateUpdate()
    {
        if (GameObject.FindGameObjectsWithTag("SlimeEnemy").Length == 0)
        {
            GameManagment.Instance.moveNextLevel();
        }
    }
}
