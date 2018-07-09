using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health1 : MonoBehaviour {

	public int playerHealth = 100;
	public int livesLeft = 2;
	public int damage = 10;

	private GameObject player;


	void Start () {

		print (playerHealth);
		player = GameObject.FindGameObjectWithTag ("Player2");
		
	}

	void update () {
	}
	
	//void OnTriggerEnter2D(Collider2D collision)
	//{
	//	if (collision.gameObject.tag == "bullet") {
	//		playerHealth -= damage;
	//		Debug.Log ("black just rocked you" + playerHealth);
	//
	//	}
	//}
}
