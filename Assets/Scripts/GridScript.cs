using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridScript : MonoBehaviour
{

    public Canvas gameOverCanvas;
    public RectTransform gameOverPanel;
    public Text gameOverText;
    public Button gameOverButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        PlayerMovement playerScript;
        GameObject player2 = GameObject.FindGameObjectWithTag("Player2");
        Player2Movement player2Script;

        if ( player == null && player2 == null )
        {

            // tie
            gameOverCanvas.gameObject.SetActive(true);
            gameOverText.text = "IT'S A TIE!";
            Time.timeScale = 0;
            
        } 

        else if ( player == null )
        {

            // player 2 wins
            gameOverCanvas.gameObject.SetActive(true);
            gameOverText.text = "PLAYER 2 WINS!";
            Time.timeScale = 0;

        } 
        
        else if ( player2 == null )
        {

            // player 1 wins
            gameOverCanvas.gameObject.SetActive(true);
            gameOverText.text = "PLAYER 1 WINS!";
            Time.timeScale = 0;

        }

    }
}
