using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlayer : GenericPlayer
{

    // Update is called once per frame
    protected new void Start()
    {
        base.Start();
        // after 2 seconds start fireing every second
        InvokeRepeating("Fire", 2.0f, 1f);
    }
    protected new void Update()
    {
        base.Update();
    }
}
