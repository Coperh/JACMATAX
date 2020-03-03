using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyPlayer : GenericPlayer
{

    private GameObject enemy;

    public AIPath path;


    // Update is called once per frame
    protected new void Start()
    {
        base.Start();
        FindTarget();
        GetPath();

        // after 2 seconds start fireing every second
        InvokeRepeating("Fire", 10.0f, 1f);
    }
    protected new void Update()
    {
        base.Update();

        CheckDirection();
    }


    private void FindTarget() {
        GameObject target = GameObject.Find("LeftPlayer(Clone)");
        GetComponent<AIDestinationSetter>().target = target.transform;

    }



    private void GetPath() {

        path = GetComponent<AIPath>();
    }

    /**
     Checks for the direction of the sprite and flips it
         */
    private void CheckDirection() {
        if (path.desiredVelocity.x > Mathf.Epsilon)
        {
            transform.localScale = new Vector2(1, 1);
        }
        else if (path.desiredVelocity.x < (0 - Mathf.Epsilon)) {
            transform.localScale = new Vector2(-1, 1);
        }

    }


}
