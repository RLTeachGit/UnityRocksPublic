using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]     //Makes sure Unity addss this component

public class Bullet : Entity {

    public float LifeSpan   =   1.0f;

	private Vector2	mPosition;
	private	Vector2 mVelocity;

	protected override void ObjectHit(Entity vOtherEntity) {		//Bullet Hit by bullet do nothing
	}


// Use this for initialization
    protected override void Start () { //Start only called if object is active
		base.Start();
		transform.position = mPosition;       //Set Start position, yusing tranform as its before force applied
		//Makes sure starting postion is set before its drawn
		mRB.AddForce(mVelocity, ForceMode2D.Impulse); //Apply force in one go
		Destroy(gameObject, LifeSpan);      //Bullets time out
	}

    public  void    SetDirection(Vector2 vPosition, Vector2 vVelocity)
    {
		mPosition = vPosition;		//Store fire data
		mVelocity = vVelocity;
    }
}
