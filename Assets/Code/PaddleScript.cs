using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PaddleScript : MonoBehaviour
{
    public float moveSpeed = 2;
    public Rigidbody2D rb;
    public GameObject gameOverScreen;
    public GameObject gameWinScreen;
    public bool activeBuff;
    private Vector3 defaultPaddle;
    private float countdownTime = 5.0f;
    private float timer;
    void Start()
    {
        defaultPaddle = gameObject.transform.localScale;
        activeBuff = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOverScreen.activeSelf == false && gameWinScreen.activeSelf == false)
        {
            if (activeBuff) {  
                timer-= Time.deltaTime;
                if (timer <= 0) { 
                    RemoveBuffs();
                }
            }
            if (Input.GetKey(KeyCode.LeftArrow) == true)
            {
                rb.velocity = Vector2.left * moveSpeed;
            }
            else if (Input.GetKey(KeyCode.RightArrow) == true)
            {
                rb.velocity = Vector2.right * moveSpeed;
            }
            else
            {
                rb.velocity = Vector2.zero;
            }
        }
        else {
            rb.velocity = Vector2.zero;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall") {
            rb.velocity = Vector3.zero;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "ExtendPaddle") {
            ExtendPaddleBuff();
        }
        Destroy(collision.gameObject);
        activeBuff = true;
        timer = countdownTime;
    }
    private void RemoveBuffs()
    {
        gameObject.transform.localScale = defaultPaddle;
        activeBuff = false;
    }
    private void ExtendPaddleBuff()
    {
        gameObject.transform.localScale = new Vector3(transform.localScale.x * 1.5f, transform.localScale.y, transform.localScale.z);
    }
    
}
