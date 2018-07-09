using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Movement : MonoBehaviour {

    public float maxSpeed = 10f;
	public float turnSpeed;
    private float speed = 0;
    private float vAxis;
    private float hAxis;
	private float speedMultipler;
	protected float aimAngle;
	protected Quaternion aimRotation;
	protected Vector2 aimDirection;
    private Rigidbody2D body;
    private Vector2 direction;
	private Health pHealth;
	public GameObject spawnPoint;
	private HealthBar hBar;
	private GameObject l12;
	private GameObject l22;
	private GameObject l32;


    private void Start()
	{
        body = GetComponent<Rigidbody2D>();
		pHealth = (Health)FindObjectOfType (typeof(Health));
		hBar = (HealthBar)FindObjectOfType (typeof(HealthBar));
		transform.position = spawnPoint.transform.position;
		l12 = GameObject.FindGameObjectWithTag ("L12");
		l22 = GameObject.FindGameObjectWithTag ("L22");
		l32 = GameObject.FindGameObjectWithTag ("L32");

	}

	void Update()
    {
        vAxis = Input.GetAxis("VerticalS");
        hAxis = Input.GetAxis("HorizontalS");

		if (pHealth.playerHealth <= 0) 
		{
			if (pHealth.livesLeft <= 0) 
			{
				Destroy (l12);
				Debug.Log ("destroying player1????");
				Destroy (gameObject);
				Application.LoadLevel ("P2WinScreen");

			} 
			else 
			{
				switch (pHealth.livesLeft) 
				{
				case 1:
					Destroy (l22);
					break;
				case 2:
					Destroy (l32);
					break;
				}
				pHealth.livesLeft--;
				pHealth.playerHealth = 100;
				hBar.hitpoint = hBar.maxHitpoints;
				hBar.UpdateHealthBar ();
				Respawn ();
			}
		}

   //     Debug.Log("vAxis: " + vAxis);
   //     Debug.Log("hAxis: " + hAxis);

        if (speed > 0)
        {
            // reduce speed
            speed -= 0.2f;

            // Prevent speed from going below zero
            if (speed < 0)
            {
                speed = 0;
            }
        }
		if (vAxis > 0.019 || vAxis < -0.019 || hAxis > 0.019 || hAxis < -0.019) {
			PushShip ();
		} else {
			speedMultipler = 0f;
		}

		float TurnV = Input.GetAxis ("TurnV");
		float TurnH = Input.GetAxis ("TurnH");

		if (TurnV != 0 && TurnH != 0) {

			aimDirection = new Vector2 (TurnH, TurnV);
			aimAngle = Mathf.Atan2 (-TurnH, -TurnV) * Mathf.Rad2Deg;
		
			aimRotation = Quaternion.AngleAxis (aimAngle, Vector3.forward);
			body.transform.rotation = Quaternion.Slerp (body.transform.rotation, aimRotation, turnSpeed * Time.time);
		
		}
			
    }

    private void PushShip() {
        
		speedMultipler += .7f;
		speed = Mathf.Pow(maxSpeed, Time.deltaTime);

        if (speed > maxSpeed)
        {
            speed = maxSpeed;
        }
        direction = new Vector2(hAxis, vAxis) * speed;
        body.AddForce(direction);
    }

	public void Respawn () 
	{
		transform.position = spawnPoint.transform.position;

	}


}
