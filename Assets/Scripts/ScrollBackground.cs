using UnityEngine;
using System.Collections;

public class ScrollBackground: MonoBehaviour 
{
	public float speed = 0;
	
	void FixedUpdate ()
	{
		renderer.material.mainTextureOffset = new Vector2 (Time.time * speed, 0f);
	
	}//FixedUpdate
}
