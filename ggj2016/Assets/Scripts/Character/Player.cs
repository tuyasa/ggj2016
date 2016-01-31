using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

	private Animator anim;

	Controller2D controller;
	Vector2 input;
	float horizontalMove;
	float smoothX;
	bool facingRight;

	public float accelerationOnGround;
	public float accelerationOnAir;
	public float moveSpeed;
	public float gravity = -50f;
	public float jumpMagnitude = 20f;
	public GameObject itemHolder;

	public delegate void actionObject (GameObject go);

	public actionObject a0;
	[HideInInspector]
	public float verticalMove;
	[HideInInspector]
	public bool teleport;
	[HideInInspector]
	public bool freeze;
	[HideInInspector]
	public bool canJump;

	public bool canOpenDoor;

	[HideInInspector]
	public int score;
	// Use this for initialization
	void Start ()
	{
		score = 0;
		canJump = true;
		canOpenDoor = true;
		anim = GetComponent<Animator> ();
		controller = GetComponent<Controller2D> ();
		facingRight = transform.localScale.x > 0;
	}
	
	// Update is called once per frame
	void Update ()
	{
		UpdateAnimator ();
		if (!freeze)
			horizontalMovement ();
		teleport = false;
		if (Input.GetButtonDown ("Fire1"))			
		{
			teleport = true;
		}
		if(Input.GetButtonDown("Fire2") && canOpenDoor)
		{
			GetComponent<SlamDoor>().slam();
		}
		if (Input.GetButtonDown ("Jump") && canJump)
			Jump ();
	}

	void horizontalMovement ()
	{
		horizontalMove = Input.GetAxisRaw ("Horizontal");
		if (horizontalMove == 1) {
			if (!facingRight)
				Flip ();
		} else if (horizontalMove == -1) {
			if (facingRight)
				Flip ();
		}

		float targetVelocityX = horizontalMove * moveSpeed;
		controller.SetHorizontalForce (Mathf.SmoothDamp (controller.speed.x, targetVelocityX, ref smoothX, controller.collisions.below ? accelerationOnGround : accelerationOnAir));
	}

	public void Jump ()
	{
		if (controller.collisions.below) {
			controller.SetVerticalForce (jumpMagnitude);
		}
	}

	void Flip ()
	{
		transform.localScale = new Vector3 (-transform.localScale.x, transform.localScale.y, transform.localScale.z);
		facingRight = transform.localScale.x > 0;
	}

	private void UpdateAnimator ()
	{
		anim.SetFloat ("Speed", Mathf.Abs (controller.speed.x));
	}

	public void freezeMovement (float time)
	{
		StartCoroutine("FreezeCoroutine",time);
	}

	IEnumerator FreezeCoroutine (float time)
	{
		freeze = true;
		canJump = false;
		horizontalMove = 0f;
		controller.SetHorizontalForce(0f);
		yield return new WaitForSeconds (time);
		freeze = false;
		canJump = true;
	}

}
