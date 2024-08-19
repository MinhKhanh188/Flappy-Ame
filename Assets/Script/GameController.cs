using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    bool isEndGame;

    int gamePoint = 0;
    public Text txtPoint;

    public GameObject pnlEndGame; 
    public Text txtEndGame;
    public Button btRestart;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        pnlEndGame.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isEndGame)
        {
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
            {
                //Time.timeScale = 1;
                // isEndGame = false;
                SceneManager.LoadScene(0);
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
            {
                Time.timeScale = 1;
            }
        }

    }

    public void getPoint()
    {
        gamePoint++;
        txtPoint.text =  gamePoint.ToString();
    }


    public void EndGame()
    {
        Debug.Log("End Game, We failed"); // Corrected the debug message.
        isEndGame = true;
        Time.timeScale = 0;
        pnlEndGame.SetActive(true);
        txtPoint.text= gamePoint.ToString();
    }
}
