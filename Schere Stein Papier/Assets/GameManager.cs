using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text enemyText;

    public GameObject background;

    public GameObject resultPanel;
    public Text resultText;

    public Button enemyButton;
    public Button[] buttonList;

    private Color startColor;

    void Awake()
    {
        startColor = background.GetComponent<Image>().color;
        resultPanel.SetActive(false);
    }


    public string CreateRandomChoice()
    {
        int rand = Random.Range(1, 4);
        if (rand == 1)
        {
            return "Schere";
        }
        else if (rand == 2)
        {
            return "Stein";
        }
        else if (rand == 3)
        {
            return "Papier";
        }
        else
        {
            return "nothing";
        }
    }

    public void PlayGame()
    {
        string playerChoice = EventSystem.current.currentSelectedGameObject.gameObject.GetComponent<PlayerChoice>().GetChoice();
        string enemyChoice = CreateRandomChoice();
        enemyText.text = enemyChoice;
        string winner = DecideWinner(playerChoice,enemyChoice);
        if(winner=="player")
        {
            resultPanel.SetActive(true);
            ChangeBackgroundColor(new Color(0,255,0,255));
            resultText.text = "Du hast gewonnen!";
        }
        else if (winner == "enemy")
        {
            resultPanel.SetActive(true);
            ChangeBackgroundColor(new Color(255, 0, 0, 255));
            resultText.text = "Du hast verloren!";
        }
        else
        {
            resultPanel.SetActive(true);
            ChangeBackgroundColor(startColor);
            resultText.text = "Unentschieden!";
            
        }
        SetButtonActivation(false);
    }

    private void ChangeBackgroundColor(Color color)
    {
        background.GetComponent<Image>().color = color;
    }

    public string DecideWinner(string playerChoice, string enemyChoice)
    {
        if ((playerChoice=="Schere" && enemyChoice == "Papier")||
            (playerChoice=="Papier" && enemyChoice == "Stein")||
            (playerChoice=="Stein" && enemyChoice == "Schere"))
        {
            return "player";
        }
        else if ((enemyChoice == "Schere" && playerChoice == "Papier") ||
            (enemyChoice == "Papier" && playerChoice == "Stein") ||
            (enemyChoice == "Stein" && playerChoice == "Schere"))
        {
            return "enemy";
        }
        else
        {
            return "draw";
        }
    }

    public void Reset()
    {
        SetButtonActivation(true);
        resultPanel.SetActive(false);
        ChangeBackgroundColor(startColor);
    }

    public void SetButtonActivation(bool toggle)
    {
        for(int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<Button>().interactable = toggle;
        }
        enemyButton.GetComponentInParent<Button>().interactable = toggle;
    }

}
