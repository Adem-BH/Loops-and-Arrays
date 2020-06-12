using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float BulletSpeed;
    public GameObject ZombieSpawner;

    private Rigidbody2D rb;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "MainCamera")
        {
           
            Destroy(gameObject);

        }

      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    
        
        {
        if (collision.gameObject.tag == "Zombie")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
            ZombieSpawner.GetComponent<ZombieSpawn>().ZombieNumber++;
         

           

        }
    }

    

    void Start()
    {
        ZombieSpawner = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * BulletSpeed;

        
       
    }


    void FixedUpdate()
    {

    }
}
