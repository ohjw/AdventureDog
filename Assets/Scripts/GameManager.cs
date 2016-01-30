using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{
	public GameObject player;
	public Transform spawnPoint;
	private GameCamera cam;

	// Use this for initialization
	void Awake () 
	{
		cam = GetComponent<GameCamera> ();
		SpawnPlayer ();

	}//Start

	public void SpawnPlayer()
	{
		cam.SetTarget((Instantiate (player, spawnPoint.position, Quaternion.identity)as GameObject).transform);
	}//SpawnPlayer



}
