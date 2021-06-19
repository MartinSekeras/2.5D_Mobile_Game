using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    /* Specifies speed variable. */
    // public float PCSpeed;
    public float MobileSpeed;

    /* Specifies our current health variable and our 4 bools for movement controls. */
    public int currentHealth;
    public bool moveForward;
    public bool moveBack;
    public bool moveLeft;
    public bool moveRight;

    /* GameObject enemy is used for our spawner. 
     * Object stored here will be spawned in accordance with our mechanics below. */
    public GameObject enemy;

    /* Below we can find our respawn timer variable for enemy spawning. 
     * This can be changed in inspector under Player model.
     * Specifies how many seconds the function waits before spawning another enemy at random location.*/
    public float respawnTimer;

    /* Creates a public reference to our health Slider so we can call it's function and set it's value to our health value. */
    public HealthSlider healthSlider;

    void Start()
    {
        /* Starts a coroutine of our IEnumerator function for enemy spawning mechanism. */
        StartCoroutine(EnemySpawner());
    }

    void Update()
    {
        /* PC controls 
        if (Input.GetAxisRaw("Horizontal") > 0.5f)
        {
            transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * PCSpeed, 0f, 0f));
        }

        if (Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * PCSpeed, 0f, 0f));
        }

        if (Input.GetAxisRaw("Vertical") > 0.5f)
        {
            transform.Translate(new Vector3(0f, 0f, Input.GetAxisRaw("Vertical") * PCSpeed));
        }

        if (Input.GetAxisRaw("Vertical") < -0.5f)
        {
            transform.Translate(new Vector3(0f, 0f, Input.GetAxisRaw("Vertical") * PCSpeed));
        } */

        /* The 4 following if statements check for bool true or false 
         * and, moves the player in specified direction. 
         * This ties to our 8 functions on the bottom of the script. */
        if (moveForward)
        {
            transform.Translate(new Vector3(0f, 0f, 1f * MobileSpeed));
        }

        if (moveBack)
        {
            transform.Translate(new Vector3(0f, 0f, -1f * MobileSpeed));
        }

        if (moveLeft)
        {
            transform.Translate(new Vector3(-.5f, 0f, 0f * MobileSpeed));
        }

        if (moveRight)
        {
            transform.Translate(new Vector3(.5f, 0f, 0f * MobileSpeed));
        }
    }

    /* The following function manages health value and Health Slider for visual health representation.
     * When called from EnemyShooting Class it causes pre-set amount of damage. 
     * Damage variable can be changed under damage variable in bullet prefab in inspector. */
    public void takeDamage(int damage)
    {
        // Subtracts a set value as damage and and sets it as currenthealth for display.
        currentHealth -= damage;

        // This modifies our healthslider value to display health properly.
        healthSlider.setHealth(currentHealth);

        //If player health reaches 0 we load a YouLose scene and stop the game.
        if (currentHealth <= 0f)
        {
            SceneManager.LoadScene(3);
        }
    }

    /* While player is alive, spawn enemies every set amount of seconds
     * randomly around the playing area This is using Random.Range to spawn
     * within specified x, z fields which are our arena. */
    IEnumerator EnemySpawner()
    {
        while (currentHealth >= 0)
        {
            Instantiate(enemy, new Vector3(Random.Range(-70, 70), 3, Random.Range(-80, 80)), Quaternion.identity);
            yield return new WaitForSeconds(respawnTimer);
        }
    }

    /* The following are set of functions that will flip a bool for mobile movement.
     * Can be "True" during which player moves in specified direction above 
     * or can be false which stops the player moving in specified direction. 
     * A total of 8 functions 2 for each direction for "True" & Bool "False". */
    public void moveForwardBoolDown()
    {
        moveForward = true;
    }

    public void moveForwardBoolUp()
    {
        moveForward = false;
    }

    public void moveBackBoolDown()
    {
        moveBack = true;
    }

    public void moveBackBoolUp()
    {
        moveBack = false;
    }

    public void moveLeftBoolDown()
    {
        moveLeft = true;
    }

    public void moveLeftBoolUp()
    {
        moveLeft = false;
    }

    public void moveRightBoolDown()
    {
        moveRight = true;
    }

    public void moveRightBoolUp()
    {
        moveRight = false;
    }

    public void LevelMove()
    {
        
    }

}
