using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GhostScript : MonoBehaviour {
    Transform player;
    Transform levelCore;

    NavMeshAgent nav;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        levelCore = GameObject.FindGameObjectWithTag("Core").transform;
        nav = GetComponent<NavMeshAgent>();

    }

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        nav.SetDestination(levelCore.position);

		
	}
}
