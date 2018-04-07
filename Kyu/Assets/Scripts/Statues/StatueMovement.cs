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
    

    Component[] components;

    public Camera cam;
    public float camVel = 1f, camRot = 2f; //velocity of movement and rotation in the transition of the camera to kyu

    public float lookSensitivity = 3f;
    private Vector3 roatation = Vector3.zero;
    

   
    

    private void Awake()
    {
        floorMask = LayerMask.GetMask("Floor");
        anim = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();

        Kyu = GameObject.FindGameObjectWithTag("Player");

        

    }

    private void FixedUpdate()
    {
        //if (this.enabled) cam.GetComponent<AudioListener>().enabled = true;
        TurnInputValue = Input.GetAxis("Horizontal");
        MovementInputValue = Input.GetAxis("Vertical");

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Move(h, v);
        //Turning();
        //Animating(h, v);

        PerformRotation();
    }

    private void Update()
    {

        //if (this.enabled) cam.GetComponent<AudioListener>().enabled = true;
        if (Input.GetKeyDown("space"))
        {

            //moving kyu
            components = this.gameObject.GetComponentsInChildren<Transform>();
            Kyu.transform.position = components[3].transform.position;
            Kyu.transform.rotation = Kyu.GetComponent<KyuMovement>().initialKyuRotation;
            Kyu.SetActive(true);

            //StartCoroutine(moveCam());
            //Changing cams --> lets coroutine
            //Parece que no funciona teniendo una referencia a la cámara y no sé por qué, lo haré todo el rato con getcomponent.
            cam.GetComponent<AudioListener>().enabled = false;
            cam.enabled = false;
            Kyu.SetActiveRecursively(true);
            Kyu.GetComponentInChildren<Camera>().enabled = true;
            Kyu.GetComponentInChildren<Camera>().transform.position = Kyu.transform.position - Kyu.GetComponent<KyuMovement>().cameraDistanceInitial;
            Kyu.GetComponentInChildren<Camera>().transform.rotation = Kyu.GetComponent<KyuMovement>().initialCamRotation;
           // print(Kyu.transform.position - Kyu.GetComponentInChildren<Camera>().transform.position);
            //Stopping movement of statue;
            this.enabled = false;

           /* Camera kyuCam = Kyu.GetComponent<Camera>();
            cam.enabled = false; 
            Kyu.SetActiveRecursively(true);
            kyuCam.enabled = true;
            kyuCam.transform.position = Kyu.transform.position - Kyu.GetComponent<KyuMovement>().cameraDistanceInitial;
            kyuCam.transform.rotation = Kyu.GetComponent<KyuMovement>().initialCamRotation;
            // print(Kyu.transform.position - Kyu.GetComponentInChildren<Camera>().transform.position);
            //Stopping movement of statue;
            this.enabled = false;*/
            
        }

        //Calculate rotation: Turning around.
        float _yRot = Input.GetAxisRaw("Mouse X");

        Vector3 _rotation = new Vector3(0f, _yRot, 0f) * lookSensitivity;

        //Apply rotation
        rotation = _rotation;
        
    }

    void PerformRotation()
    {
        playerRigidbody.MoveRotation(playerRigidbody.rotation * Quaternion.Euler(rotation));
    }

    void Rotate()
    {

    }

    IEnumerator moveCam()
    {

        print("Control point 1");
        Kyu.GetComponent<Camera>().transform.position = cam.transform.position;
        Kyu.GetComponent<Camera>().transform.rotation = cam.transform.rotation;

        cam.enabled = false;

        print("Control point 2");
        Kyu.SetActiveRecursively(true);
        Kyu.GetComponent<Camera>().enabled = true;
        print("Control point 3");
        Vector3 destinationPoint = Kyu.transform.position - Kyu.GetComponent<KyuMovement>().cameraDistanceInitial;
        Quaternion initialRotation = Kyu.GetComponent<KyuMovement>().initialCamRotation;

        print("Control point 4");
        while (Vector3.Distance(Kyu.GetComponent<Camera>().transform.position, destinationPoint) > 0.5f)
        {
            Kyu.GetComponent<Camera>().transform.position = Vector3.Lerp(Kyu.GetComponent<Camera>().transform.position, destinationPoint, camVel * Time.deltaTime);
            Kyu.GetComponent<Camera>().transform.rotation = Quaternion.Slerp(Kyu.GetComponent<Camera>().transform.rotation, initialRotation, camRot * Time.deltaTime);
            yield return null;
        }
        print("Control point 5");
        this.enabled = false;
        

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