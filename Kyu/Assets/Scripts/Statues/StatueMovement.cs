using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatueMovement : MonoBehaviour
{

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

    private GameObject Kyu;
    private Camera kyuCam;

    Component[] components;

    public Camera cam;


    

   
    

    private void Awake()
    {
        floorMask = LayerMask.GetMask("Floor");
        anim = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();

        Kyu = GameObject.FindGameObjectWithTag("Player");

        

    }

    private void FixedUpdate()
    {
        TurnInputValue = Input.GetAxis("Horizontal");
        MovementInputValue = Input.GetAxis("Vertical");

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Move(h, v);
        Turning();
        //Animating(h, v);
    }

    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            print(Kyu.transform.position);

            //moving kyu
            components = this.gameObject.GetComponentsInChildren<Transform>();
            Kyu.transform.position = components[3].transform.position;
            Kyu.transform.rotation = Kyu.GetComponent<KyuMovement>().initialKyuRotation;
            Kyu.SetActive(true);
            

            //Changing cams
            cam.enabled = false;
            Kyu.SetActiveRecursively(true);
            Kyu.GetComponentInChildren<Camera>().enabled = true;
            Kyu.GetComponentInChildren<Camera>().transform.position = Kyu.transform.position - Kyu.GetComponent<KyuMovement>().cameraDistanceInitial;
            Kyu.GetComponentInChildren<Camera>().transform.rotation = Kyu.GetComponent<KyuMovement>().initialCamRotation;
           // print(Kyu.transform.position - Kyu.GetComponentInChildren<Camera>().transform.position);
            //Stopping movement of statue;
            this.enabled = false;
        }

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

        playerRigidbody.MovePosition(playerRigidbody.position + movement);
    }

    void Turning()
    {
        /*float turn = TurnInputValue * TurnSpeed * Time.deltaTime;

        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);

        playerRigidbody.MoveRotation(playerRigidbody.rotation * turnRotation);*/
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
 
    }

    void OnTriggerExit(Collider other)
    {

    }

}