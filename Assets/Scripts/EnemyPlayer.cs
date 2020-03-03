using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyPlayer : GenericPlayer
{

    private GameObject enemy;
    
    


    // Update is called once per frame
    protected new void Start()
    {
        base.Start();
        FindTarget();


        // after 2 seconds start fireing every second
        InvokeRepeating("Fire", 10.0f, 1f);
    }
    protected new void Update()
    {
        base.Update();
    }


    private void FindTarget() {
        GameObject target = GameObject.Find("LeftPlayer(Clone)");
        GetComponent<AIDestinationSetter>().target = target.transform;

    }





}

