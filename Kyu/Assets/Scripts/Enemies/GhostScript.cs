using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GhostScript : MonoBehaviour {
    Transform player;
    Transform levelCore;

    public float distToPlayer, distToCore;
    public float maxDistToPly = 15f;
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
                /* if (PlayerMovement.isHidden)
                 {
                     currentState = state.goHome;
                     nav.SetDestination(home.position);  //following -> home
                 }
                 else
                 {
                     if (distToPlayer > maxDistToPly)
                     {
                         currentState = state.idle;  //following -> idle
                         nav.SetDestination(transform.position);

                     }
                     else nav.SetDestination(player.position);
                 }
                 */
                if (distToPlayer > maxDistToPly)
                {
                    currentState = state.goCore; 
                    nav.SetDestination(levelCore.position);

                }
                else
                {
                    nav.SetDestination(player.position);
                }
                
                break;

            case state.goCore:
                if (distToPlayer <= maxDistToPly)
                {
                    currentState = state.following; //core -> following

                    nav.SetDestination(player.position);
                }
                else
                {
                    if (distToCore <= 5)
                    {
                        print("HAS PERDIDO UNA VIDA");
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
}
