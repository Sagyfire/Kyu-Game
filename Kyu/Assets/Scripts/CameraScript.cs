using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    public Transform positionOfCam;
    public Transform orientationOfCam;
    public Transform kyu;
    public float camVelocity = 1f, rotationSpeed = 1f;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.Lerp(transform.position, positionOfCam.position, camVelocity * Time.deltaTime);
        /*transform.rotation = Quaternion.LookRotation(kyu.position);*/


        Vector3 relativePos = orientationOfCam.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos);

        transform.rotation =Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, kyu.position);
    }
}
