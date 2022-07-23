using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameController : MonoBehaviour
{
    //variaveis relacionadas ao PLAYER
    private PlayerBehaviour _playerBehaviour;
    [SerializeField]
    private Image[] ui_playerLifes = new Image[3];
    [SerializeField]
    private Text _uiPlayerCoins;
    [SerializeField]
    private Image[] _uiBagCoins = new Image[3];

    //variaveis da sacolinha de dinheiro (bag)
    private float _widthBigBagStart = 51.7f;

    //variavel do canvas GameOver
    [SerializeField]
    private GameObject _uiGameOver;

    private void Awake()
    {
        _playerBehaviour = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehaviour>(); // pega o código do player
        _uiGameOver.SetActive(false); //utilizado para caso não seja a primeira partida do usuario
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // METODOS PLAYER
    public void PlayerTakeDamage(bool dead)
    {
        ui_playerLifes[_playerBehaviour.life].color = new Color32(255, 3, 0, 45);
        if(dead)
        {
            _uiGameOver.SetActive(true);
        }
	}

    public void PlayerReceiveHealth()
    { 
        ui_playerLifes[_playerBehaviour.life].color = new Color32(255, 255, 255, 255);
    }

    //METODOS HEALTH POTION
    public void PlayerFindPotion(int life)
    {
        _playerBehaviour.ReceiveLife(life);
    }

    public void PlayerFindCoin(long valueCoin)
    {
        long playerCoins = _playerBehaviour.ReceiveCoin(valueCoin);
        _uiPlayerCoins.text = playerCoins + "";
        if(playerCoins >= 10)
        {
            if(playerCoins >= 100)
            { // 3 ou mais caracteres
                _uiBagCoins[1].color = new Color32(255, 255, 255, 0);
                _uiBagCoins[2].color = new Color32(255, 255, 255, 255);

                float character = (float)(Math.Floor((Math.Log10(playerCoins))) - 2); // calcula a quantidade de caractes - 2 (para iniciar em 0)
                Debug.Log("Calculei " + character + "caracteres");
                // usa na formula do width o width do bag[1] pois esse mantem o valor inicial

                float width = (character * 20) + _widthBigBagStart;
                Debug.Log("Calculei " + width + "para largura");
                _uiBagCoins[2].rectTransform.sizeDelta = new Vector2(width, _uiBagCoins[2].rectTransform.sizeDelta.x);


            }
            else // dois caracteres
            {
                _uiBagCoins[0].color = new Color32(255, 255, 255, 0);
                _uiBagCoins[1].color = new Color32(255, 255, 255, 255);
            }
        }
        //GUIUtility.ExitGUI();
    }

}
