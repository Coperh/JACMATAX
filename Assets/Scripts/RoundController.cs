using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundController : MonoBehaviour
{

    [SerializeField] protected GameObject RightPlayerPrefab; // player that spawns on right, score, health, etc. also on right
    [SerializeField] protected GameObject LeftPlayerPrefab; // player that spawns on left, score, health, etc. also on left
    protected GameObject RightPlayer;
    protected HealthSystem RightPlayerHealth;

    protected GameObject LeftPlayer;
    protected HealthSystem LeftPlayerHealth;

    private Players winner;

    private Slider RightPlayerHealthSlider;
    private Slider LeftPlayerHealthSlider;
    private Text RightPlayerHealthText;
    private Text LeftPlayerHealthText;

    private Text RightAmmoText;
    private Text LeftAmmoText;
    




    // Start is called before the first frame update
    void Start()
    {
        SpawnSprites();
        GetHealthObject();

        SetAmmo();

        UnFreezePlayers();
    }

    // Update is called once per frame
    void Update()
    {
            UpdateHealthSlider();
            CheckHealth();
    }



    void SetAmmo() {
        GameController gc = GameObject.Find("GameController").GetComponent<GameController>();
        LeftPlayer.GetComponent<GenericPlayer>().ammo = gc.leftAmmo;

        RightPlayer.GetComponent<GenericPlayer>().ammo = gc.rightAmmo;
    }


    private void FreezePlayers() {
        // freeze players 
        RightPlayer.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
        LeftPlayer.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
        // disable control scripts
        LeftPlayer.GetComponent<GenericPlayer>().enabled = false;
        RightPlayer.GetComponent<GenericPlayer>().enabled = false;

    }

    private void UnFreezePlayers() {
        // unfreeze players ( keep rotation frozen)
        RightPlayer.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        LeftPlayer.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        // enable controll scripts
        LeftPlayer.GetComponent<GenericPlayer>().enabled = true;
        RightPlayer.GetComponent<GenericPlayer>().enabled = true;

    }


    private void EndRound(GameObject loser) {

        FreezePlayers();
        enabled = false;

        // calculate remaining ammo
        int leftAmmo = LeftPlayer.GetComponent<GenericPlayer>().ammo;
        int rightAmmo = RightPlayer.GetComponent<GenericPlayer>().ammo;




        Destroy(loser);
        // show win screen

        // end scene
        // get game controller and tell it round has ended;
        GameObject.Find("GameController").GetComponent<GameController>().EndRound(winner,leftAmmo, rightAmmo);

    }
    

    // check health condition
    private void CheckHealth() {

        if (RightPlayerHealthSlider.value <= 0) {
            winner = Players.LeftPlayer;
            EndRound(LeftPlayer);
        }

        else if (LeftPlayerHealthSlider.value <= 0) {
            
            winner = Players.RightPlayer;
            EndRound(RightPlayer);
        }

    }

    // method to update health's slider and text
    // call ChechHealth() to check win conditions
    private void UpdateHealthSlider() {
        // get player's health conditions from HealthSystem's method Gethealth()
        // set the sliders' values
        RightPlayerHealthSlider.value = RightPlayerHealth.GetHealth();
        LeftPlayerHealthSlider.value = LeftPlayerHealth.GetHealth();

        // set the Texts' value as the sliders' value
        RightPlayerHealthText.text = RightPlayerHealthSlider.value.ToString();
        LeftPlayerHealthText.text = LeftPlayerHealthSlider.value.ToString();

        // Update Ammo
        RightAmmoText.text = RightPlayer.GetComponent<GenericPlayer>().ammo.ToString();
        LeftAmmoText.text = LeftPlayer.GetComponent<GenericPlayer>().ammo.ToString();

    }

    // method to find the health objects
    private void GetHealthObject() {
        // set Right and Left Player Heath
        RightPlayerHealth = RightPlayer.GetComponent<GenericPlayer>().health;
        LeftPlayerHealth  = LeftPlayer.GetComponent<GenericPlayer>().health;

        // set the corresponding sliders game object
        RightPlayerHealthSlider = GameObject.Find("RightPlayerHealthSlider").GetComponent<Slider>();
        LeftPlayerHealthSlider  = GameObject.Find("LeftPlayerHealthSlider").GetComponent<Slider>();

        // set the corresponding Text game object
        RightPlayerHealthText = GameObject.Find("RightPlayerHealthText").GetComponent<Text>();
        LeftPlayerHealthText  = GameObject.Find("LeftPlayerHealthText").GetComponent<Text>();

        // get Ammo Texts
        RightAmmoText = GameObject.Find("RightAmmoCount").GetComponent<Text>();
        LeftAmmoText = GameObject.Find("LeftAmmoCount").GetComponent<Text>();

    }

    private void SpawnSprites() {

        Vector2 rightPos = new Vector2(20, 10);
        Vector2 leftPos = new Vector2(10, 10);


        // create right player
        RightPlayer = Instantiate(
            RightPlayerPrefab,
            rightPos,
            Quaternion.identity);


        // create right player
        LeftPlayer = Instantiate(
            LeftPlayerPrefab,
            leftPos,
            Quaternion.identity);

        FreezePlayers();
    }


}
