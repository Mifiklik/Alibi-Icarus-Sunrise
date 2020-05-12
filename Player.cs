using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    public Rigidbody2D RigBud;
    public float movespeed;

    void Start()
    {
        RigBud = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            RigBud.velocity = new Vector2(-movespeed , RigBud.velocity.y);
            Debug.Log("moving left");
        }

        if (Input.GetKey(KeyCode.D))
        {
            RigBud.velocity = new Vector2(movespeed , RigBud.velocity.y);
            Debug.Log("moving right");
        }

        if (Input.GetKey(KeyCode.W))
        {
            RigBud.velocity = new Vector2(RigBud.velocity.x, movespeed);
            Debug.Log("moving up");
        }

        if (Input.GetKey(KeyCode.S))
        {
            RigBud.velocity = new Vector2(RigBud.velocity.x, -movespeed);
            Debug.Log("moving up");
        }
    } // просто движение персонажа на WASD
}
