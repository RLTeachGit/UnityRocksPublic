using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]     //Makes sure Unity addss this component

public class Bullet : MonoBehaviour {

    public float LifeSpan   =   10.0f;

    Rigidbody2D mRB;        //Keep a copy of this RigidBody2D, for fast access

    // Use this for initialization
    void Awake () { //Awake only called if object is active
        mRB = GetComponent<Rigidbody2D>();        
        gameObject.SetActive(false);    //Turn off till it fires
	}

    public  void    Fire(Vector2 vPosition, Vector2 vVelocity)
    {
        mRB.gameObject.SetActive(true);    //Turn on now 
        transform.position = vPosition;       //Set Start position, yusing tranform as its before force applied
                                              //Makes sure starting postion is set before its drawn
        mRB.AddForce(vVelocity, ForceMode2D.Impulse); //Apply force in one go
        Destroy(gameObject, LifeSpan);      //Bullets time out
    }

    private void LateUpdate()
    {
        mRB.position = Utilities.WrapPosition(Camera.main, mRB.position);   //Warp world
    }
}
