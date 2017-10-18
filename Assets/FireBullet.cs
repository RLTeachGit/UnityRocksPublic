using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour {

    public Bullet BulletPrefab; //Link to Bullet Prefab in IDE
    public GameObject Gun;      //Link to Gun position on ship in IDE
    public float FirePerSec = 0.2f;       //5 per second

    Rigidbody2D mRB;

    float mCoolDown=0.0f;   //So you can't rapid fire

	// Use this for initialization
	void Start () {
        if(BulletPrefab==null)      //Needs to be attached in IDE
        {
            Debug.LogError("No Bullet Prefab"); //Error if this does not reference a bullet object
        }
        mRB = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if(mCoolDown<0.0f)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Bullet tBullet = Instantiate(BulletPrefab);
                Vector2 tFireDirection = Utilities.DirectionOfMotion2D(mRB.rotation);
				tFireDirection += mRB.velocity;
                tBullet.Fire(Gun.transform.position, tFireDirection);
                mCoolDown = FirePerSec;       //Fire rate
            }
        } else
        {
            mCoolDown -= Time.deltaTime;
        }
    }
}
