using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericPlayer : MonoBehaviour
{
    protected Rigidbody2D playerRigidBody;
    protected Collider2D playerCollider;


    // configuration parameters
    [SerializeField] protected float runSpeed = 10f;
    [SerializeField] private float jumpSpeed = 15f;
    [SerializeField] protected GameObject laserPrefab;
    [SerializeField] private float laserSpeed = 10f;
    [SerializeField] private float laserDistance = 1f; // distance laser spawns from sprite
    public string test = "boop";

    // health parameters
    public HealthSystem health;
    [SerializeField] private int damage = 10;
    public int ammo;



    // Called when funciton is initialized
    void Awake()
    {
        health = new HealthSystem();
    }

    // Start is called before the first frame update
    protected void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();

    }

    protected void Update()
    {
    }





    public float GetHealth() {

        return health.GetHealth();
    }




    // damage
    public void DamagePlayer() {
        // damage the player
        health.Damage(damage);
        Debug.Log(health.GetHealth());
    }


    // Player Controls
    protected void Fire()
    {
        if (ammo > 1)
        {
            ammo--;
            float direction = transform.localScale.x;
            // starting post of laser
            Vector2 laserPos = new Vector2(transform.position.x + (laserDistance * direction),
            transform.position.y);
            // create laser
            GameObject laser = Instantiate(
                laserPrefab,
                laserPos,
                Quaternion.identity) as GameObject;
            // give velocity (direction facing * speed)
            float currentSpeed = laserSpeed * direction;
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(currentSpeed, 0);
        }
    }


    protected void FlipSprite()
    {

        // if player's velocity is biger than near zero 
        bool playerHasHorizonatalSpeed = Mathf.Abs(playerRigidBody.velocity.x) > Mathf.Epsilon;
        // if player is moving horizontally 
        if (playerHasHorizonatalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(playerRigidBody.velocity.x), 1);
        }
    }


    protected void Jump()
    {

    // if player is not touching ground
    if (!playerCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))) { return; }

     Vector2 jumpVelocity = new Vector2(0f, jumpSpeed);
            playerRigidBody.velocity += jumpVelocity;
    }

}
