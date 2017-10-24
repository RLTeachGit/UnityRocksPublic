using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidBig : AsteroidBase {
    
    //Override with score for this Asteroid
    public override int Score { 		
		get {
			return	10;
		}
	}
						
	protected override void HitByPlayer(PlayerShip vPlayer) {
		base.HitByPlayer (vPlayer);		//Call base function
		SpawnNew (transform.position, 2, (AsteroidType.Medium));
	}

    //Big asteroid uses default behaviour, but modifies it to make 2 medium asteroids
    protected override void HitByBullet(Bullet vBullet) {
		base.HitByBullet (vBullet);		//Default destroy for bullet and old Asteroid
		SpawnNew (transform.position, 2, AsteroidType.Medium);
	}
}
