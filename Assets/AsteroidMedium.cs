using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMedium : AsteroidBase { //Medium asteroid uses default behaviour, but modifies it to make 3 small asteroids

	public	override int Score { 		//Override with score for this Asteroid
		get {
			return	20;
		}
	}

	protected override void HitByPlayer(PlayerShip vPlayer) {
		base.HitByPlayer (vPlayer);
		SpawnNew (transform.position, 3, AsteroidType.Small);
	}

	protected override void HitByBullet(Bullet vBullet) {
		base.HitByBullet (vBullet);		//Default destroy for bullet and old Asteroid
		SpawnNew (transform.position, 3, AsteroidType.Small);
	}
}
