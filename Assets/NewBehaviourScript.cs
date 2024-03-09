using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirPlane : MonoBehaviour 
{
    public Rigidbody rb;
    public float enginePowerThrust, litfBooster , drag , angularDrag;



    void FixedUpdate()
    {
        //1. Add Thrust
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(transform.forward * enginePowerThrust);
        }

        //2. Lift
        Vector3 lift = Vector3.Project(rb.velocity, transform.forward);
        rb.AddForce(transform.up * lift.magnitude   * litfBooster);

        //3. Drag
        rb.drag = rb.velocity.magnitude * drag;

        //4 Control
        //4.1 left - Right
        rb.AddTorque(Input.GetAxis("Horizontal") * transform.forward * -1);

        //4.2
        rb.AddTorque(Input.GetAxis("Vertical") * transform.right);
    }
}
