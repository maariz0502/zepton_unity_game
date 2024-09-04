using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour

{
    public LogicScript logic;
    public BlockScript blockScript;

    public int numberOfBlocks = 80;
    public float speed = 2;
    public Rigidbody2D rb;
    Vector3 lastVelocity;
    public AudioSource audSrc;
    // Start is called before the first frame update
    void Start()
    {
        rb.AddForce(new Vector2(9.8f * 25f, 9.8f * 25f));
        audSrc = GetComponent<AudioSource>();  
    }

    // Update is called once per frame
    void Update()
    {
        lastVelocity = rb.velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var speed = lastVelocity.magnitude;
        var direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);

        rb.velocity = direction * Mathf.Max(speed, speed);
        if(collision.gameObject.tag == "Block")
        { //hits blocks
            audSrc.Play();
            --numberOfBlocks;
            collision.gameObject.SetActive(false);
            blockScript.DropItem(collision.transform.position.x, collision.transform.position.y);
            if(numberOfBlocks == 0)
            {
                logic.winGame();
                rb.velocity = Vector2.zero;
                rb.gravityScale = 0f;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Floor") {
            Destroy(gameObject);
            logic.GameOver();
        }   

    }
}
