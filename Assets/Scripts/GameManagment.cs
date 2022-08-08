using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagment : MonoBehaviour
{
    public static GameManagment Instance;
    [SerializeField] private float playerPoints = 0;

    private void Awake()
    {
        if (GameManagment.Instance == null)
        {
            GameManagment.Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void moveNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }



    public void sumPoints(float points)
    {
        playerPoints += points;
    }

}
