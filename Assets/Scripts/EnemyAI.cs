using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyAI : MonoBehaviour
{

    /* Creates a public variable called playerPos which is of type transform and can store lcoation values. */
    public Transform playerPos;

    /* Creates reference to public float speed used for speed of the enemy game object. */
    public float Speed;
    
    /* This variable does nothing but identifies what type of enemy is this game object. Like Jockey or Wizard or Shooter etc.
     * Pretty much useless and I didn't use it but still something that could be used in some way. */
    public string enemyType;

    /* Creates a reference to a health variable that is used for enemy.
     * This variable is modified by function call in WeaponScript. */
    public int health;

    /* This will reset the rate of fire variable to ensure enemies shoot at same speed with same bullet cooldown. */
    public float rateOfFireReset;

    /* This deals with weapon shooting cooldown. Enemy can shoot only once in a specified number that is stored in this variable.
     * Can be andjested in inspector. */
    private float rateOfFire;

    /* This stores our gameobject bullet projectile prefab. */
    public GameObject projectile;

    void Start()
    {
        /* Finds a gameobject with "Player" tag and gets it's transform values. */
        playerPos = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        /* This handles enemy movement, it uses the playerPos variable we referenced in start method and gets it's position 
         * If the distance between the enemy and player is greater then 1 unit* away the enmy moves towards them. */
        if (Vector3.Distance(transform.position, playerPos.position) > 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, playerPos.position, Speed * Time.deltaTime);
        }

        /* This handles spawning of projectiles If Player is less then 100 units away it will start spawning projectiles.
         * Thes eprojectiles have set position and will not follow the Player but instead go towards players locaton at the time of instantiation. */
        if (rateOfFire <= 0 && Vector3.Distance(transform.position, playerPos.position) < 100)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            rateOfFire = rateOfFireReset;
        }
        else
        {
            // Using deltatime instead of 1 for optimization and hardware perposes.
            rateOfFire -= Time.deltaTime;
        }
    }
    
    /* A funtion that deals damage to Enemy Game Object and calls fucntion to destroy the game object if health is below or equal to 0. */
    public void takeDamage(int damage)
    {
        health -= damage;
        if (health <= 0f)
        {
            destroyEnemy();
        }
    }

    /* Function that destroys the game object if health drops below or equals 0. */
    private void destroyEnemy()
    {
        
        //Destroys te enemy gameobject.
        Destroy(gameObject);
    }
}
