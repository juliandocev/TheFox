using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField]
    Rigidbody2D PlayerBody;
    [SerializeField]
    Collider2D PlayerCollider;
    [SerializeField]
    LayerMask GroundLayer;
    [SerializeField]
    SpriteRenderer Sprite;


    public bool Grounded;
    // SETTINGS
    float RunSpeed;
    float JumpPower;

    // Start is called before the first frame update
    void Start()
    {
        RunSpeed = 5;
        JumpPower = 6;
    }

    // Update is called once per frame
    void Update()
    {
        Grounded = IsGrounded();
        PlayerJump();
        PlayerMove();
        // Never go left from the start position
        if (transform.position.x <= -5)
        {
            transform.position = new Vector3(-5, transform.position.y, transform.position.z);
        }
    }
    void PlayerMove()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            PlayerBody.velocity = new Vector2(RunSpeed, PlayerBody.velocity.y);
            //this.gameObject.transform.localScale = new Vector3(1, 1, 1);
            Sprite.flipX = false;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            PlayerBody.velocity = new Vector2(-RunSpeed, PlayerBody.velocity.y);

            
            //this.gameObject.transform.localScale = new Vector3(-1, 1, 1);
            Sprite.flipX = true;
        }
        // eliminira produlzitelnoto pluzgane pri otpuskane na strelkite
        if (!(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)) && Grounded)
        {
            PlayerBody.velocity = new Vector2(PlayerBody.velocity.x / 5, PlayerBody.velocity.y);
        }
    }
    void PlayerJump()
    {
        if (Input.GetKey(KeyCode.UpArrow) && Grounded)
        {
            PlayerBody.velocity = new Vector2(PlayerBody.velocity.x, JumpPower);
        }
    }

    public bool IsGrounded() 
    {
        // extension of our ray
        float extention = 0.2f;
        // Drow a ray. It is from RaycastHit2D type. We save it in a variable from thqt type.
        RaycastHit2D hit = Physics2D.Raycast(PlayerCollider.bounds.center, Vector2.down, PlayerCollider.bounds.extents.y + extention, GroundLayer);
        Color rayColor = hit.collider != null ? Color.green : Color.red;
        //Visualisation of the ray
        Debug.DrawRay(PlayerCollider.bounds.center, Vector2.down * (PlayerCollider.bounds.extents.y + extention),rayColor);
       // Grounded = hit.collider != null;

        // From the hit object we can take the collider we hit
        // If there is non, we still haven't hit anything
        return hit.collider != null;
    }
}

