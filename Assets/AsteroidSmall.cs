using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSmall : AsteroidBase {

	public	override int Score { 		//Override with score for this Asteroid
		get {
			return	40;
		}
	}

	protected override void HitByPlayer(PlayerShip vPlayer) {
		base.HitByPlayer (vPlayer);
	}

	protected override void HitByBullet(Bullet vBullet) {
		base.HitByBullet (vBullet);		//Smallest asteroid does not split, so just destroy
	}
}
