using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : Entity
{
    public float Thrust = 1.0f;
    public float RotationSpeed = 360.0f;
    public float MaxSpeed = 10.0f;


    //Update GO position based on player input
    void UpdatePlayerMovement()   //Apply movement to RigidBody2D, not transform
    {
        if (Input.GetKey(KeyCode.RightArrow))       //If rotate key is pressed, rotate ship
        {
			//Rotate around Z axis, to make ship rotate, more precise than using AddTorque()
            mRB.MoveRotation(mRB.rotation 
                - (RotationSpeed * Time.deltaTime));
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            mRB.MoveRotation(mRB.rotation
                + (RotationSpeed * Time.deltaTime));  //Rotate around Z axis, to make ship rotate
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            Vector2 tForce = Utilities.DirectionOfMotion2D(mRB.rotation) * Thrust;
            mRB.AddForce(tForce);
        }

        //Clamp Max speed
        if (Mathf.Abs(mRB.velocity.magnitude) > MaxSpeed)
        {
            //clamp speed at 10, normalised makes a vector of unit length
            mRB.velocity = mRB.velocity.normalized * MaxSpeed;      
        }
    }

    // FixedUpdate is called once per PHYSICS frame, it happens 100 per second unless changed in prefs 
    void FixedUpdate()    {
        UpdatePlayerMovement();       //Allows Testing of Movement
    }

}