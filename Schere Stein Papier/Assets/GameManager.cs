using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text enemyText;

    public Button schereB;
    public Text schereT;
    public Button steinB;
    public Text steinT;
    public Button papierB;
    public Text papierT;

    public GameObject resultPanel;
    public Text resultText;

    void Awake()
    {
        resultPanel.SetActive(false);
    }
    public string createRandomSSP()
    {
        int rand = Random.Range(1, 3);
        if (rand == 1)
        {
            return "Schere";
        }
        if (rand == 2)
        {
            return "Stein";
        }
        if (rand == 3)
        {
            return "Papier";
        }
        return "nothing";
    }

    public void PlayGame()
    {
        string playerChoice = 
        enemyText.text = createRandomSSP();
        string winner = DecideWinner(playerChoice);
        if(winner == "player")
        {

        }
        else if(winner == "enemy")
        {

        }
        else
        {

        }
    }

    public string DecideWinner()
    {

    }
}
