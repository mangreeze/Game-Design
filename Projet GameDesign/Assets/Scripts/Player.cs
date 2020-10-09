using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State
{
    Alive,
    Immovable,
    Dead
}

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    private PlayerMind pm;
    public float speed = 5f;
    private bool facingRight;

    public float jumpForce = 2;
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius = 0.1f;
    public LayerMask ground;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pm = GetComponent<PlayerMind>();
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    void Facing(float move)
    {
        if (facingRight == false && move > 0)
        {
            Flip();
        } else if (facingRight == true && move < 0)
        {
            Flip();
        }
    }

    void CheckInput()
    {
        float xMove = Input.GetAxis("Horizontal") * speed;
        rb.velocity = new Vector2(xMove, rb.velocity.y);
        Facing(xMove);
        Jump();
    }

    void CheckGround()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, ground);
    }

    // Update is called once per frame
    void Update()
    {
        CheckGround();
        CheckInput();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Collectible collectible = collision.GetComponent<Collectible>();
        if (collectible)
        {
            collectible.Interact();
        }
        if (collision.tag == "SafeArea")
        {
            pm.SetDarkVariable(false);
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "SafeArea")
        {
            pm.SetDarkVariable(true);
        }
    }
}
