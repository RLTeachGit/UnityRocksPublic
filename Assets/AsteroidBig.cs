using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidBig : AsteroidBase {

	public	override int Score { 		//Override with score for this Asteroid
		get {
			return	10;
		}
	}
						
	protected override void HitByPlayer(PlayerShip vPlayer) {
		base.HitByPlayer (vPlayer);		//Call base function
		SpawnNew (transform.position, 2, (AsteroidType.Medium));
	}

	protected override void HitByBullet(Bullet vBullet) {		//Big asteroid uses default behaviour, but modifies it to make 2 medium asteroids
		base.HitByBullet (vBullet);		//Default destroy for bullet and old Asteroid
		SpawnNew (transform.position, 2, AsteroidType.Medium);
	}
}
