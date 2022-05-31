using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{

    // fields

    // note: SerializeField allows for the editing and accessing of a field from within the unity editor itself.
    // essentially writes the variable to the disk and allows it to be edited or accessed in another program.
    [SerializeField] float turnSpeed;
    [SerializeField] float moveSpeed;
    



    // Start is called before the first frame update
    void Start() {

    }



    /* 
    FixedUpdate is a more consistent version of Update. Update calls its methods a certain amount of times based on the amount of frames a pc can render. 
    IE comp1 can render 190 fps while comp2 can only render 95. This means comp1 will have the Update method called twice as much as comp2.
    this can cause variables like movement speed to appear faster on comp1 than comp2 since comp1 will be able to call methods like the 
    translate method twice as much as comp2. FixedUpdate calls a certain amount of times per second regardless of framerate.

    -------------------------------------------------------------------------------------------------------------------------------------------------------

    Time.deltaTime tells the computer how long each frame takes to execute.
    multiplying something by Time.deltaTime makes it framerate independent within the update loop
    this can be used alongside or as an alternative to FixedUpdate
    10fps = 1 frame per 0.1s || 100fps = 1 frame per 0.01s
    10 * 0.1(Time.deltaTime's returned value) = 1 || 100 * 0.01(Time.deltaTime's returned value) = 1
    */

    // Update is called once per frame
    void Update() {

        /* Input.GetAxis gets a value of 1, -1, or 0 from the player's input, then multiplies that by a specified amount 
        to get a certain speed. otherwise you would be stuck turning 1 or -1 pixels at a time */
        float steerAmount = Input.GetAxis("Horizontal") * turnSpeed;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed;

        // changes the the xyz values relating to an object's rotation by a specified amount each frame
        transform.Rotate(0, 0, -steerAmount*Time.deltaTime);

        // changes the the xyz values relating to an object's position by a specified amount each frame
        transform.Translate(0, moveAmount*Time.deltaTime, 0);

    }
}