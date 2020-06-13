using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMouvement : MonoBehaviour
{
    public float Speed;
    public bool destroy = false;

    Vector2 MovePosition;
    Vector2 MousePos;

    public GameObject Bullet;
    public Transform FirePoint;

    public Behaviour[] DisableOnDeath;
    GameObject[] Zombies;

    public Image HealthBar;

    public float  Health = 100;

   


    private Rigidbody2D rb;


    

    void Start()
    {

        rb = GetComponent<Rigidbody2D>();

        

    }

  
    void Update()
    {


        Shoot();

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Zombie")
        {
            Health -= collision.gameObject.GetComponent<Zombie>().Damage;

            HealthBar.fillAmount = Health / 100f;

            
            if (Health <= 0){
                Health = 0;
                Die();
            }
        }
    }

    void FixedUpdate()

    {



        Zombies = GameObject.FindGameObjectsWithTag("Zombie");


        if (destroy)
        {

            foreach (GameObject i in Zombies)
            {

                Destroy(i);
                
            }

            destroy = false;

        }
        

        MovePosition.x = Input.GetAxisRaw("Horizontal");
        MovePosition.y = Input.GetAxisRaw("Vertical");
        rb.MovePosition(rb.position + MovePosition * Speed * Time.deltaTime);



        MousePos = Camera.main.ScreenPointToRay(Input.mousePosition).origin;
        Vector2 Dir = MousePos - rb.position;

        float angle = Mathf.Atan2(Dir.y, Dir.x) * Mathf.Rad2Deg;
        rb.rotation = angle;


        
       

    }

    public void Shoot()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(Bullet, FirePoint.position, FirePoint.rotation);
         
        }


    }

    public void Die()
    {
        GetComponent<Text>().TimeStart = false;
        SceneManager.LoadScene(1);
        foreach (Behaviour i in DisableOnDeath)
        i.enabled = false;

    }

    private void Destroy()
    {
        foreach (GameObject i in Zombies)
        {

            Destroy(i);

        }
    }
}

