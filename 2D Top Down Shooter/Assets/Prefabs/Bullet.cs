using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float BulletSpeed;
    public float Damage = 30;
    public GameObject ZombieSpawner;

    private Rigidbody2D rb;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "MainCamera")
        {
           
            Destroy(gameObject);

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
