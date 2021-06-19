using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WeaponScript : MonoBehaviour
{

    /* This stores the transform values of the player and uses them to shoot from in direction. */
    public Transform fire;

    /* This variable stores the number of enemies we need to kill before king spawns. */
    public int KingSpawnKillCountReq;

    /* This is used to specifi how much damage should each raycast deal to enemy. */
    private int Damage = 5;

    /* This stores information about what was hit. And checks for components. */
    RaycastHit hit;

    /* GameObject kingEnemy is used for spawning of the King. 
     * Object stored here will be spawned in accordance with our mechanics below. */
    public GameObject kingEnemy;

    /* A bool used for spawning of the King. */
    private bool kingSpawned;

    void Start()
    {
        /* Initializes PlayerPrefs to store a number of enemies that died in string so we can access it if needed. */
        PlayerPrefs.SetInt("EnemyDead", 0);

        /* We use this to specifiy if the king has apwn yet or not.
         * Of course at the start of the game the answer to that is a false. */
        kingSpawned = false;
    }

    private void Update()
    {
        /* This here checks for value stored in our EnemyDead string that we declared in start function. 
         * Every time player kills an enemy the value in this string increases by 1 and when it hits 25. 
         * We spawn a King which we need to kill, when this dies the game ends with you winning. */
        if (PlayerPrefs.GetInt("EnemyDead", 0) == KingSpawnKillCountReq && kingSpawned == false)
        {
            Instantiate(kingEnemy, new Vector3(Random.Range(-70, 70), 3, Random.Range(-80, 80)), Quaternion.identity);
            kingSpawned = true;
        }
    }

    /* A function that is attached to button up for firing forward. */
    public void FireUp()
    {
        /* Casts a raycast from players position towards a direction of specified vector3 on x, y, z. 
         * In this case forward +1 on z axis. Stores what was hit in hit variable. */
        if (Physics.Raycast(fire.position, new Vector3(0, 0, 1), out hit))
        {
            /* Checks if twhatever was hit by the raycast has a component EnemyAI. */
            EnemyAI target = hit.transform.GetComponent<EnemyAI>();

            /* Checks if twhatever was hit by the raycast has a component KingAI. */
            KingAI KingTarget = hit.transform.GetComponent<KingAI>();

            /* If it has the component it is an enemy or King it calls a function takeDamage from EnemyAI or KingAI script. */
            if (target != null)
            {
                /* This increases the number of enemies dead and stores it in variable so we can sue it later.
                 * PlayerPrefs.SetInt sets the integer to be stored in EnemyDead string and Player.GetInt gets the current value and adds 1 to it.
                 * if this is called firt time it Player.GetInt will asuume the value is 0 and adds 1 to make a total of 1. */
                PlayerPrefs.SetInt("EnemyDead", PlayerPrefs.GetInt("EnemyDead", 0) + 1);

                /* Destroys the enemy pawn */
                target.takeDamage(Damage);
            }
            else if (KingTarget != null)
            {
                KingTarget.kingTakeDamage(Damage);
            }
        }
    }

    /* A function that is attached to button down for firing downwards. */
    public void FireDown()
    {
        /* Casts a raycast from players position towards a direction of specified vector3 on x, y, z. 
         * In this case backwards -1 on z axis. Stores what was hit in hit variable. */
        if (Physics.Raycast(fire.position, new Vector3(0, 0, -1), out hit))
        {
            /* Checks if twhatever was hit by the raycast has a component EnemyAI. */
            EnemyAI target = hit.transform.GetComponent<EnemyAI>();

            /* Checks if twhatever was hit by the raycast has a component KingAI. */
            KingAI KingTarget = hit.transform.GetComponent<KingAI>();

            /* If it has the component it is an enemy or King it calls a function takeDamage from EnemyAI or KingAI script. */
            if (target != null)
            {
                /* This increases the number of enemies dead and stores it in variable so we can sue it later.
                 * PlayerPrefs.SetInt sets the integer to be stored in EnemyDead string and Player.GetInt gets the current value and adds 1 to it.
                 * if this is called firt time it Player.GetInt will asuume the value is 0 and adds 1 to make a total of 1. */
                PlayerPrefs.SetInt("EnemyDead", PlayerPrefs.GetInt("EnemyDead", 0) + 1);

                /* Destroys the enemy pawn */
                target.takeDamage(Damage);
            }
            else if (KingTarget != null)
            {
                KingTarget.kingTakeDamage(Damage);
            }
        }
    }

    /* A function that is attached to button left for firing left. */
    public void FireLeft()
    {
        /* Casts a raycast from players position towards a direction of specified vector3 on x, y, z. 
         * In this case left -1 on x axis. Stores what was hit in hit variable. */
        if (Physics.Raycast(fire.position, new Vector3(-1, 0, 0), out hit))
        {
            /* Checks if twhatever was hit by the raycast has a component EnemyAI. */
            EnemyAI target = hit.transform.GetComponent<EnemyAI>();

            /* Checks if twhatever was hit by the raycast has a component KingAI. */
            KingAI KingTarget = hit.transform.GetComponent<KingAI>();

            /* If it has the component it is an enemy or King it calls a function takeDamage from EnemyAI or KingAI script. */
            if (target != null)
            {
                /* This increases the number of enemies dead and stores it in variable so we can sue it later.
                 * PlayerPrefs.SetInt sets the integer to be stored in EnemyDead string and Player.GetInt gets the current value and adds 1 to it.
                 * if this is called firt time it Player.GetInt will asuume the value is 0 and adds 1 to make a total of 1. */
                PlayerPrefs.SetInt("EnemyDead", PlayerPrefs.GetInt("EnemyDead", 0) + 1);

                /* Destroys the enemy pawn */
                target.takeDamage(Damage);
            }
            else if (KingTarget != null)
            {
                KingTarget.kingTakeDamage(Damage);
            }
        }
    }

    /* A function that is attached to button right for firing right. */
    public void FireRight()
    {
        /* Casts a raycast from players position towards a direction of specified vector3 on x, y, z. 
         * In this case right 1 on x axis. Stores what was hit in hit variable. */
        if (Physics.Raycast(fire.position, new Vector3(1, 0, 0), out hit))
        {
            /* Checks if twhatever was hit by the raycast has a component EnemyAI. */
            EnemyAI target = hit.transform.GetComponent<EnemyAI>();

            /* Checks if twhatever was hit by the raycast has a component KingAI. */
            KingAI KingTarget = hit.transform.GetComponent<KingAI>();

            /* If it has the component it is an enemy or King it calls a function takeDamage from EnemyAI or KingAI script. */
            if (target != null)
            {
                /* This increases the number of enemies dead and stores it in variable so we can sue it later.
                 * PlayerPrefs.SetInt sets the integer to be stored in EnemyDead string and Player.GetInt gets the current value and adds 1 to it.
                 * if this is called firt time it Player.GetInt will asuume the value is 0 and adds 1 to make a total of 1. */
                PlayerPrefs.SetInt("EnemyDead", PlayerPrefs.GetInt("EnemyDead", 0) + 1);

                /* Destroys the enemy pawn */
                target.takeDamage(Damage);
            }
            else if (KingTarget != null)
            {
                KingTarget.kingTakeDamage(Damage);
            }
        }
    }
}
