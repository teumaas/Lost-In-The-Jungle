﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
 
public class FlyCamera : MonoBehaviour {    
    [SerializeField] 
    float mainSpeed = 25.0f; //regular speed
    [SerializeField] 
    float shiftAdd = 250.0f; //multiplied by how long shift is held.  Basically running
    [SerializeField] 
    float maxShift = 1000.0f; //Maximum speed when holdin gshift
    [SerializeField] 
    float camSens = 0.1f; //How sensitive it with mouse
    private Vector3 lastMouse = new Vector3(255, 255, 255); //kind of in the middle of the screen, rather than at the top (play)
    private float totalRun= 1.0f;

    private Vector3 pos = new Vector3(0, 0, 0);
    [SerializeField]
    private float runtime = 5.0f;
    private bool justRan = true;

    void Update () {
        //Mouse transformations
        lastMouse = Input.mousePosition - lastMouse ;
        lastMouse = new Vector3(-lastMouse.y * camSens, lastMouse.x * camSens, 0 );
        lastMouse = new Vector3(transform.eulerAngles.x + lastMouse.x , transform.eulerAngles.y + lastMouse.y, 0);
        transform.eulerAngles = lastMouse;
        lastMouse =  Input.mousePosition;
        //Mouse  camera angle done.  
       
        //WASD transformations
        float f = 0.0f;
        Vector3 p = GetBaseInput();
        if (Input.GetKey (KeyCode.LeftShift)){
            totalRun += Time.deltaTime;
            p  = p * totalRun * shiftAdd;
            p.x = Mathf.Clamp(p.x, -maxShift, maxShift);
            p.y = Mathf.Clamp(p.y, -maxShift, maxShift);
            p.z = Mathf.Clamp(p.z, -maxShift, maxShift);
        }
        else{
            totalRun = Mathf.Clamp(totalRun * 0.5f, 1f, 1000f);
            p = p * mainSpeed;
        }
       
        p = p * Time.deltaTime;
       Vector3 newPosition = transform.position;
        if (Input.GetKey(KeyCode.Space)){ //If player wants to move on X and Z axis only
            transform.Translate(p);
            newPosition.x = transform.position.x;
            newPosition.z = transform.position.z;
            transform.position = newPosition;
        }
        else{
            transform.Translate(p);
        }

        //Cinematic camera controls
        if (Input.GetKeyDown(KeyCode.P)) {
             if (justRan) {
                // Set the starting point of the animation
                pos = transform.position;
                justRan = false;
            } else {
                // Start the animation
                StartCoroutine(CycleCamera(transform, pos, runtime));
                justRan = true;
            }
        } else if (Input.GetKeyDown(KeyCode.R)) {
            StartCoroutine(CycleCamera(transform, pos, runtime));
        }

        if (Input.GetKeyDown(KeyCode.Tab)){
            SceneManager.LoadScene("Village");
        }

        UpdateRunTime();
    }
     
    private Vector3 GetBaseInput() { //returns the basic values, if it's 0 than it's not active.
        Vector3 p_Velocity = new Vector3();
        if (Input.GetKey (KeyCode.W)){
            p_Velocity += new Vector3(0, 0 , 1);
        }
        if (Input.GetKey (KeyCode.S)){
            p_Velocity += new Vector3(0, 0, -1);
        }
        if (Input.GetKey (KeyCode.A)){
            p_Velocity += new Vector3(-1, 0, 0);
        }
        if (Input.GetKey (KeyCode.D)){
            p_Velocity += new Vector3(1, 0, 0);
        }
        return p_Velocity;
    }

    private IEnumerator CycleCamera(Transform transform, Vector3 position, float timeToMove) {
        var currentPos = transform.position;
        var t = 0f;
        while(t < 1){
            t += Time.deltaTime / timeToMove;
            transform.position = Vector3.Lerp(position, currentPos, t);
            yield return null;
        }
    }

    private void UpdateRunTime() {
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            runtime = 1.0f;
        } else if (Input.GetKeyDown(KeyCode.Alpha2)) {
            runtime = 2.0f;
        } else if (Input.GetKeyDown(KeyCode.Alpha3)) {
            runtime = 3.0f;
        } else if (Input.GetKeyDown(KeyCode.Alpha4)) {
            runtime = 4.0f;
        } else if (Input.GetKeyDown(KeyCode.Alpha5)) {
            runtime = 5.0f;
        } else if (Input.GetKeyDown(KeyCode.Alpha6)) {
            runtime = 6.0f;
        } else if (Input.GetKeyDown(KeyCode.Alpha7)) {
            runtime = 7.0f;
        } else if (Input.GetKeyDown(KeyCode.Alpha8)) {
            runtime = 8.0f;
        } else if (Input.GetKeyDown(KeyCode.Alpha9)) {
            runtime = 9.0f;
        } 
    }
}