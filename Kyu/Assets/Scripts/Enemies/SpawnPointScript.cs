using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointScript : MonoBehaviour {

    public float timeBetweenUnits = 2f;
    public GameObject ghost;
    public bool spawnEnemy = true;
<<<<<<< HEAD
    
=======
>>>>>>> Laura
	// Use this for initialization
	void Start () {
        StartCoroutine(spawnEnemies());
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    IEnumerator spawnEnemies()
    {

        while (spawnEnemy)
        {
<<<<<<< HEAD

            GameObject.Instantiate(ghost,this.gameObject.transform.position,this.gameObject.transform.rotation);
            EnemyManager.currentNumberOfEnemies++;
=======
            GameObject.Instantiate(ghost,this.gameObject.transform.position,this.gameObject.transform.rotation);
>>>>>>> Laura
            yield return new WaitForSeconds(timeBetweenUnits);
        }
        yield return null;
        
    }
}
