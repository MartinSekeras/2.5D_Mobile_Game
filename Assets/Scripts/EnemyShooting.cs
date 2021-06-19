using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{

    /* Creates a public variable called playerPos which is of type transform and can store lcoation values. */
    private Transform playerPos;

    /* Specifies a variabel to set the speed of our projectile. */
    public float projectileSpeed;

    /* Specifies variable damage and it is sed to tell how much damage should the projectile deal if it hits th eplayer. */
    public int damage;

    /* Target is vector3 variable to store the location values x, y, z of player. */
    private Vector3 target;

    // Start is called before the first frame update
    void Start()
    {
        /* Finds a gameobject with "Player" tag and gets it's transform values. */
        playerPos = GameObject.FindWithTag("Player").transform;

        /* Uses the variable target to store the players location in it for x, y, z. */
        target = new Vector3(playerPos.position.x, 0f, playerPos.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        /* This makes the projectile move towards the players position at the time of instantiating of this game object. */
        transform.position = Vector3.MoveTowards(transform.position, target, projectileSpeed * Time.deltaTime);

        /* When the position of the projectile reaches the position referenced in targer it calls the function to destroy the projectile. */
        if (transform.position.x == target.x && transform.position.z == target.z)
        {
            DestroyProjectile();
        }
    }

    private void OnTriggerEnter(Collider Player)
    {
        /* Checks if the object which was hit has PlayerController script and stores the result in target variable. */
        PlayerController target = Player.transform.GetComponent<PlayerController>();

        /* If the target variable returns true for having PlayerController attached to it.
         * it means the object hit is Player and runs the following. */
        if (target != null)
        {
            // This runs the takeDamage function in PlayerController and deals damage to the player.
            target.takeDamage(damage);
            
            // This calls for cuntion to destroy the projectile.
            DestroyProjectile();
        }
    }

    /* This functios destroys the projectile when called. */
    private void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
