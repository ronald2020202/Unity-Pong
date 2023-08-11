using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public int score1 = 0;
    public int score2 = 0;
    public int player;
    public float moveSpeed = 5f;

    public Text text2;
    public Text text;

    private Rigidbody2D rb;

    Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if(player == 3)
        {
            rb.velocity = new Vector2(moveSpeed, 0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(player != 3)
        {
            movement.y = Input.GetAxisRaw("Vertical" + player);
        }
        else
            text.text = score2 + " " + score1;
            if(score2 == 5)
            {
                text2.text = "Player One Wins";
                score1 = 0;
                score2 = 0;
            }
            if(score1 == 5)
            {
                text2.text = "Player Two Wins";
                score1 = 0;
                score2 = 0;

            }
    }

    void FixedUpdate()
    {
        if(player != 3)
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
    
    void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.gameObject.tag == "Wall")
        {
            score1++;
            rb.position = new Vector2(0,0);
            rb.velocity = new Vector2(moveSpeed, 0);
        }
        if(collision.gameObject.tag == "Wall2")
        {
            score2++;
            rb.position = new Vector2(0,0);
            rb.velocity = new Vector2(-moveSpeed, 0);
        }
    }

}
