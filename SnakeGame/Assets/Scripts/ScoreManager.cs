using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public Text points; //allows the use of Text object located in Unity UI
    public Text highScoreText; //allows the use of High Schore Text object in Unity UI

    public int score = 0; //initialize the score to value of 0
    public int highScore = 0; //initializes the high score value to 0
    public int gameOverScore = 0; //this value to save score and display during game over screen.

    private void Awake() 
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        highScore = PlayerPrefs.GetInt("hiscore", 0);
        points.text = "SCORE - " + score.ToString(); //Putting the score label on the top of the game board
        highScoreText.text = "HIGH SCORE - " + highScore.ToString(); //Putting the highscore on the top of the game board
    }
    
    public void AddScore() //adding 100 points to the total score
    {
        score += 100; //add the score
        points.text = "SCORE - " + score.ToString(); //display the updated score
        gameOverScore = score; //saving the score to display on the game over screen
        if (highScore < score) //checks the previously saved highscore against current score
        {
            PlayerPrefs.SetInt("hiscore", score); //if the current score is higher than previous high score then it will update the variable
        }

    }

    public void ResetScore() //resetting the score back to 0 when game over occurs.
    {
        score = 0; //settin the score back to 0
        points.text = "SCORE - " + score.ToString(); //displaying the score on game UI
        gameOverScore = score; // gameover score variable is also updated to 0 whenever game resets.
    }

   
}
