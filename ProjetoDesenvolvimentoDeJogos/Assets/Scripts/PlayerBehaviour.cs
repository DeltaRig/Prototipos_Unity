using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour
{
    public GameController gameController; // recebe obj no unity

    public float jumpForce = 7f;
    private int _speed = 8;
    private int MAX_LIFE = 3;
    public int _life = 3;

    [SerializeField]
    private long playerCoin;
    private bool _isGrounded;

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        playerCoin = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        //vida, identificação de entidades
        _rigidbody = GetComponent<Rigidbody2D>();
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
        Move();
        
        //_rigidbody.velocity = new Vector2(speed, _rigidbody.velocity.y);
    }

    private void Move()
    {
        transform.Translate(new Vector2(_speed * Time.deltaTime, 0));
    }

    private void TakeDamage()
    {
        if (_life > 0)
        {
            _life--;
            gameController.PlayerTakeDamage(false);
        } 
        else
        {
            gameController.PlayerTakeDamage(true); //dead
        }
        // fazer morte
    }

    public void ReceiveLife(int life)
    {
        int aux = _life + life;
        for (int i = _life; i < aux && i < MAX_LIFE; i++)
        {
            gameController.PlayerReceiveHealth();
            _life++;
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

        if (tag == "Damage")
            TakeDamage();
    }

}
