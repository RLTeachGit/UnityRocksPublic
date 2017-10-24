using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]     //Makes sure Unity addss this component


//A base class for a simple generic entity, which will be inherited by other objects
public abstract class Entity : MonoBehaviour {		//Making it abstract means you need to inherit from it to instanciate it

    protected Rigidbody2D mRB; //Assume all inherited Objects have RB

	// Use this for base class Init
	protected  virtual void Start () {
        //Take care of linking in RB for all derived objects
        mRB = GetComponent<Rigidbody2D>();		
	}

	//Base class Fixed Update, does wrap
	protected virtual void LateUpdate () {
		mRB.position = Utilities.WrapPosition(Camera.main, mRB.position);		//Do default screen wrap
	}

    //Grab collisions and pass them on in friendly way
    private void OnTriggerEnter2D(Collider2D collision)		
    {
        //Get Entity object attached to object we hit, we assumes they all have one
        //which will in practice be a derived class as Entity is abstract
        Entity tEntity = collision.gameObject.GetComponent<Entity>();

        ObjectHit(tEntity);      //Call overrideable function to deal with collision
    }

    //Can override in derived classes, default ignore collision & do nothing
    protected virtual  void  ObjectHit (Entity vOtherEntity) {	
	} 

	public	virtual	void	Kill() {		//Default kill is to Destroy
		Destroy (gameObject);
	}

	public virtual void	Explode()		//Default explode, then kill
	{
		Instantiate (GM.sGM.Explosion, transform.position, Quaternion.identity); //Show explosion particles
		Kill ();
	}
}
