using UnityEngine;
using System.Collections;

public class Controller2D : MonoBehaviour {

	public LayerMask collisionsMask;
	private BoxCollider2D boxColllider;

	[HideInInspector]
	public RayCastOrigins rayCastOrigins;
	public CollisionsInfo collisions;

	public int horizontalRayCount;
	public int verticalRayCount;
	public float verticalRaySpacing;
	public float horizontalRaySpacing;

	private float Gravity = -20f;
	public Vector2 speed;

	private float littleValue = 0.01f;

	private float maxVelocity = 50f;

	public void SetForce(Vector2 force)
	{
		speed = force;
	}
	public void SetHorizontalForce(float x)
	{
		speed.x = x;
	}
	public void SetVerticalForce(float y)
	{
		speed.y = y;
	}
	// Use this for initialization
	void Start () {	
		boxColllider = GetComponent<BoxCollider2D>();
		CalculateRaySpacing();
	}
	
	// Update is called once per fra
	void LateUpdate () {

		speed.y += Gravity * Time.deltaTime;
<<<<<<< HEAD:ggj2016/Assets/Scripts/Character/Controller2DPlayer.cs
		//Debug.Log(collisions);
=======
>>>>>>> bd1e7da5c3cc463d508c2cb0c57e5b51f5d58619:ggj2016/Assets/Scripts/Character/Controller2D.cs
		Move(speed * Time.deltaTime);

		if(collisions.below || collisions.above)
			speed.y = 0;
	}

	public void Move(Vector2 velocity)
	{
		UpdateRayOrigins();
		collisions.Reset();

		HorizontalCollision(ref velocity);

		if(velocity.y != 0)
			VerticalCollisions(ref velocity);

		Mathf.Clamp(velocity.x,-maxVelocity,maxVelocity);
		Mathf.Clamp(velocity.y,-maxVelocity,maxVelocity);

		transform.Translate(velocity);
	}

	void HorizontalCollision(ref Vector2 velocity)
	{
		float directionX = Mathf.Sign(velocity.x);
		float rayLength = Mathf.Abs(velocity.x);

		for (int i = 0; i < horizontalRayCount; i++) {
			Vector2 rayOrigin = (directionX == 1) ? rayCastOrigins.bottomRight : rayCastOrigins.bottomLeft;
			rayOrigin += (horizontalRaySpacing *i) * Vector2.up;
			RaycastHit2D hit =  Physics2D.Raycast(rayOrigin, Vector2.right * directionX,rayLength,collisionsMask);

			Debug.DrawRay(rayOrigin, directionX * Vector2.right, Color.red);

			if(hit)
			{
				velocity.x = (hit.distance - littleValue) * directionX;
				rayLength = hit.distance;
				collisions.left = directionX == -1;
				collisions.right = directionX == 1;
			}
		}
	}
	void VerticalCollisions(ref Vector2 velocity)
	{
		float directionY = Mathf.Sign(velocity.y);
		float rayLength = Mathf.Abs(velocity.y) + littleValue;

		for (int i = 0; i < verticalRayCount; i++) {
				Vector2 rayOrigin = (directionY ==1) ? rayCastOrigins.topLeft :  rayCastOrigins.bottomLeft;

				rayOrigin += (verticalRaySpacing * i + velocity.x) * Vector2.right;

				RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.up * directionY,rayLength,collisionsMask);

				Debug.DrawRay(rayOrigin, directionY * Vector2.up, Color.red);

				if(hit)
				{
					velocity.y = (hit.distance - littleValue) * directionY;
					rayLength = hit.distance;
					collisions.below = directionY == -1;
					collisions.above = directionY == 1;
				}
		}
	}

	void CalculateRaySpacing() {
		Bounds bounds = boxColllider.bounds;
		
		horizontalRayCount = Mathf.Clamp (horizontalRayCount, 2, int.MaxValue);
		verticalRayCount = Mathf.Clamp (verticalRayCount, 2, int.MaxValue);
		
		horizontalRaySpacing = bounds.size.y / (horizontalRayCount - 1);
		verticalRaySpacing = bounds.size.x / (verticalRayCount - 1);
	}
	void UpdateRayOrigins()
	{
		Bounds bounds  = boxColllider.bounds;
		rayCastOrigins.bottomLeft = new Vector2(bounds.min.x, bounds.min.y);
		rayCastOrigins.bottomRight = new Vector2(bounds.max.x,bounds.min.y);
		rayCastOrigins.topLeft = new Vector2(bounds.min.x,bounds.max.y);
		rayCastOrigins.topRight = new Vector2(bounds.max.x,bounds.max.y);
	}

	public struct RayCastOrigins {
		public Vector2 topLeft,  topRight;
		public Vector2 bottomLeft,  bottomRight;

	}
	public struct CollisionsInfo {
		public bool above, below;
		public bool left, right;
		public void Reset()
		{
			above = below = left= right = false;
		}
		public override string ToString ()
		{
			return string.Format ("[CollisionsInfo: above={0}, below={1}, left={2}, right={3}]", above, below, left, right);
		}
		
	}
}
