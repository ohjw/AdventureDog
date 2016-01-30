using UnityEngine;
using System.Collections;

public class SplashScreen : MonoBehaviour 
{
	public float timer = 2f;
	public string sceneToLoad = "MainMenu";

	void Start ()
	{
		StartCoroutine ("DisplayScene");
	}//Start
	
	IEnumerator DisplayScene() 
	{
		yield return new WaitForSeconds(timer);
		Application.LoadLevel (sceneToLoad);
	
	}//DisplayScene
}
