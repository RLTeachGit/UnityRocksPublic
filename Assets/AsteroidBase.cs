﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Abstract Base class for all asteroids
abstract public class AsteroidBase : Entity {

	public	enum AsteroidType  {	//Makes up consecutive integers from starting at 0, needs cast to (int) to work as index
			Big=0		//0
			,Medium		//1
			,Small		//2
	}

	public	static	int	AsteroidCount = 0;		//Count of all the asteroids regardless of which type

	public	abstract int Score { get;}		//Abstract means all Asteroids must implement this getter for score

	// Use this for Basic Asteroid initialization, by overriding base Entity class
	protected override void Start () {
        base.Start();		//Call base class start
		Vector2 tDirection = Utilities.RandomDirection;		//Use utility function
		tDirection *= Random.Range (.5f, 5f);
		mRB.AddForce (tDirection, ForceMode2D.Impulse);		//Make it move by applying force impulse
		AsteroidCount++;	//When asteroid created, increase count
	}

    protected override void ObjectHit(Entity vOtherEntity)	//Override Entity Object hit, NB Asteroids only care about being hit by a bullet
    {
		if (vOtherEntity.GetType () == typeof(Bullet)) {		//Has the asteroid hit a bullet
			HitByBullet ((Bullet)vOtherEntity);
		} else if (vOtherEntity.GetType () == typeof(PlayerShip)) {		//Has Asteroid hit player
			HitByPlayer ((PlayerShip)vOtherEntity);
		} 
    }

	protected virtual void HitByBullet(Bullet vBullet) {		//This can be overridden by more specific behaviour
																//default is to explode and self destruct Asteriod & bullet
		Explode ();				//Explode this Asteroid
		vBullet.Kill ();		//Tell Bullet to destroy itself
		GM.sGM.AddScore(Score);		//Give correct score for hit, depending on Asteroid type
	}

	protected virtual void HitByPlayer(PlayerShip vPlayer) {		//This can be overridden by more specific behaviour
		Explode ();						//Explode this Asteroid, dont give score
		Debug.Log ("Player would have died");		//Cheat mode
	}


	static	public	void	SpawnNew(Vector2 vPositon,int vCount, AsteroidType vType) {
		for (int i = 0; i < vCount; i++) {
			Instantiate (GM.sGM.Asteroids [(int)vType], vPositon, Quaternion.identity);		//Set up new set of new Asteroids
		}
	}

	void OnDestroy() {		//When asteroid destroyed, reduce count
		AsteroidCount--;
	}
}