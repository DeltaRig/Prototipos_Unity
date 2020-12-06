using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private int speed = 4;
    private bool isCollising = false;

    // Start is called before the first frame update
    void Start()
    {
        //vida, identificação de entidades

    }

    // Update is called once per frame
    void Update()
    {
        movement();

    }

    private void movement()
    {
        float inputX = Input.GetAxis("Horizontal"); //puxa das config do unity
        float inputY = Input.GetAxis("Vertical");

        if (!isCollising)
        {
            Vector2 movement = new Vector2(speed * inputX * Time.deltaTime, speed * inputY * Time.deltaTime);
            transform.Translate(movement);
        }
        
    }
}
