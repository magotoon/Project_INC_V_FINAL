using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player_Movement1 : MonoBehaviour {

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
	private Health1 pHealth;
	public GameObject spawnPoint;
	private HealthBar1 hBar;
	private GameObject l11;
	private GameObject l21;
	private GameObject l31;



    private void Start()
	{
        body = GetComponent<Rigidbody2D>();
		pHealth = (Health1)FindObjectOfType (typeof(Health1));
		hBar = (HealthBar1)FindObjectOfType (typeof(HealthBar1));
		transform.position = spawnPoint.transform.position;
		l11 = GameObject.FindGameObjectWithTag ("L11");
		l21 = GameObject.FindGameObjectWithTag ("L21");
		l31 = GameObject.FindGameObjectWithTag ("L31");
	}

	void Update()
    {
        vAxis = Input.GetAxis("VerticalS2");
        hAxis = Input.GetAxis("HorizontalS2");

		if (pHealth.playerHealth <= 0) 
		{
			if (pHealth.livesLeft <= 0) 
			{
				Destroy (l11);
				Debug.Log ("destroying player2????");
				Destroy (gameObject);
				Application.LoadLevel ("P1WinScreen");
			} 
			else 
			{
				switch (pHealth.livesLeft) 
				{
				case 1:
					Destroy (l21);
					break;
				case 2:
					Destroy (l31);
					break;
				}
				pHealth.livesLeft--;
				pHealth.playerHealth = 100;
				hBar.hitpoint = hBar.maxHitpoints;
				hBar.UpdateHealthBar ();
				Respawn ();
			}
		}

    //    Debug.Log("vAxis: " + vAxis);
    //    Debug.Log("hAxis: " + hAxis);

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

		float TurnV = Input.GetAxis ("TurnV2");
		float TurnH = Input.GetAxis ("TurnH2");

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
		// TODO Add respawn animation/death animation
		transform.position = spawnPoint.transform.position;	
	}


}
