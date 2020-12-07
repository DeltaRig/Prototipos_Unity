﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour
{
    public GameController gameController; // recebe obj no unity

    //[SerializeField]
    private int speed = 4;
    private int MAX_LIFE = 3;
    public int _life = 3;

    private void Awake()
    {
        //gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //vida, identificação de entidades

    }

    // Update is called once per frame
    void Update()
    {
    
    }

	void FixedUpdate() {
        movement();
    }

	private void movement()
    {
        float inputX = Input.GetAxis("Horizontal"); //puxa das config do unity
        float inputY = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(speed * inputX * Time.deltaTime, speed * inputY * Time.deltaTime);
        transform.Translate(movement);
    }

    private void takeDamage(){
        if(_life > 0){
            _life--;
            gameController.playerTakeDamage();
        }
        // fazer morte
	}

    public void receiveLife(int life){
        int aux = _life + life;
        for (int i = _life; i < aux && i < MAX_LIFE; i++)
        {
            gameController.playerReceiveHealth();
            _life++;
        }
	}

	private void OnTriggerEnter2D(Collider2D collision) {
        var tag = collision.gameObject.tag;

        if ( tag == "Damage"){
            takeDamage();
		}
	}

}
