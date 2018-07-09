using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Actions : MonoBehaviour {
	private static float cooldown = 0.5f;
	public GameObject projectile;
	public float fireRate;
	public float projSpeed;
	public float damage;
	public float cooldownTime = cooldown;
	private bool canFire = true;
	private float vAxis;
	private float hAxis;



	private void Awake(){
	

	
	}



	// Update is called once per frame
	void Update () {

		//vAxis = Input.GetAxis ("VerticalS");
		//hAxis = Input.GetAxis ("HorizontalS");
		//
		//if (vAxis > 0) {
		
		//	Debug.Log ("You touched the JS");
	//	}



		//Vector2 shootDirection = new Vector2 (Input.GetAxis ("HorizontalJS"), (Input.GetAxis ("VerticalJS")));


		if(Input.GetButton("Fire1") && canFire){

			//Debug.Log ("You got input!");

			fireProjectile ();
			canFire = false;
		}

		if (canFire == false) {
			if (cooldownTime > 0) {
				cooldownTime -= Time.deltaTime;

			} 
			else {
				cooldownTime = cooldown;
				canFire = true;
			}
		}
				
		
	}

	void fireProjectile(){

	
		GameObject clone = (GameObject)Instantiate (projectile, GetComponent<Rigidbody2D>().transform.position, GetComponent<Rigidbody2D>().transform.rotation);

	}


}
