using UnityEngine;
using System.Collections;

public class GameCamera : MonoBehaviour {
	
	public static Transform target;
	private float trackSpeed = 10;
	
	public void SetTarget(Transform t)
	{
		target = t;
		
	}//SetTarget
	
	void Update()
	{
		if (target) 
		{
			float x = IncrementTowards(transform.position.x, target.position.x,trackSpeed);
			float y = IncrementTowards(transform.position.y, target.position.y,trackSpeed);			
			transform.position = new Vector3(x,y, transform.position.z);
		}//if
	}//LateUpdate
	
	private float IncrementTowards(float n, float target, float a)
	{
		if (n == target)
		{
			return n;
		}//if
		
		else 
		{
			//in which direction must the current speed be incremented (- or +)
			float dir = Mathf.Sign (target - n); // n must be increased or decreased to get closer to the target
			n += a * Time.deltaTime * dir;
			return(dir == Mathf.Sign (target - n)) ? n : target; //if target has not been reached then return target else return n
		}//else
	}
}

