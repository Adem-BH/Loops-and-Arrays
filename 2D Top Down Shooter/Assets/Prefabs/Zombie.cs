using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public float Speed;
    private Transform Player;


    public bool Collided = false;

    private Rigidbody2D rb;




    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "MainCamera")
        {
            Collided = true;
           

        }
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        Player = GameObject.Find("Player").GetComponent<Transform>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (Collided == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, Player.position, Speed * Time.deltaTime);

            Vector2 Dir = Player.position - transform.position;

            float angle = Mathf.Atan2(Dir.y , Dir.x) * Mathf.Rad2Deg;

            rb.rotation = angle;



        }

    }
}
