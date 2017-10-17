using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]     //Makes sure Unity addss this component

public class MovePlayerShipRB : MonoBehaviour
{


    public float Thrust = 1.0f;
    public float RotationSpeed = 360.0f;
    public float MaxSpeed = 10.0f;

    Rigidbody2D mRB;

    // Use this for initialization
    void Start()
    {
        mRB = GetComponent<Rigidbody2D>();  //Need this for physics
    }

    //Update GO position based on player input
    void UpdateMovement()   //Apply movement to RigidBody2D, not transform
    {
        if (Input.GetKey(KeyCode.RightArrow))       //If rotate key is pressed, rotate ship
        {
            //Rotate around Z axis, to make ship rotate
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
    void FixedUpdate()
    {
        UpdateMovement();       //Allows Testing of Movement
    }

    void LateUpdate()       //Fix up position after all the physics is calculated
    {
        mRB.position = Utilities.WrapPosition(Camera.main, mRB.position);
    }
}