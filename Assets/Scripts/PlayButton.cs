using UnityEngine;
using System.Collections;

public class PlayButton : MonoBehaviour {

	//these are set in the inspector of the PlayButton
	public Texture2D playNormal;
	public Texture2D playHover;
	
	void OnMouseEnter ()
	{
		//when hovering use this texture
		guiTexture.texture = playHover;
	}//OnMouseEnter
	
	void OnMouseExit ()
	{
		//when not hovering use this texture
		guiTexture.texture = playNormal;
	}//OnMouseExit
	
	void OnMouseDown ()
	{
		//load game scene
		Application.LoadLevel("Game");
	}//OnMouseDown
}