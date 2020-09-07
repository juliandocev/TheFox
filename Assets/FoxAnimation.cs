using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxAnimation : MonoBehaviour
{
    //STATE MAP
    //1. IDLE
    //2. RUN
    //3. JUMP
    //4. FALL
    //5. CROUCH
    //6. HURT
    //7. CLIMB


    [SerializeField]
    Animator PlayerAnimator;
    [SerializeField]
    Rigidbody2D PlayerBody;



    bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = GameObject.Find("Fox").GetComponent<PlayerMovement>().Grounded;
        IsIdle();
        IsRunning();
        IsJumping();
    }

    void IsIdle()
    {
        if (!(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)) && isGrounded)
        {
            PlayerAnimator.SetInteger("State", 1);
        }
    }
    void IsRunning()
    {
        if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)) && (isGrounded))
        {
            PlayerAnimator.SetInteger("State", 2);
        }
    }
    void IsJumping()
    {
       // bool isGrounded = GameObject.Find("Fox").GetComponent<PlayerMovement>().Grounded;
        if (!isGrounded && PlayerBody.velocity.y>0)
        {
            PlayerAnimator.SetInteger("State", 3);
        }
        else if (!isGrounded && PlayerBody.velocity.y < 0)
        {
            PlayerAnimator.SetInteger("State", 4);
        }
    }
}
    

