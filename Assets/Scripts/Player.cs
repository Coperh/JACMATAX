using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D playerRigidBody;
    private Collider2D playerCollider;

    [SerializeField] private float runSpeed = 10f;
    [SerializeField] private float jumpSpeed = 15f;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        FlipSprite();
        Jump();


    }
    private void Run()
    {
        // get input
        float controlThrow = Input.GetAxis("Horizontal");
        // set new vector
        Vector2 playerVelocity = new Vector2(controlThrow* runSpeed, playerRigidBody.velocity.y);

        playerRigidBody.velocity = playerVelocity;
    }

    private void FlipSprite() {


        // if player's velocity is biger than near zero 
        bool playerHasHorizonatalSpeed = Mathf.Abs(playerRigidBody.velocity.x) > Mathf.Epsilon;
        // if player is moving horizontally 
        if (playerHasHorizonatalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(playerRigidBody.velocity.x), 1);
        }
    }


    private void Jump() {
    
        // if player is not touching ground
        if (!playerCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))){return;}

        if (Input.GetButtonDown("Jump")) {
            
            Vector2 jumpVelocity = new Vector2(0f, jumpSpeed);
            playerRigidBody.velocity += jumpVelocity;

        }

    }
}
