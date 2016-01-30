using UnityEngine;
using System.Collections;

public class Teleport : MonoBehaviour 
{

	public GameObject target;
	public float adjust; // adjust how high player spawns in portal
	public bool  jump;
	
	void  OnTriggerEnter2D(Collider2D col)
	{
		//if transporting to one portal to another do not cause it to go back and forth too quicklu
		if(!jump)
		{
			//player has entered a portal 
			if(col.tag == "Player")
			{
				//jumped to new portal so jump is true 
				target.GetComponent<Teleport>().jump = true;
				col.gameObject.transform.position = new
					Vector3(target.transform.position.x,target.transform.position.y + adjust, 0);
			}//if
		}//if
	}//OnTriggerEnter2D
	
	void  OnTriggerExit2D ( Collider2D col  )
	{
		if(col.tag == "Player")
			jump = false; // when player exits portal jump is reset back
	}//OnTriggerExit2D 
}
