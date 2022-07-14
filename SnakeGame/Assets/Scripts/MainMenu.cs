using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject controlMenuUI; //gameObject for How to Play menu
    public GameObject mainMenuUI; //gameobject for main menu

    //Play button
    public void Play()
    {
        Debug.Log("Playing the Game...");
        SceneManager.LoadScene("GameScene");
    }

    //How To Play Button
    public void HowToPlay()
    {
        Debug.Log("Going to how to play screen...");
        controlMenuUI.SetActive(true); //loading the how to play screen
        mainMenuUI.SetActive(false); //unload the main menu screen

    }

    //This method is for the buttons on the How To play screen.
    public void BackToMainMenu()
    {
        Debug.Log("Going Back To Main Menu...");
        controlMenuUI.SetActive(false); //unloads the how to play screen
        mainMenuUI.SetActive(true); //loads the main menu screen
    }

    //This will quit the game 
    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit(); //quit the whole application
    }
}
