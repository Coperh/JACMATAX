using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundController : MonoBehaviour
{

    [SerializeField] protected GameObject right_player; // player that spawns on right, score, health, etc. also on right
    [SerializeField] protected GameObject left_player; // player that spawns on left, score, health, etc. also on left



    // Start is called before the first frame update
    void Start()
    {
        SpawnSprites();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnSprites() {

        Vector2 rightPos = new Vector2(10, 10);
        Vector2 leftPos = new Vector2(20, 10);


        // create right player
        Instantiate(
            right_player,
            rightPos,
            Quaternion.identity);


        // create right player
        Instantiate(
            left_player,
            leftPos,
            Quaternion.identity);
    }


}
