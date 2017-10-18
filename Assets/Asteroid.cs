using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {

	Rigidbody2D	mRB;

	// Use this for initialization
	void Start () {
		Vector2 tDirection = Vector2.up;
		tDirection = Quaternion.Euler (0, 0, Random.Range (0, 360))
						* tDirection;
		tDirection *= Random.Range (.5f, 15f);
		mRB = GetComponent<Rigidbody2D> ();
		mRB.AddForce (tDirection, ForceMode2D.Impulse);
	}
	
	// Update is called once per frame
	void LateUpdate () {
		mRB.position = Utilities.WrapPosition (Camera.main, mRB.position);
	}
}
