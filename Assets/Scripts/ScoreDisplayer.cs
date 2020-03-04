using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreDisplayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GetScore() {
        GameObject gc = GameObject.Find("GameController");

        (int a, int b) scores = gc.GetComponent<GameController>().GetScore();

        Destroy(gc);
        DisplayScore(scores.a,scores.b);

    }


    public void DisplayScore(int player1, int player2) {
        GameObject.Find("Score1").GetComponent<Text>().text = player1.ToString();
        GameObject.Find("Score2").GetComponent<Text>().text = player2.ToString();

        TextMeshProUGUI winner = GameObject.Find("Winner").GetComponent<TextMeshProUGUI>();

        if (player2 > player1)
        {
            winner.text = "Player 2 Wins";
        }
        else if (player2 < player1)
        {
            winner.text = "Player 1 Wins";
        }
        else
        {
            winner.text = "Game Draw";
        }

    }
}
