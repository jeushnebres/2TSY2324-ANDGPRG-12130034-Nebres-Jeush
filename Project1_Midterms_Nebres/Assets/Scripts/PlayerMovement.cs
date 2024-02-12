using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D boxcoll;
    private Animator animator;
    private float dirX = 0;
    private SpriteRenderer sprite;
    [SerializeField]private float moveSpeed = 7;
    [SerializeField]private float jumpForce = 14;
    [SerializeField] private LayerMask jumpableGround;
    private enum MovementState {idle, running, jumping}

    [SerializeField] private AudioSource jumpSoundEffect;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxcoll = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        sprite= GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if(Input.GetButtonDown("Jump") && IsGrounded())
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpSoundEffect.Play();
        }
        UpdateAnimation();

    }

    private void UpdateAnimation()
    {
        MovementState state;
        if (dirX > 0)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1)
        {
            state = MovementState.jumping;
        }
    
        animator.SetInteger("state",(int)state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(boxcoll.bounds.center, boxcoll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

}
