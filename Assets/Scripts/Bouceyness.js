#pragma strict

var BounceAmount : float;
var boing : AudioClip;

function OnTriggerEnter2D (other : Collider2D) 
{
	if(other.tag == "Player")
	{
		//grab player object
		var P = GameObject.FindGameObjectWithTag("Player");
		
		//play boing sound effect when player hits the bouncy platform
		audio.clip = boing;
		audio.Play();
		
		//add bounceAmount to the players velocity in y direction
		P.GetComponent("PlayerControl").rigidbody2D.velocity.y = BounceAmount;
	}//if

}
