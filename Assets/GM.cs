using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour {


	public	GameObject[]	Asteroids;		//Linked in IDE, to 3 types of asteroids
	public	GameObject		Explosion;


	public	bool	GameOver=false;		//Global game over flag

	public	static	GM	sGM;		//Creates a singleton, allowing static access to data and helper code

	private	int		Score = 0;

	void Awake () {		//Runs before Start
		if (sGM == null) {
			sGM = this;		//First Time creation of Game Manager
		} else if (sGM != this) { //If we get called again, then destroy new version and keep old one
			Destroy (gameObject);
		}
	}

	public	float	ScreenWidth {	//Helper code, allows singleton to be used to get Width & Height
		get {
			return	Camera.main.orthographicSize * Camera.main.aspect;
		}
	}

	public	float	ScreenHeight {		//Screen Height
		get {
			return	Camera.main.orthographicSize;
		}
	}

	public	Vector2	RandomPosition {		//Make Random on screen position
		get {
			return	new Vector2 (Random.Range (-ScreenWidth, ScreenWidth), Random.Range (-ScreenHeight, ScreenHeight));		//Random position
		}
	}

	void	Start() {	//No used as Update checks if restart is needed
	}

	void	NewGame() {
		AsteroidBase.SpawnNew (RandomPosition, 5, AsteroidBase.AsteroidType.Big);		//Call static spawn function
		GameOver = false;
		Score = 0;
	}


	public	void	AddScore(int vScore) {			//Add to score
		Score += vScore;
		Debug.LogFormat ("Score {0:d}", Score);
	}
	
	void Update () {
		CheckNewGame ();
	}

	void	CheckNewGame() {
		if (!GameOver && AsteroidBase.AsteroidCount == 0) {			//If in game, reaching 0 asteroids tiggers endgame
			GameOver = true;
			Debug.Log ("Game Over");
			Invoke ("NewGame", 2.0f);		//Start new game in 2 seconds
		}
	}
}
