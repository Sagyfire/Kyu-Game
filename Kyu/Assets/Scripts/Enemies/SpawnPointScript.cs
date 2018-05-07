using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointScript : MonoBehaviour {

    public float timeBetweenUnits = 2f;
    public GameObject ghost;
    public bool spawnEnemy = true;
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
            GameObject.Instantiate(ghost);
            yield return new WaitForSeconds(timeBetweenUnits);
        }
        yield return null;
        
    }
}
