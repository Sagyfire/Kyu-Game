using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GhostScript : MonoBehaviour {
    Transform player;
    Transform levelCore;

    public float distToPlayer, distToCore;
    public float maxDistToPly = 15f;
    public float disToCollisionWithPlayer;
    NavMeshAgent nav;
    enum state { idle, following, goCore, death };

    state currentState;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        levelCore = GameObject.FindGameObjectWithTag("Core").transform;
        nav = GetComponent<NavMeshAgent>();

    }

    // Use this for initialization
    void Start () {
        currentState = state.goCore;
        nav.SetDestination(levelCore.position);
	}
	
	// Update is called once per frame


    void Update()
    {

        distToPlayer = Vector3.Distance(player.position, this.transform.position);
        distToCore = Vector3.Distance(levelCore.position, this.transform.position);
        /* if(distToPlayer<= maxDistToPly)
         {
             currentState = state.following;
             nav.enabled = true;
             nav.SetDestination(player.position);

         }
         else
         {
             nav.enabled = false;
         }
         */

        /*
        if (!(enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0))
        {
            currentState = state.death;
        }
        */

        switch (currentState)
        {
            case state.following:
                if (distToPlayer > maxDistToPly)
                {
                    currentState = state.goCore; 
                    nav.SetDestination(levelCore.position);

                }
                else   // here is where the ghost is following the player
                {
                    if(distToPlayer <= disToCollisionWithPlayer)
                    {
                        print("HAS PERDIDO UNA VIDA");
                        player.GetComponent<KyuHealth>().TakeDamage();
                        Destroy(this.gameObject);
                    }
                    else //if not collides with the player
                    {
                        if (KyuMovement.intoStatue)
                        {
                            currentState = state.goCore;
                            nav.SetDestination(levelCore.position);
                            print("el jugador entra en la estatua");
                        }
                        else
                        {
                            nav.SetDestination(player.position);
                        }
                    }

                }
                
                break;

            case state.goCore:
                if (distToPlayer <= maxDistToPly && !KyuMovement.intoStatue)
                {
                    currentState = state.following; //core -> following

                    nav.SetDestination(player.position);
                }
                else
                {
                    if (distToCore <= 5)
                    {
                        print("HAS PERDIDO UNA VIDA");
                        player.GetComponent<KyuHealth>().TakeDamage();
                        Destroy(this.gameObject);
                    }
                }
                break;

            case state.idle:
                if (distToPlayer <= maxDistToPly)
                {
                    currentState = state.following; //idle -> following

                    nav.SetDestination(player.position);

                }
                break;

            case state.death:
                nav.enabled = false;
                break;
        }
    }

    public void DeathEnemy()
    {

    }
}
