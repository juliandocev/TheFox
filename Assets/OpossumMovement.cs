using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpossumMovement : MonoBehaviour
{
    [SerializeField]
    private Transform ObjectToFallow;
    [SerializeField]
    private float MinDistance;
    [SerializeField]
    private float Speed;
    private Rigidbody2D OpossumBody;
    private Animator OpossumAnimator;
    

    // Start is called before the first frame update
    void Start()
    {
        OpossumBody = transform.gameObject.GetComponent<Rigidbody2D>();
        OpossumAnimator = transform.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        FallowObject();
    }

    void FallowObject()
    {
        if (Vector3.Distance(transform.position, ObjectToFallow.transform.position) <= MinDistance)
        {
            // Direction
            float direction = 1f;
            // set sprite direction
            transform.localScale = new Vector3(-1, 1, 1);
            if(transform.position.x > ObjectToFallow.transform.position.x)
            {
                direction = -1f;
                transform.localScale = Vector3.one;

            }

            // Move
            OpossumBody.velocity = new Vector2(Speed * direction, OpossumBody.velocity.y);

            // Set animation
            OpossumAnimator.SetInteger("State", 2);
        }
        else
        {
            OpossumAnimator.SetInteger("State", 1);
        }
    }
}
