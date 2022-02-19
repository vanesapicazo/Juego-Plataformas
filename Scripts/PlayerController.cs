using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Rigidbody2D myRB;
    public float speed;
    bool faceRight = true;
    SpriteRenderer myRenderer;
    Animator myAnimator;

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        myRenderer = GetComponent<SpriteRenderer>();
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");

        if (move < 0 && !faceRight)
        {
            Turn();
        }
        else
        {
            if(move < 0 && faceRight)
            {
                Turn();
            }
        }

        myRB.velocity = new Vector2(move * speed, myRB.velocity.y);
        myAnimator.SetFloat("MoveSpeed", Mathf.Abs(move));
    }

    void Turn()
    {
        myRenderer.flipX = !myRenderer.flipX;
        faceRight = !faceRight;
    }
}
