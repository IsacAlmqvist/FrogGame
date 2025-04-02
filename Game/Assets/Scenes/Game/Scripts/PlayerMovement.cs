using UnityEditor.Callbacks;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 8f;
    private Rigidbody2D rb;
    private bool bounce;
    private Vector2 upForce = new Vector2(0, 10); 
    private bool isFalling;
    private float bounceForce = 13.5f;
    private SpriteSwitch spriteSwitch;
    private float bounceMultiplier = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;

        spriteSwitch = GetComponent<SpriteSwitch>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(horizontalInput * speed, rb.linearVelocity.y);

        isFalling = rb.linearVelocity.y <= 0;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject platform = collision.gameObject;

        if(isFalling && platform.CompareTag("Ground")) {

            SpriteRenderer otherSR = collision.gameObject.GetComponent<SpriteRenderer>();
            if(otherSR.sprite.name == "bounce") {
                bounceMultiplier = 2.5f;
            }else if(otherSR.sprite.name == "rock") {
                platform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                platform.GetComponent<BoxCollider2D>().enabled = false;
            }

            rb.linearVelocity = new Vector2(rb.linearVelocity.x, bounceForce * bounceMultiplier);
            bounceMultiplier = 1f;
            
            spriteSwitch.sprite2();
            spriteSwitch.Invoke("sprite1", 0.5f);
        }
    }

    // void OnCollisionExit2D(Collision2D collision)
    // {
    //     if(collision.gameObject.CompareTag("Ground")) {
    //         bounce = false;
    //     }
    // }

}
