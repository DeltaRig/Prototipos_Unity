using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour
{
    private GameController gameController; // recebe obj no unity

    private int TOTAL_HEALTH = 1; // quantidade de vida que a poção da

    private void Awake()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var tag = collision.gameObject.tag;

        if (tag == "Player")
        {
            gameController.playerFindPotion(TOTAL_HEALTH);
            Destroy(this.gameObject);
        }
            
    }

    
}
