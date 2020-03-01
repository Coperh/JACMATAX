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

    private float MaxScore = 100;

    private bool roundOver = false;

    private int leftScore = 0;
    private int rightScore = 0;

    public int leftAmmo = 22;
    public int rightAmmo = 22;




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
    public void EndRound(Players player, int leftAmmoRemaining, int rightAmmoRemaining) {


        Debug.Log(leftAmmoRemaining.ToString() + " " + rightAmmoRemaining.ToString());

        int score;
        float ammoSpent;

        // check which player won then calculate score
        // Score is calculated by percentage bullets spent as a percent of max score
        if (player == 0) 
        {


            ammoSpent = (float)leftAmmoRemaining / leftAmmo;
            score = (int)(MaxScore * ammoSpent);
            leftScore = leftScore + score;
        }
        else
        {
            ammoSpent = (float)rightAmmoRemaining / rightAmmo;
            score = (int)(MaxScore * ammoSpent);

            rightScore = rightScore + score;
        }



        // ammo for next round is all of spend ammo + half of unspent ammo
        leftAmmo = (leftAmmo - leftAmmoRemaining) + (leftAmmoRemaining /2);
        rightAmmo = (rightAmmo - rightAmmoRemaining) + (rightAmmoRemaining / 2);

        Debug.Log(leftScore.ToString() + " " + rightScore.ToString());
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
        currentLevel++;
        if (currentLevel > scenes.Length-1) {
            currentLevel = 0;
        }
    }


}


