using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {


	public float lookRadius = 10f;
	Transform target;
	NavMeshAgent agent;

	// Use this for initialization
	void Start () {
		GameObject.FindGameObjectsWithTag ("Player");
		agent = GetComponent<NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		float distance = Vector3.Distance (target.position, transform.position);

		if (distance <= lookRadius) 
		{
			agent.SetDestination (target.position);

			if (distance <= agent.stoppingDistance) {
			
				//Attack the target

				//Face the target
				FaceTarget();
			
			}
		}
	}

	void FaceTarget(){
	
		Vector3 direction = (target.position - transform.position).normalized;
		Quaternion lookRotation = Quaternion.LookRotation (new Vector3 (direction.x, 0, direction.z));
		transform.rotation = Quaternion.Slerp(transform.rotation,lookRotation,Time.deltaTime*5f);
	}

	void OnDrawGizmoSelected(){

		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere (transform.position, lookRadius);
	}
}
