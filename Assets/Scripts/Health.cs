using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	public int playerHealth = 100;
	public int livesLeft = 2;
	public int damage = 10;

	private GameObject player;


	void Start () {

		print (playerHealth);
		player = GameObject.FindGameObjectWithTag ("Player1");
		
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
