﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Playermovement : MonoBehaviour
{
    //public float playerSpeed = 1.0f; //Speed of player input
    public float horizonSpeed = 1.0f; //Speed of horizontal auto movement
    public float warpUp = 3.0f; //Position of player changes without physics
    public float warpDown = -3.0f;
    private float playerPosition;
    Lanternsmasher smasher;
    Playerlightcontrol lighter;
    Pressspacetostart gamestart;
    Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        smasher = GetComponent<Lanternsmasher>();
        gamestart = GetComponent<Pressspacetostart>();
        smasher.overEnemy = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector3(horizonSpeed * Time.deltaTime, 0, 0); //Player is contantly moving horizontally
    }

    void Update()
    {
        playerPosition = GameObject.Find("Player").transform.position.y;

        if (Input.GetKeyDown(KeyCode.UpArrow) && (playerPosition != 3)) //!= 3 keeps player from moving too far up (can't believe I didn't think of that sooner)  
        {
            //rb.velocity = new Vector3(horizonSpeed, +playerSpeed, 0);
            //Movement without Physics
            Vector3 position = transform.position;

            position.y += warpUp;
            transform.position = position;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && (playerPosition != -3)) //&& (playerPosition != 0))
        {
            //rb.velocity = new Vector3(horizonSpeed, -playerSpeed, 0);

            //Movement without Physics
            Vector3 position = transform.position;
            position.y -= warpDown;
            transform.position = position;
        }
        if ((Input.GetKeyDown(KeyCode.Space) && (smasher.overEnemy == true)))
        {
            Debug.Log("It works, just popped:" + smasher.collidedWith.gameObject);
            Destroy(smasher.collidedWith.gameObject);
            //lighter.playerPressed = true;
        }
        if ((Input.GetKeyDown(KeyCode.Space)) && (gamestart.preGamestate == true))
        {
            gamestart.preGamestate = false;
        }
    }
}
    //if (Input.GetKeyDown(KeyCode.Space))
      //  {
        //    lighter.playerPressed = true;   
        //}
        //else if (smasher.overEnemy == false)
        //{
            //Debug.Log("Update was the thing you needed to do");
        //}

    //}
//}

