using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipController : MonoBehaviour {

	public	float	Thrust = 1.0f;
	public	float	RotationSpeed = 360.0f;

	//Initial velocity
	Vector3	mVelocity=Vector3.zero;

	// Use this for initialization
	void Start () {
		
	}
	
    float   ScreenHeight()
    {
        //Orthograpic camera height is stored in Camera
        return Camera.main.orthographicSize;
    }

    float   ScreenWidth()
    {
        //To get Width use the height and aspect ratio
        return ScreenHeight() * Camera.main.aspect;
    }

    void WrapPosition()
    {
        //Get current width and Height
        float tScreenHeight = ScreenHeight();
        float tScreenWidth = ScreenWidth();
        bool tWrapped = false;      //Flag
        //Keep a copy of the current position, so we can alter it if needed
        Vector3 tWrapPosition = transform.position;

        //Horizontal
        if (transform.position.x > tScreenWidth)
        {  //Check right of screen
            //Adjust screen position to move right by whole screen
            tWrapPosition.x -= tScreenWidth  * 2.0f;
            tWrapped = true; //Set flag so position is updated
        }
        else if (transform.position.x < -tScreenWidth)
        { //Check left of screen
            //Adjust screen position to move left
            tWrapPosition.x += tScreenWidth * 2.0f;
            tWrapped = true; //Set flag so position is updated
        }

        //Vertical
        if (transform.position.y > tScreenHeight)
        {  //Check top of screen
            //Adjust screen position to move down by whole screen
            tWrapPosition.y -= tScreenHeight * 2.0f;
            tWrapped = true; //Set flag so position is updated
        }
        else if (transform.position.y < -tScreenHeight) //Check bottom of screen
        {
            //Adjust screen position to move down
            tWrapPosition.y += tScreenHeight * 2.0f;
            tWrapped = true; //Set flag so position is updated
        }
        if (tWrapped)       //Only adjust position to wrap if needed
        {
            transform.position = tWrapPosition; //Apply new position
        }
    }

    public float Speed = 5.0f;      //Show this in IDE
    //Update GO position based on player input
    void UpdateMovement()
    {
		float	tThrust=0.0f;

        if (Input.GetKey(KeyCode.RightArrow))       //If rotate key is pressed, rotate ship
        {
			transform.Rotate (0, 0, -RotationSpeed * Time.deltaTime);  //Rotate around Z axis, to make ship rotate
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
			transform.Rotate (0, 0, RotationSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
			tThrust = Thrust;
        }
		//Current Acceleration
		Vector3 tAcceleration=transform.rotation*Vector3.up*tThrust;

		mVelocity += tAcceleration;		//v=u+a (as time take care of later)
		float vSpeed=mVelocity.magnitude;
		if (Mathf.Abs (vSpeed) > 10.0f) 
		{
			mVelocity = mVelocity.normalized * 10.0f;		//clamp speed at 10, normalised makes a vector of unit length
		}
		transform.position += 0.5f*mVelocity*Time.deltaTime;	//NewPos=OldPos+0.5*v
    }

    // Update is called once per frame
    void Update () 
	{
        UpdateMovement();       //Allows Testing of Movement
        WrapPosition();         //Wrap world
	}
}
