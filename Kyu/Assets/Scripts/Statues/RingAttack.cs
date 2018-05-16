using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingAttack : MonoBehaviour {

    private bool particlesRunning = false;
    public ParticleSystem ps, ps2;

    public SphereCollider sphereColl;
    public float increaseRadius = 0.02f;

    public GameObject prey; //the enemy that enters the zone
    // Use this for initialization
    void Start () {
        ps.Stop();
        ps2.Stop();
        prey = null;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            prey = other.gameObject;
            startAttack();
        }
    }


    private void startAttack()
    {
        ps.Play();
        ps2.Play();
        StartCoroutine(changePS());
    }

    IEnumerator changePS()
    {
        //var shape = ps.shape;
       
        //var radius = shape.radius;
        ParticleSystem.ShapeModule shapeModule = ps.shape;
        shapeModule.radius = 0.1f;
        //ps.Play();
        ParticleSystem.ShapeModule shapeModule2 = ps2.shape;
        shapeModule2.radius = 0.1f;
        
        while (shapeModule.radius <= sphereColl.radius)
        {
            
            shapeModule.radius += increaseRadius;
            shapeModule2.radius += increaseRadius;
            //ps.Play();
            yield return null;
            //yield return new WaitForSeconds(0.2f);
        }
        yield return new WaitForSeconds(0.5f);
        ps.Stop();
        KillEnemy();
        yield return new WaitForSeconds(0.2f);
        ps2.Stop();
        yield return null;
    }

    private void KillEnemy()
    {
        Destroy(prey);
        prey = null;
    }

}
