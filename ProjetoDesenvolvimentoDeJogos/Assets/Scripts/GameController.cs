using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;


public class GameController : MonoBehaviour
{
    //variaveis relacionadas ao PLAYER
    private PlayerBehaviour _playerBehaviour;
    [SerializeField]
    private Image[] uiPlayerLifes = new Image[3];
    [SerializeField]
    private Text uiPlayerCoins;
    [SerializeField]
    private Image[] uiBagCoins = new Image[3];
    [SerializeField]
    private Text uiPlayerResult;

    //variaveis da sacolinha de dinheiro (bag)
    private float _widthBigBagStart = 51.7f;

    //variavel do canvas GameOver
    [SerializeField]
    private GameObject uiGameOver;

    private void Awake()
    {
        _playerBehaviour = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehaviour>(); // pega o código do player
        uiGameOver.SetActive(false); //utilizado para caso não seja a primeira partida do usuario
    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        _gameTime += Time.deltaTime;
    }

    // METODOS PLAYER
    public void PlayerTakeDamage(bool dead)
    {
        uiPlayerLifes[_playerBehaviour.life].color = new Color32(255, 3, 0, 45);
        if(dead)
        {
            uiPlayerResult.text = uiPlayerCoins.text + " coins\n"; // + _gameTime + " seconds";
            uiGameOver.SetActive(true);
        }
	}

    public void PlayerReceiveHealth()
    { 
        uiPlayerLifes[_playerBehaviour.life].color = new Color32(255, 255, 255, 255);
    }

    //METODOS HEALTH POTION
    public void PlayerFindPotion(int life)
    {
        _playerBehaviour.ReceiveLife(life);
    }

    public void PlayerFindCoin(long valueCoin)
    {
        long playerCoins = _playerBehaviour.ReceiveCoin(valueCoin);
        uiPlayerCoins.text = playerCoins + "";
        if(playerCoins >= 10)
        {
            if(playerCoins >= 100)
            { // 3 ou mais caracteres
                uiBagCoins[1].color = new Color32(255, 255, 255, 0);
                uiBagCoins[2].color = new Color32(255, 255, 255, 255);

                float character = (float)(Math.Floor((Math.Log10(playerCoins))) - 2); // calcula a quantidade de caractes - 2 (para iniciar em 0)
                Debug.Log("Calculei " + character + "caracteres");
                // usa na formula do width o width do bag[1] pois esse mantem o valor inicial

                float width = (character * 20) + _widthBigBagStart;
                Debug.Log("Calculei " + width + "para largura");
                uiBagCoins[2].rectTransform.sizeDelta = new Vector2(width, uiBagCoins[2].rectTransform.sizeDelta.x);
            }
            else // dois caracteres
            {
                uiBagCoins[0].color = new Color32(255, 255, 255, 0);
                uiBagCoins[1].color = new Color32(255, 255, 255, 255);
            }
        }
        //GUIUtility.ExitGUI();
    }

}
