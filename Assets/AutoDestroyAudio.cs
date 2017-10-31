using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroyAudio : MonoBehaviour {


    //Self destruct once effect is over
    void Start () {
        AudioSource tAS = GetComponent<AudioSource>();        
        Destroy(gameObject, tAS.clip.length);
	}
}
