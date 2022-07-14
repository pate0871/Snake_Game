using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public Text scoreText; //allows the use of Text object located in Unity UI
    public GameObject gameOverUI; //game object for Game over screen

    public static GameOverScreen instance;

    private void Awake()
    {
        instance = this;
    }

    //method that will display the whole game over screen when player dies
    public void GameOverScr()
    {
        gameOverUI.SetActive(true); //loading the game over scene
        scoreText.text = "SCORE - " + ScoreManager.instance.gameOverScore.ToString(); //Player's score is shown

    }

    // When restart button is selected on the game over screen
    public void RestartButton()
    {
        SceneManager.LoadScene("GameScene"); //loads the game scene
        Snake.instance.RestartGame(); //restarts the game, resetting the score

    }

    // When main menu button is selected on game over screen
    public void MainMenuButton()
    {
        SceneManager.LoadScene("Menu"); //loads the main menu screen

    }
}
