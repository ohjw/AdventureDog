using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{
	[HideInInspector]
	public bool facingRight = false; // For determining which way the player is currently facing.

	[HideInInspector]
	public bool jump = false; // Condition for whether the player should jump.

	[HideInInspector]
	public bool bapmode = false; // player transforms into this when true

	//MOVEMENT
	public float move;
	public float moveForce = 365f; // Amount of force added to move the player left and right.
	public float maxSpeed = 10f;  // The fastest the player can travel in the x axis.
	public float jumpForce = 300f; // Amount of force added when the player jumps.
 
	//AUDIO
	public AudioClip jumping;
	public AudioClip bapTransformation;
	public AudioClip enemyDefeated;
	public AudioClip checkpointReached;
	public AudioClip taunt;

	//GUI
	public GameObject checkpointText;
	public GameObject levelCompleteText;
	public GameObject levelCompleteInfoText;
	public GameObject levelCompleteReturn;

	//DYING 
	public Transform newSpawnPoint; //getting spawnpoint of player
	public AudioClip dyingShout; //played during dying scene
	public GameObject player;
	public static bool dead;
	private GameCamera cc;
	private bool levelComplete = false;

	//ANIMATION
	private Animator anim;	// Reference to the player's animator component.

	void Start()
	{
		anim = GetComponent<Animator> (); // get players animator

		//getting texts 
		checkpointText = GameObject.Find("CheckpointText");
		levelCompleteText = GameObject.Find("LevelCompleteText");
		levelCompleteInfoText = GameObject.Find ("LevelCompleteInfoText");
		levelCompleteReturn = GameObject.Find ("LevelCompleteReturn");

	}//Start

	void FixedUpdate()
	{

		//if level is completed then player has option to replay/return to menu
		if(levelComplete == true)
		{
			if(Input.GetKey(KeyCode.M))
			{
				Application.LoadLevel("MainMenu");
			}//if

			if(Input.GetKey(KeyCode.R))
			{
				Application.LoadLevel("Game");
			}//if
		}//if

		// If the jump button (spacebar) is pressed then the player should jump
		if (Input.GetButtonDown ("Jump")) 
		{
			jump = true;
		}//if

		//if T is pressed then this activates bapmode
		if(Input.GetKeyDown(KeyCode.T))
		{

			if(!bapmode)
			{
				
				bapmode = true;
				audio.clip = bapTransformation;
				audio.Play ();
				
			}//if
			
			else
			{
				anim.SetBool("BapMode", false);	

				bapmode = false;
				
			}//else
		}//if
		
		//cache the horizontal input.
		 move = Input.GetAxis("Horizontal");
		
		//speed animator parameter is set to the absolute value of the horizontal input.
		anim.SetFloat("Speed", Mathf.Abs(move));

		rigidbody2D.velocity = new Vector2 (move * maxSpeed, rigidbody2D.velocity.y);
		
		//if the input is moving the player right and the player is facing left...
		if (move > 0 && !facingRight)
			//flip the player.
			Flip();

		//if the input is moving the player left and the player is facing right...
		else if (move < 0 && facingRight)
			//flip the player.
			Flip();
		
		// if the player jumps
		if(jump)
		{
			audio.clip = jumping;
			audio.Play(); // play jump sound
	
			// add a vertical force to the player.
			rigidbody2D.AddForce(Vector2.up * jumpForce);

			// make sure the player can't jump again until the jump conditions from Update are satisfied.
			jump = false;
		}//if

		if (bapmode) 
		{
		 	anim.SetBool("BapMode", true);	
		}//if


	}//FixedUpdate

	void OnTriggerEnter2D(Collider2D col)
	{
		//if player collides with the deadzone
		if(col.tag == "Deadzone")
		{
			Debug.Log ("Player has hit the deadzone");
			//if the player dies then call this 
			StartCoroutine("Died"); 
					
		}//if

		if(col.tag =="Checkpoint")
		{
			Debug.Log("Checkpoint reached");

			audio.clip = checkpointReached; // play checkpoint reached sound
			audio.Play ();
			checkpointText.guiText.text = "Checkpoint Reached!";

			//reloating the spawn point based on the position of the checkpoint reached
			GameObject.Find("SpawnPoint").transform.position = transform.position;

		}//if

		if(col.tag == "Enemy")
		{
			if(bapmode)
				return;
			else
			StartCoroutine("Died"); 

		}//if

		if(col.tag == "TauntZone")
		{
			//play taunt near enemy
			audio.clip = taunt;
			audio.Play ();
		}//if

		if(col.tag == "EndOfLevel")
		{
			//update GUI texts
			levelCompleteText.guiText.text = "Success!";
			levelCompleteInfoText.guiText.text = "Adventure Dog has been reunited with Fry Girl!";
			levelCompleteReturn.guiText.text = "Press M to return to menu OR R to Replay";

			levelComplete = true;
		}//if

	}//OnTriggerEnter2D

	void OnTriggerExit2D(Collider2D col)
	{
		if(col.tag == "Checkpoint")
		{
			checkpointText.guiText.text = ""; //restart text time display nothing
			Destroy(col.gameObject); //destroy checkpoint

		}//if
	}//OnTriggerExit2D

	IEnumerator Died()
	{
		Debug.Log ("Player has died");

		//set dead to true 
		dead = true;
	
		anim.SetBool("Dead",true);//show dead animation
		
		//play the dying shout audio
		audio.clip = dyingShout;
		audio.Play();

		//2 second wait then do the below 
		//so the animation plays for a bit for respawning character
		yield return new WaitForSeconds(2);

		Debug.Log ("Life has been lost");
		PlayerHealth.health--;
		    
		if(bapmode) //dont reduce life in bapmode
		{
			PlayerHealth.health++;
			dead = false;//revive player

			Debug.Log ("Dead animation is off");

			anim.SetBool ("Dead", false); //stop dead animation
		}

		//location to respawn player 
		transform.position = GameObject.Find ("SpawnPoint").transform.position;

		//positioning camera again
		GameObject.Find("Main Camera").transform.position = new Vector3(-2,-4,-10);
		cc = GameObject.FindWithTag ("MainCamera").GetComponent<GameCamera> ();

		//setting the cameras target on the player to follow them again
		cc.SetTarget(GameObject.FindWithTag("Player").transform);

		if(PlayerHealth.health < 0)
			levelComplete = true;
	}//Died

	void Flip()
	{
		// Switch the way the player is labelled as facing.
		facingRight = !facingRight;
		
		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}//Flip
}
