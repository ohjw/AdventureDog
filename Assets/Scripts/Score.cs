using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour
{
	public static int score = 0; // players score
	public GameObject scoreText;//GUIText to display score
	public int scoreValue; // value that score increments by
	public AudioClip pickup;

	void Awake()
	{
		score = 0;
		scoreText.guiText.text = "";
	}//Awake

	void Start ()
	{
		//finding the PlayerScore object in game
		scoreText = GameObject.Find("PlayerScore");
		UpdateScore ();

	}//Start

	//@param newScore - value to be added onto players old/current score
	public void AddScore(int newScore)
	{
		score += newScore;

		//update the GUI text to show change
		UpdateScore ();
	}//AddScore
	
	void UpdateScore()
	{
		scoreText.guiText.text = "Score: " + score;
	}//UpdateScore

	void OnTriggerEnter2D(Collider2D other) 
	{
		//when a object with the tag Pickup is collided with then it added 10 (scoreValue) to the score
		if (other.tag == "Pickup")
		{	
			audio.clip = pickup;
			audio.Play();

			AddScore(scoreValue);

			//destroy Pickup object 
			Destroy(other.gameObject);		
		}//if

	}//OnTriggerEnter2D
}
