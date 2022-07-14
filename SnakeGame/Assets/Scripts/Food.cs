using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public BoxCollider2D gameArea;

    private void Start()
    {
        // Calling the method to place food in random area of the game grid
        RandomPosition();
    }

    // Moves the food object around the game area specified with bound variable
    private void RandomPosition()
    {
        // Setting boundaries for game area object
        Bounds bounds = this.gameArea.bounds;

        // Choosing a random postion for Food object with max and mix x and y axis
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        // This places the food into a random position obtained above
        // Rouding it to whole number for both x and y position and z is set to 0
        this.transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);
    }

    // This method will get called automatically when the objects collide
    // Will also respawn food object in another random positon
    private void OnTriggerEnter2D(Collider2D other)
    {
        // This will check if the object that collided with food is actually Snake head
        // If its true then it will respawn food object in another area again
        if (other.tag == "Player")
        {
            RandomPosition();
        }
    }
}
