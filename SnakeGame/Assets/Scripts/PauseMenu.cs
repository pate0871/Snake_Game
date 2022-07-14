using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    //variable that will keep track of whether the game is paused or not
    public static bool gameIsPaused = false; //initial value is false because the game wont be paused when started

    public GameObject pauseMenuUI; //game object for pause menu screen

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            if (gameIsPaused) //checks the boolean variable's value, if true then runs the loop
            {
                ResumeGame(); //runs the ResumeGame() Method

            } else //if false then runs the current method
            {
                PauseGame(); //runs the method that will pause the game
        
            }
        }
    }

    //Method to Resume the game when it is paused
    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false); //This will disable the pause menu UI
        Time.timeScale = 1f; //Game will resume
        gameIsPaused = false; //setting boolean value to resume the game
    }

    //Method to pause the game when a button is clicked 
    void PauseGame()
    {
        pauseMenuUI.SetActive(true); //This will display the pause menu UI
        Time.timeScale = 0f; //this will freeze the game
        gameIsPaused = true; //setting boolean value to pause the game
    }

    //Method to call if player wants to go back to main menu screen
    public void LoadMainMenu()
    {
        Time.timeScale = 1f; //unfreeze the game
        SceneManager.LoadScene("Menu"); //display the menu screen for the user
        Debug.Log("Main Menu Screen!!"); //should output in the console that main menu button was clicked
    }
}
