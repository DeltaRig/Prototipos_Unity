using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    public void PlayGame(){
        SceneManager.LoadScene(1); //prototipo
    }

    public void QuitGame()
    {
        Debug.Log("QUIT"); // não é possovel testar de outra forma pelo Unity (sem build)
        Application.Quit(); // onde eu boto o botão de quit?
    }

}
