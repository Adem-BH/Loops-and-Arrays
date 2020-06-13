using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public float Speed;
    public float Health;
    public float Damage;
    private Transform Player;


    public bool Collided = false;

    private Rigidbody2D rb;




    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "MainCamera")
        {
            Collided = true;


        }

        if (collision.gameObject.tag == "Bullet")
        {

            Health -= collision.gameObject.GetComponent<Bullet>().Damage;
            collision.gameObject.GetComponent<Animator>().SetBool("boom", true);
            Destroy(collision.gameObject);

            if (Health <= 0)
            {

                Health = 0;
                Destroy(gameObject);

            }

        }
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        Player = GameObject.Find("Player").GetComponent<Transform>();

        Health = Random.Range(50, 200);
        Speed = Random.Range(2, 5);
        Damage = Random.Range(20, 50);

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (Collided == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, Player.position, Speed * Time.deltaTime);

            Vector2 Dir = Player.position - transform.position;

            float angle = Mathf.Atan2(Dir.y, Dir.x) * Mathf.Rad2Deg;

            rb.rotation = angle;



        }

    }
}
    

