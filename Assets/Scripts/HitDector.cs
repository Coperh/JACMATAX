using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HitDector : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.tag == "Player")
        {
            PlayerHit(hit.gameObject);
        }
        Destroy(gameObject);
    }

    void PlayerHit(GameObject player) {
        SoundManagerScript.PlaySound("playerHit");
        GenericPlayer p = player.GetComponent<GenericPlayer>();
        p.DamagePlayer();
        

    }

    private void OnDestroy()
    {
        //Debug.Log("Do Something");
    }

}
