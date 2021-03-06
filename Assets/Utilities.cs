﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Some useful utility functions
static  public class Utilities {
    //Need to pass in camera as a static cannot inherit from MonoBehaviour
    public static  Vector3 WrapPosition(Camera vCamera, Vector3 vPosition)     
    {
        //Get current width and Height
        //Height is given for orthographic camera
        float tHalfScreenHeight = vCamera.orthographicSize;
        //Width is worked out, from height and aspect ratio
        float tHalfScreenWidth = vCamera.aspect * tHalfScreenHeight;

        //Horizontal
        if (vPosition.x > tHalfScreenWidth)
        {  //Check right of screen
            //Adjust screen position to move right by whole screen
            vPosition.x -= tHalfScreenWidth * 2.0f;
        }
        else if (vPosition.x < -tHalfScreenWidth)
        { //Check left of screen
            //Adjust screen position to move left
            vPosition.x += tHalfScreenWidth * 2.0f;
        }

        //Vertical
        if (vPosition.y > tHalfScreenHeight)
        {  //Check top of screen
            //Adjust screen position to move down by whole screen
            vPosition.y -= tHalfScreenHeight * 2.0f;
        }
        else if (vPosition.y < -tHalfScreenHeight) //Check bottom of screen
        {
            //Adjust screen position to move down
            vPosition.y += tHalfScreenHeight * 2.0f;
        }
        return vPosition; //Return position with wrap, if needed
    }


    //Helper function to work out a unit vector pointing
    //in direction of ship sprite's direction
    public  static  Vector2 DirectionOfMotion2D(float vAngle)
    {
        return new Vector2(-Mathf.Sin(vAngle * Mathf.Deg2Rad),      //X
                            Mathf.Cos(vAngle * Mathf.Deg2Rad));     //Y
    }

	public	static	Vector2	RandomDirection {		//Make random direction Unit Vector
		get {
			return	Quaternion.Euler (0, 0, Random.Range (0, 360))* Vector2.up;
		}
	}


    //Very slow
    static  public T TimedFindComponentByType<T>() where T : Component
    {
        System.Diagnostics.Stopwatch tSW = new System.Diagnostics.Stopwatch();  //Time how long it takes to find Item
        T tClass = default(T);
        tSW.Start();
        tClass = GameObject.FindObjectOfType<T>();       //Search for GM by type
        tSW.Stop();
        Debug.LogFormat("{0:s}() {1:d}", System.Reflection.MethodBase.GetCurrentMethod().Name, tSW.Elapsed.Ticks);
        return tClass;
    }


    //Suprisingly quite fast
    static public T TimedFindComponentByTag<T>(string vTag) where T : Component
    {
        System.Diagnostics.Stopwatch tSW = new System.Diagnostics.Stopwatch();  //Time how long it takes to find Item
        tSW.Start();
        GameObject tGO = GameObject.FindWithTag(vTag);       //Search for GM by tag;
        T tComponent = default(T);
        if (tGO)
        {
            tComponent = tGO.GetComponent<T>();
        }
        tSW.Stop();
        Debug.LogFormat("{0:s}() {1:d}", System.Reflection.MethodBase.GetCurrentMethod().Name, tSW.Elapsed.Ticks);
        return tComponent;
    }
}
