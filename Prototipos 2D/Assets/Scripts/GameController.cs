using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private PlayerBehaviour player;
    public Image[] ui_playerLifes = new Image[3];

    // Start is called before the first frame update
    void Start()
    {
        // pega o código do player:
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // METODOS PLAYER
    private void playerTakeDamage(){
        if(player.life > 0){
            ui_playerLifes[player.life].color = new Color32(255, 3, 0, 45);
        }
	}

}
