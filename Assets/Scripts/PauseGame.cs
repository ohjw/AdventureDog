using UnityEngine;
using System.Collections;

public class PauseGame : MonoBehaviour {

	public float TS;
	public bool paused;

	public GUIText pauseText;
	public GUIText pauseTextInstruct;

	// Use this for initialization
	void Start () 
	{
		//sets it to 1 at start 
		TS = Time.timeScale;

		pauseText.text = "";

	}//Start

	void Update () 
	{
		
		if(Input.GetKeyDown(KeyCode.P))
		{
			if(!paused)
			{

				paused = true;
				pauseText.text = "Paused";
				pauseTextInstruct.text = "P to Continue";
			
			}//if
			
			else
			{
				paused = false;
				pauseText.text = "";
				pauseTextInstruct.text = "";
				
			}//else

		}//if

		if(paused ||PlayerHealth.health < 0f)
		{

			if(Time.timeScale > 0.0f)
			{
				Time.timeScale = 0.0f;
			}//if
			
			if(audio.pitch > 0f)
			{
				audio.pitch -= 0.01f;
			}//if
			
			else
			{
				audio.Pause(); // halt background music while paused
			}//else
		}//if
		
		else
		{
			if(Time.timeScale < TS)
			{
				Time.timeScale = TS;
			}//if
			
			if(audio.pitch < 0.4f)
			{
				if(!audio.isPlaying)
				{
					audio.Play(); //continue background music
				}//if
				
				audio.pitch += 0.01f;
			}//if
		}//else
	}//Update

}
