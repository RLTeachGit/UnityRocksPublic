using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;		//Needed for UI interface

public class UI : MonoBehaviour {


	public	Text	ScoreText;				//Link in IDE
	public	Text	AsteroidCountText;		//Link in IDE

	void Start () {
		GM.sGM.mUI = GetComponent<UI> ();		//Link UI updater into Game Manager, once stored in GM can be accessed by all
	}

	public	void	UpdateScore(int vScore) {		//Update on sceen score
		ScoreText.text = string.Format ("Score {0:d}", vScore);
	}

	public	void	UpdateAsteroidCount(int vCount) {		//Update on sceen Count
		AsteroidCountText.text = string.Format ("Count {0:d}", vCount);
	}

}
