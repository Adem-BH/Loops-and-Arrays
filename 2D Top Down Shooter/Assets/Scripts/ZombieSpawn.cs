
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawn : MonoBehaviour
{

    public GameObject Zombie;
    public  int ZombieNumber = 5;
    public int Waves;
    public Transform Player;

    Vector3 RandomCircle (Vector3 center, float radius)
    {

        float ang = Random.value * 360;
        Vector3 Pos;

        Pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        Pos.y = center.y + radius * Mathf.Cos(ang * Mathf.Deg2Rad);

        Pos.z = center.z;

        return Pos;


        
    }

    void Start()
    {

        InvokeRepeating("Spawn", 5f, 5);


    }


    void FixedUpdate()
    {
        if(ZombieNumber < 0)
        {

            ZombieNumber = 0;

        }

        if (ZombieNumber > 0)
        {

            Vector2 Position = RandomCircle(Vector3.zero, Random.Range(13, 20));
            Instantiate(Zombie, Position + Vector2.one, Quaternion.identity);
            ZombieNumber--;



        }

    }
    void Spawn()
    {

        for (int i = 0; i < Waves; i++) {

            Vector2 Position = RandomCircle(Vector3.zero, Player.position.x + 6);
            Instantiate(Zombie, Position + Vector2.one, Quaternion.identity);
            ZombieNumber--;
        }

    }
}


