using UnityEngine;
using System.Collections;

public class EnemyBaseBall : MonoBehaviour {


	public Vector2 speed = new Vector2(1, 1);
	
	/// <summary>
	/// Moving direction
	/// </summary>
	public Vector2 direction = new Vector2(-1, 0);

	public 	bool facingRight = false;
	
	private Vector2 movement;

	void Awake()
	{
		movement = new Vector2(speed.x * direction.x, speed.y * direction.y);
	}

	
	void FixedUpdate ()
	{
		rigidbody2D.velocity = movement;		
	
	}

	void OnTriggerEnter2D(Collider2D col)	
	{
		// If any of the colliders is an Obstacle...

		if(col.tag == "Obstacle")
		{
			if(facingRight)// ... Flip the enemy and stop checking the other colliders.
			{
				Flip ();
				movement = new Vector2(
				speed.x * -direction.x,
				speed.y * direction.y);

			
			}//if

			else if(!facingRight)
			{

				Flip ();
				direction = new Vector2(1, 0);
				movement = new Vector2(
				speed.x * direction.x,
				speed.y * direction.y);

			}//else if

		}//if
	}//OnTriggerEnter2D
	
	public void Flip()
	{
		facingRight = !facingRight;

		// Multiply the x component of localScale by -1.
		Vector3 enemyScale = transform.localScale;
		enemyScale.x *= -1;
		transform.localScale = enemyScale;
	}
}
