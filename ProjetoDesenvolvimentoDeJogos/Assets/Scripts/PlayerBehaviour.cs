﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour
{
    const int MaxLife = 3;
    
    private GameController _gameController; 

    public float jumpForce = 7f; // to change on unity
    private float _speed = 10;
    public int life = 3;

    [SerializeField]
    private long playerCoin;
    private bool _isGrounded;

    private Rigidbody2D _rigidbody;

    private float _positionTemp;
    private float _timeDamege;
    private float WaitTimeDamage = 0.2f;

    private void Awake()
    {
        _gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        playerCoin = 0;
        _timeDamege = WaitTimeDamage;
    }
 
    // Start is called before the first frame update
    void Start()
    {
        //vida, identificação de entidades
        _rigidbody = GetComponent<Rigidbody2D>();
        _positionTemp = _rigidbody.position.x - 1;
    }
    
    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.CapsuleCast(transform.position, new Vector2(1f, .4f), CapsuleDirection2D.Vertical, 0, Vector2.down, .7f);
        _isGrounded = hit.collider != null;
        
        if (_isGrounded && Input.GetKeyDown(KeyCode.Space))
            _rigidbody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
    }

    void FixedUpdate()
    {
        _speed += .0001f;
        Move();

        _timeDamege += Time.deltaTime;
        
        if ( _rigidbody.position.x == _positionTemp)
        {
            if(_timeDamege > WaitTimeDamage)
            {
                _timeDamege = 0;
                TakeDamage();
            }
        }
        
        _positionTemp = _rigidbody.position.x;
        //_rigidbody.velocity = new Vector2(speed, _rigidbody.velocity.y);
    }

    private void Move()
    {
        transform.Translate(new Vector2(_speed * Time.deltaTime, 0));
    }

    private void TakeDamage()
    {
        if (life > 0)
        {
            life--;
            _gameController.PlayerTakeDamage(false);
        } 
        else
        {
            _gameController.PlayerTakeDamage(true); //dead
        }
        // fazer morte
    }

    public void ReceiveLife(int life)
    {
        int aux = this.life + life;
        for (int i = this.life; i < aux && i < MaxLife; i++)
        {
            _gameController.PlayerReceiveHealth();
            this.life++;
        }
    }

    public long ReceiveCoin(long valueCoin)
    {
        playerCoin += valueCoin;
        return playerCoin;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var tag = collision.gameObject.tag;

        if (tag == "Damage"){
            if (_timeDamege > WaitTimeDamage)
            {
                _timeDamege = 0;
                TakeDamage();
            }
        }
    }
}
