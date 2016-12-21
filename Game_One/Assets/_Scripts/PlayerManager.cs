using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour 
{
	Animator anim;
	Rigidbody2D myRigidBody;
 	bool walk, facingRight, jumping, grounded;
	float speed, jumpTimeCounter, speedMilestoneCount;
	public float speedX = 1.0f;
	public float speedMultiplier = 0.1f;
	public float speedIncreaseMilestone = 100f;
	public float jumpSpeedY = 1.0f;
	public float jumpTime = 0.1f;
	public GameManager gameManager;

	//public Transform groundCheck;
	//public float groundCheckRadius = 1f;
	//public LayerMask groundMask;

	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator> ();
		myRigidBody = GetComponent<Rigidbody2D> ();
		walk = false;
		facingRight = true;
		grounded = false;
		jumpTimeCounter = jumpTime;
		speedMilestoneCount = speedIncreaseMilestone;
	}
	
	// Update is called once per frame
	void Update () 
	{
		//grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, groundMask);
		// player movement
		MovePlayer (speed);

		// player jump
		if (Input.GetKeyDown (KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space)) 
		{
			Jump ();
		}

		if (Input.GetKey (KeyCode.UpArrow) || Input.GetKey (KeyCode.Space))
		{
			if (jumpTimeCounter > 0) 
			{
				Jump ();
				jumpTimeCounter -= Time.deltaTime;
			}
		}

		if (Input.GetKeyUp (KeyCode.UpArrow) || Input.GetKeyUp (KeyCode.Space)) 
		{
			jumpTimeCounter = 0;
			grounded = false;
		}
	}

	void MovePlayer (float playerSpeed)
	{
		// code for player movement
		myRigidBody.velocity = new Vector3(speed, myRigidBody.velocity.y, 0);

		if (playerSpeed < 0 && !jumping || playerSpeed > 0 && !jumping)
		{
			anim.SetInteger ("State", 2);
		}
		if (playerSpeed == 0 && !jumping) 
		{
			anim.SetInteger ("State", 0);
		}

		if (transform.position.x > speedMilestoneCount) 
		{
			speedMilestoneCount += speedIncreaseMilestone;
			speedIncreaseMilestone = speedIncreaseMilestone * speedMultiplier;
			speedX = speedX * speedMultiplier;
		}

		// for auto running //
		speed = speedX;
		//anim.SetInteger ("State", 2);



	}
		
	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Ground" || other.gameObject.tag == "Objects") 
		{
			jumping = false;
			grounded = true;
			anim.SetInteger ("State", 0);
			jumpTimeCounter = jumpTime;
		}

		if (other.gameObject.tag == "Objects")
		{
			Application.LoadLevel (0);
		}
	}
		
	public void Jump()
	{
		if (grounded) 
		{
			myRigidBody.velocity = (new Vector2 (myRigidBody.velocity.x, jumpSpeedY));
			jumping = true;
			anim.SetInteger ("State", 3);
		}
	}




	/*
	void toggleWalk()
	{
		if (walk == true)
			walk = false;
		else
			walk = true;
	}

	public void WalkLeft()
	{
		speed = -speedX;
	}

	public void WalkRight()
	{
		speed = speedX;
	}

	public void StopMoving()
	{
		speed = 0;
	}
	*/

	/**
		// left player movement
	if (Input.GetKeyDown (KeyCode.LeftArrow)) 
	{
		speed = -speedX;
	}
	if (Input.GetKeyUp (KeyCode.LeftArrow)) 
	{
		speed = 0;
	}

	// right player movement
	if (Input.GetKeyDown (KeyCode.RightArrow)) 
	{
		speed = speedX;
	}
	if (Input.GetKeyUp (KeyCode.RightArrow)) 
	{
		speed = 0;
	}
	**/

/**
	if (walk == true) {
		// handling the idle - walking - idle state change
		if (Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.LeftArrow)) {
			anim.SetInteger ("State", 1);
			transform.Translate (Vector3.right * Time.deltaTime);
		}
		if (Input.GetKeyUp (KeyCode.RightArrow) || Input.GetKeyUp (KeyCode.LeftArrow)) {
			anim.SetInteger ("State", 0);
		}
		//
	} else {
		// handling the idle - running - idle state change
		if (Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.LeftArrow)) {
			anim.SetInteger ("State", 2);
			transform.Translate (Vector3.right * Time.deltaTime * speedX);
		}
		if (Input.GetKeyUp (KeyCode.RightArrow) || Input.GetKeyUp (KeyCode.LeftArrow)) {
			anim.SetInteger ("State", 0);
		}
	}

	if (Input.GetKey (KeyCode.R)) {
		toggleWalk ();
	}
	**/

	/**
	void Flip()
	{
		// code to flip the player direction

		if (speed > 0 && !facingRight || speed < 0 && facingRight) 
		{

			facingRight = !facingRight;
			Vector3 temp = transform.localScale;
			temp.x *= -1;
			transform.localScale = temp;
		}
	}
	**/
}
