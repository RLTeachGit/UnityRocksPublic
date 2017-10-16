using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerShipRB : MonoBehaviour {


	public	float	Thrust = 1.0f;
	public	float	RotationSpeed = 360.0f;
	public	float	MaxSpeed = 10.0f;


	Rigidbody2D	mRB;

	//Initial velocity
	Vector2	mVelocity=Vector2.zero;

	// Use this for initialization
	void Start () {
		mRB = GetComponent<Rigidbody2D> ();
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
		Vector2 tWrapPosition = mRB.position;

		//Horizontal
		if (mRB.position.x > tScreenWidth)
		{  //Check right of screen
			//Adjust screen position to move right by whole screen
			tWrapPosition.x -= tScreenWidth  * 2.0f;
			tWrapped = true; //Set flag so position is updated
		}
		else if (mRB.position.x < -tScreenWidth)
		{ //Check left of screen
			//Adjust screen position to move left
			tWrapPosition.x += tScreenWidth * 2.0f;
			tWrapped = true; //Set flag so position is updated
		}

		//Vertical
		if (mRB.position.y > tScreenHeight)
		{  //Check top of screen
			//Adjust screen position to move down by whole screen
			tWrapPosition.y -= tScreenHeight * 2.0f;
			tWrapped = true; //Set flag so position is updated
		}
		else if (mRB.position.y < -tScreenHeight) //Check bottom of screen
		{
			//Adjust screen position to move down
			tWrapPosition.y += tScreenHeight * 2.0f;
			tWrapped = true; //Set flag so position is updated
		}
		if (tWrapped)       //Only adjust position to wrap if needed
		{
			mRB.position = tWrapPosition; //Apply new position
		}
	}

	public float Speed = 5.0f;      //Show this in IDE
	//Update GO position based on player input
	void UpdateMovement()
	{
		float	tThrust=0.0f;

		if (Input.GetKey(KeyCode.RightArrow))       //If rotate key is pressed, rotate ship
		{
			mRB.MoveRotation (mRB.rotation-(RotationSpeed * Time.deltaTime));  //Rotate around Z axis, to make ship rotate
		}

		if (Input.GetKey(KeyCode.LeftArrow))
		{
			mRB.MoveRotation (mRB.rotation+(RotationSpeed * Time.deltaTime));  //Rotate around Z axis, to make ship rotate
		}

		if (Input.GetKey(KeyCode.DownArrow))
		{
			tThrust = Thrust;
		}
		//Current Force
		Vector2 tForce=new Vector2(-Mathf.Sin(mRB.rotation*Mathf.Deg2Rad),Mathf.Cos(mRB.rotation*Mathf.Deg2Rad)) * tThrust;
		mRB.AddForce (tForce);

		if (Mathf.Abs (mRB.velocity.magnitude) > MaxSpeed) 
		{
			mRB.velocity = mRB.velocity.normalized * MaxSpeed;		//clamp speed at 10, normalised makes a vector of unit length
		}
	}

	// Update is called once per frame
	void FixedUpdate () 
	{
		UpdateMovement();       //Allows Testing of Movement
	}

	void LateUpdate()
	{
		WrapPosition ();
	}
}
