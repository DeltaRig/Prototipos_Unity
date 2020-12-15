using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameController : MonoBehaviour
{
    //variaveis relacionadas ao PLAYER
    private PlayerBehaviour playerBehaviour;
    [SerializeField]
    private Image[] ui_playerLifes = new Image[3];
    [SerializeField]
    private Text ui_playerCoins;
    [SerializeField]
    private Image[] ui_bagCoins = new Image[3];

    //variaveis da sacolinha de dinheiro (bag)
    private float widthBigBagStart = 51.7f;

    //variavel do canvas GameOver
    [SerializeField]
    private GameObject ui_gameOver;




    private void Awake()
    {
        playerBehaviour = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehaviour>(); // pega o código do player
        ui_gameOver.SetActive(false); //utilizado para caso não seja a primeira partida do usuario
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // METODOS PLAYER
    public void playerTakeDamage(bool dead)
    {
        ui_playerLifes[playerBehaviour._life].color = new Color32(255, 3, 0, 45);
        if(dead)
        {
            ui_gameOver.SetActive(true);
        }
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

    public void playerFindCoin(long valueCoin)
    {
        long playerCoins = playerBehaviour.receiveCoin(valueCoin);
        ui_playerCoins.text = playerCoins + "";
        if(playerCoins >= 10)
        {
            if(playerCoins >= 100)
            { // 3 ou mais caracteres
                ui_bagCoins[1].color = new Color32(255, 255, 255, 0);
                ui_bagCoins[2].color = new Color32(255, 255, 255, 255);

                float character = (float)(Math.Floor((Math.Log10(playerCoins))) - 2); // calcula a quantidade de caractes - 2 (para iniciar em 0)
                Debug.Log("Calculei " + character + "caracteres");
                // usa na formula do width o width do bag[1] pois esse mantem o valor inicial

                float width = (character * 20) + widthBigBagStart;
                Debug.Log("Calculei " + width + "para largura");
                ui_bagCoins[2].rectTransform.sizeDelta = new Vector2(width, ui_bagCoins[2].rectTransform.sizeDelta.x);


            }
            else // dois caracteres
            {
                ui_bagCoins[0].color = new Color32(255, 255, 255, 0);
                ui_bagCoins[1].color = new Color32(255, 255, 255, 255);
            }
        }
        //GUIUtility.ExitGUI();

        

    }

}
