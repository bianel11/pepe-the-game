using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndController : MonoBehaviour
{
    // Start is called before the first frame update
    public Text scoreText;
    void Start()
    {
        scoreText.text = "Your score is " + GameManagment.Instance.playerPoints;
    }

    public void EndGame()
    {
        Application.Quit();
    }
}
