using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneManagment : MonoBehaviour
{
    public Text playerPoints;
    public int enemiesCount = 0;
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
        enemiesCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

        if (enemiesCount == 0)
        {
            GameManagment.Instance.moveNextLevel();
        }
    }
}
