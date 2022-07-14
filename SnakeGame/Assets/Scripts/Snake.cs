using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Snake : MonoBehaviour
{
    // This is a direction variable that will update as keys are pressed to make the snake move
    // default direction is set to right
    private Vector2 direction = Vector2.right;

    // Segments being added to the snake
    private List<Transform> segments = new List<Transform>();
    //refrence to segment prefab
    public Transform segmentPrefab;
    // starting size for snake
    public int size = 3;

    public static Snake instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        RestartGame();

    }

    // This funtion will be called automatically everytime the game is running
    // This will handle the input
    private void Update()
    {
        // checks which arrow key is pressed and based on it changes the snakes direction
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            direction = Vector2.up;
            // Debug.Log("Going Up"); //testing output for when changing direction to up
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow)) {
            direction = Vector2.down;
            // Debug.Log("Going Down!"); //testing output for when changing direction to down
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow)) {
            direction = Vector2.right;
            // Debug.Log("Going to the Right!"); //testing output for when changing direction to right
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            direction = Vector2.left;
            // Debug.Log("Going to the Left"); //testing output for when changing direction to left
        }
    }

    // Move the snake along with its segments
    private void FixedUpdate()
    {
        for (int i = segments.Count -1; i > 0; i--)
        {
            segments[i].position = segments[i - 1].position;
        }
        this.transform.position = new Vector3(
            Mathf.Round(this.transform.position.x) + direction.x, //rounds up the x coordinate so gameboard is represented like a grid
            Mathf.Round(this.transform.position.y) + direction.y,
            0.0f
            );
    }

    //Growing the Snake
    private void Grow()
    {
        Transform segment = Instantiate(this.segmentPrefab);
        segment.position = segments[segments.Count - 1].position; //sets the position of the new object at the end of the snake
        segments.Add(segment); //add the segment to the end of the snake
    }

    //Resetting the Game when colliding with Wall or Snake's segment ("Game Over")
    public void RestartGame()
    {
        for(int i = 1; i < segments.Count; i++)
        {
            Destroy(segments[i].gameObject);
        }
        segments.Clear(); //clears the segments List
        segments.Add(this.transform);

        for (int i = 1; i < this.size; i++)
        {
            segments.Add(Instantiate(this.segmentPrefab));
        }

        this.transform.position = Vector3.zero;
        ScoreManager.instance.ResetScore(); //score will be reset to 0
        Time.timeScale = 1f; // Time will resume 

    }

    // This will check if the object that collided with with player is Food or an Obstacle
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.tag == "Food") // When colliding with Food object, it will grow the snake
        {
            Grow(); //growing the snake by one segment each time food is eaten
            ScoreManager.instance.AddScore(); //100 points will be added to the score

        } else if (other.tag == "Obstacle") { // When colliding with its segments, Player will lose the game
            Debug.Log("collided with Itself"); //testing output for when successful collision with game boundary
            Time.timeScale = 0f; //stops the game from running
            GameOverScreen.instance.GameOverScr(); //runs the game over method to display game over screen

        } else if (other.tag == "Wall") { // When colliding with game area boundries, Player will lose the game
            Debug.Log("Collided into Wall"); //testing output for when successful collision with game boundary
            Time.timeScale = 0f; //stops the game from running
            GameOverScreen.instance.GameOverScr();//runs the game over method to display game over screen
        }
    }
}
