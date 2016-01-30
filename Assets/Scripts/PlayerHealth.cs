using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour 
{
	public static int health = 3; // players health
	public int healthValue; // value that health increments/decrements by

	//AUDIO
	public AudioClip pickup;

	//GUI
	public GameObject healthText;//GUIText to display health
	public GameObject gameOverText;//GUIText to display game over message
	public GameObject restartText; //GUIText to display restart option when game ends
	public GameObject gameOverOptionsText; //GUITezt displaying options when game is over

	//GAMEOVER
	private bool gameOver = false; 

	void Start ()
	{

		//finding the GameOverText object in game
		gameOverText = GameObject.Find("GameOverText");

		//finding the GameOverOptionText object in game
		gameOverOptionsText = GameObject.Find("GameOverOptionText");

		//finding the RestartText object in game
		restartText = GameObject.Find("RestartText");

		//finding the PlayerHealth object in game
		healthText = GameObject.Find("PlayerHealth");

	}//Start

	void Awake()
	{
		health = 3;
		gameOver = false;
		gameOverText.guiText.text = "";
		restartText.guiText.text = "";
		healthText.guiText.text = "";
	}//Awake

	void Update()
	{
		UpdateHealth ();

		//players game is over if the lives is less than 0
		if (health < 0) 
		{
			gameOver = true;

			//call GameOver to display gameover text 
			GameOver ();

			Debug.Log ("can make game over option");
				
			if (Input.GetKey(KeyCode.R)) 
			{
				Debug.Log ("R was pressed");
				Application.LoadLevel(Application.loadedLevel);
				
			}//if

			if (Input.GetKey(KeyCode.M)) 
			{
				Debug.Log ("M was pressed");
				Application.LoadLevel("MainMenu");

			}//if
				
			if(Input.GetKey(KeyCode.E))
			{
				Application.Quit();
			}//if

		}//if
	}//Update


	void UpdateHealth()
	{
		//updating GUI text to display new health status
		healthText.guiText.text = "x " + health;

		if(health < 0)
		{
			healthText.guiText.text = " No more lives";
		}//if

	}//UpdateHealth

	void IncreaseHealth(int healthValue)
	{
		health += healthValue;//add healthValue to current health
		UpdateHealth(); //update gui text

	}//AddHealth

	void OnTriggerEnter2D(Collider2D col) 
	{
		//when a object with the tag Health is collided with increase health
		if (col.tag == "Health")
		{	
			audio.clip = pickup;
			audio.Play();

			IncreaseHealth(healthValue);
			Destroy(col.gameObject); //destroy Pickup object 

		}//if

	}//OnTriggerEnter

	void GameOver()
	{
		gameOverText.guiText.text = "Game Over!";
		gameOverOptionsText.guiText.text = "Press M for Menu";
	}//Died 

}
