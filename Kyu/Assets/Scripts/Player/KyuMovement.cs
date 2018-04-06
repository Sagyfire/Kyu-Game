using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KyuMovement : MonoBehaviour {

    public float speed = 0f;
    public float SlerpSpeed = 5f;
	public float TurnSpeed = 180f;

    Vector3 movement;
    Vector3 rotation;

    Animator anim;
    Rigidbody playerRigidbody;

    int floorMask;
    float camRayLenght = 100f;

	public float TurnInputValue = 0f;
	public float MovementInputValue = 0f;

    private void Awake()
    {
        floorMask = LayerMask.GetMask("Floor");
        anim = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
		TurnInputValue = Input.GetAxis ("Horizontal");
		MovementInputValue = Input.GetAxis ("Vertical");

		float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Move(h, v);
        Turning();
        Animating(h, v);
    }

    private void Move(float h, float v)
    {
		bool moving = h != 0f || v != 0f;
		bool run = speed > 10f;

		if (moving && run == false) 
			speed += 0.1f;
		else if (moving && run) 
			speed = 10f;
		else
			speed = 0f;

		movement = transform.forward * MovementInputValue * speed * Time.deltaTime;

		playerRigidbody.MovePosition (playerRigidbody.position + movement);
    }

    void Turning()
    {        
		float turn = TurnInputValue * TurnSpeed * Time.deltaTime;

		Quaternion turnRotation = Quaternion.Euler (0f, turn, 0f);

		playerRigidbody.MoveRotation (playerRigidbody.rotation * turnRotation);
    }

    void Animating(float h, float v)
    {
        bool walking = h != 0f || v != 0f;
        anim.SetBool("IsWalking", walking);

		bool running = speed > 6f;
		anim.SetBool("IsRunning", running);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Statue")
        {
            print("cerca estatua");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Statue")
        {
            print("lejos estatua");
        }
    }

}