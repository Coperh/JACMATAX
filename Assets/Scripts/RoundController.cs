using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundController : MonoBehaviour
{

    [SerializeField] protected GameObject RightPlayerPrefab; // player that spawns on right, score, health, etc. also on right
    [SerializeField] protected GameObject LeftPlayerPrefab; // player that spawns on left, score, health, etc. also on left
    protected GameObject RightPlayer;
    protected HealthSystem RightPlayerHealth;

    protected GameObject LeftPlayer;
    protected HealthSystem LeftPlayerHealth;


    // Start is called before the first frame update
    void Start()
    {
        SpawnSprites();
        GetHealthObject();
    }


    // Update is called once per frame
    void Update()
    {
        CheckHealth();
    }


    private void CheckHealth() {

        Debug.Log(RightPlayerHealth.GetHealth());
        Debug.Log(LeftPlayerHealth.GetHealth());

    }

    private void GetHealthObject() {
        RightPlayerHealth = RightPlayer.GetComponent<GenericPlayer>().health;
        LeftPlayerHealth = LeftPlayer.GetComponent<GenericPlayer>().health;
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
    }


}
