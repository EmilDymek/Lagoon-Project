using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private Vector2 playerDirection;
    private Vector2 movement;
    private Vector3 mousePos;
    private Vector3 firePointPos;
    
    private Rigidbody2D rb;

    public Vector3 playerPosition;
    public float playerMoveSpeed;
    public Transform firePoint1;
    public Transform crosshair;
    public GameObject grenade;
    public LineRenderer lineRend;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        lineRend.enabled = false;
    }


    void Update()
    {
        GetInput();
    }

    void FixedUpdate()
    {
        //GetInput();
        TurnFirepoint1();
        MovePlayer();
        playerPosition = this.transform.position;
    }

    void GetInput()
    {
        //Movement Inputs
        playerDirection = Vector2.zero;                                         //Zeroes the cameras direction
        if (Input.GetKey(KeyCode.W))                                            //Checks if W is being pressed
        {
            playerDirection += Vector2.up;                                      //Sets direction to up if W is being pressed
        }
        if (Input.GetKey(KeyCode.A))                                            //Checks if A is being pressed
        {
            playerDirection += Vector2.left;                                    //Sets direction to left if A is being pressed
        }
        if (Input.GetKey(KeyCode.S))                                            //Checks if S is being pressed
        {
            playerDirection += Vector2.down;                                    //Sets direction to down if S is being pressed
        }
        if (Input.GetKey(KeyCode.D))                                            //Checks if D is being pressed
        {
            playerDirection += Vector2.right;                                   //Sets direction to right if D is being pressed
        }

        //Attack Inputs
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            StartCoroutine(RaycastShoot());
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            ThrowGrenade();
        }
    }

    IEnumerator RaycastShoot()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(firePoint1.position, firePoint1.right);      //Uses raycast to draw a line from the player (fire point) in the direction of the gun
        Debug.Log(hitInfo);
        if (hitInfo && hitInfo.collider.tag != "Player" && hitInfo.collider.tag != "Grenade")                                        //If the raycast detects something that isn't tagged as player 
        {
            //EnemyAI Enemy = HitInfo.transform.GetComponent<EnemyAI>();            //Get the Enemy game component
            //if (Enemy != null)                                                                  //If an enemy is detected
            //{
            //    Enemy.Damage(GM.PlayerGunDamage);                                           //Call Takedamage function in the enemy script and send the Gun Damage variable
            //}
            //Instantiate(ImpactEffect, HitInfo.point, Quaternion.identity);                      //Make an Impact effect, Where the bullet is, With locked rotation
            lineRend.SetPosition(0, firePoint1.position);                                      //Sets first point of the line on the fire point position
            lineRend.SetPosition(1, hitInfo.point);                                             //Sets second point of the line at the detected object
        }
        else
        {
            lineRend.SetPosition(0, firePoint1.position);                                      //Sets first point of the line on the fire point position
            lineRend.SetPosition(1, firePoint1.position + firePoint1.right * 100);            //Sets the second point of the line 100 units away from the firepoint in the direction of the gun
        }
        lineRend.enabled = true;                                                                //Draw the line
        yield return new WaitForSeconds(0.02f);                                                 //Wait for 0.02 seconds
        lineRend.enabled = false;                                                               //Hide the line
    }

    void MovePlayer()
    {
        rb.velocity = playerDirection * playerMoveSpeed * Time.deltaTime;

        // Placeholders for audio when walking, taken from WotBB
        //if (playerDirection != Vector2.zero)
        //{
        //    if (soundTimer <= 0)
        //    {
        //        if (soundAlternator)
        //        {
        //            FindObjectOfType<AudioManager>().Play("Player Walk1");
        //            soundAlternator = false;
        //            soundTimer = soundTimerReset;
        //        }
        //        else
        //        {
        //            FindObjectOfType<AudioManager>().Play("Player Walk2");
        //            soundAlternator = true;
        //            soundTimer = soundTimerReset;
        //        }
        //    }
        //}
    }

    void TurnFirepoint1()
    {
        mousePos = Input.mousePosition;                                         //Updates the variable and stores the current mouse position
        firePointPos = Camera.main.WorldToScreenPoint(transform.position);      //Updates the variable and stores the gun position
        mousePos.x = mousePos.x - firePointPos.x;                               //Adjusts the variable
        mousePos.y = mousePos.y - firePointPos.y;                               //  --//--

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;      //Calculates the Rotation of the gun
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));        //Rotates the gun
    }

    void ThrowGrenade()
    {
        Instantiate(grenade, firePoint1.position, firePoint1.rotation);         //Instantiates a grenade
    }
}
