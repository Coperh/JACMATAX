using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserPlayer : GenericPlayer
{



    protected new void Start()
    {
        // call base start method
        base.Start();
    }

    // Update is called once per frame
    protected new void Update()
    {
        // call base update method
        base.Update();
        Run();
        DetectJump();
        DetectFire();

    }

    private void Run()
    {
        // get input
        float controlThrow = Input.GetAxis("Horizontal");
        // set new vector
        Vector2 playerVelocity = new Vector2(controlThrow * runSpeed, playerRigidBody.velocity.y);

        playerRigidBody.velocity = playerVelocity;
        FlipSprite();
    }


    private void DetectFire()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
    }

    private void DetectJump() { 
    if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
   }

}
