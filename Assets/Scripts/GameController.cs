using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    [SerializeField] private UnityEngine.Object[] scenes;

    private int currentLevel = 0;

    private int numberOfRounds;
    private int roundsPlayed = 0;

    private bool roundOver = false;

    private int leftScore = 0;
    private int rightScore = 0;




    void Awake()
    {
        // makes scene allways active
        DontDestroyOnLoad(transform.gameObject);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        changeRound();

    }

    // called by round controller to end current round
    public void EndRound(Players player) {

        // check which player won
        if (player == 0) leftScore++;
        else rightScore++;
     
        roundOver = true;
    }


    public void StartGame() {

        string roundString = GameObject.Find("NumberOfRoundsInput").GetComponent<InputField>().text;

        numberOfRounds = int.Parse(roundString);
        Debug.Log(numberOfRounds);
        LoadNextLevel();

    }


    public void EndGame() {
        SceneManager.LoadScene("EndScreen");
    }

    void changeRound() {
        if (roundOver) {
            roundOver = false;
            roundsPlayed++;
            if (roundsPlayed >= numberOfRounds)
            {
                Debug.Log("game Over");
                EndGame();
                Destroy(gameObject);
            }
            else
            {
                Debug.Log("Load next level");
                LoadNextLevel();
            }
        }

    }


    
    public void LoadNextLevel() {

        SceneManager.LoadScene(scenes[currentLevel].name);
        Debug.Log(leftScore.ToString() + " " + rightScore.ToString());
        currentLevel++;
        if (currentLevel > scenes.Length-1) {
            currentLevel = 0;
        }
    }


}


