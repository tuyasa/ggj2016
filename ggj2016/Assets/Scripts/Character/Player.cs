using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public AnimationCurve animCurve;

	Controller2D controller;
	Vector2 input;
	float horizontalMove;
	float smoothX;
	bool facingRight;

	public float accelerationOnGround;
	public float moveSpeed;
	public float gravity = -50f;
	public float jumpMagnitude =20f;
	// Use this for initialization
	void Start () {
		 controller = GetComponent<Controller2D>();
		 facingRight = transform.localScale.x > 0;
	}
	
	// Update is called once per frame
	void Update () {
		horizontalMovement();
		if(Input.GetButtonDown("Jump"))
			Jump();
	}

	void horizontalMovement()
	{
		horizontalMove =  Input.GetAxisRaw("Horizontal");
		if(horizontalMove == 1)
		{
			if(!facingRight)
				Flip();
		}else if( horizontalMove == -1){
			if(facingRight)
				Flip();
		}

		float targetVelocityX = horizontalMove * moveSpeed;
		controller.SetHorizontalForce(Mathf.SmoothDamp(controller.speed.x,targetVelocityX,ref smoothX,accelerationOnGround));
	}

	public void Jump()
	{
		if(controller.collisions.below)
		{
			controller.SetVerticalForce(jumpMagnitude);
		}
	}
	void Flip()
	{
		transform.localScale = new Vector3 (-transform.localScale.x, transform.localScale.y, transform.localScale.z);
		facingRight = transform.localScale.x > 0;
	}
}
