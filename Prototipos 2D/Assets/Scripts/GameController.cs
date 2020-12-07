using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    //variaveis relacionadas ao PLAYER
    private PlayerBehaviour playerBehaviour;
    public Image[] ui_playerLifes = new Image[3];



    private void Awake()
    {
        playerBehaviour = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehaviour>(); // pega o código do player
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // METODOS PLAYER
    public void playerTakeDamage()
    {
        ui_playerLifes[playerBehaviour._life].color = new Color32(255, 3, 0, 45);
	}

    public void playerReceiveHealth()
    { 
        ui_playerLifes[playerBehaviour._life].color = new Color32(255, 255, 255, 255);
    }

    //METODOS HEALTH POTION
    public void playerFindPotion(int life)
    {
        playerBehaviour.receiveLife(life);

    }

}
