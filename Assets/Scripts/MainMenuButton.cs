using UnityEngine;
using System.Collections;

public class MainMenuButton : MonoBehaviour {

	//these are set in the inspector of the PlayButton
	public Texture2D menuNormal;
	public Texture2D menuHover;
	
	void OnMouseEnter ()
	{
		//when hovering use this texture
		guiTexture.texture = menuHover;
	}//OnMouseEnter
	
	void OnMouseExit ()
	{
		//when not hovering use this texture
		guiTexture.texture = menuNormal;
	}//OnMouseExit
	
	void OnMouseDown ()
	{
		//load game scene
		Application.LoadLevel("MainMenu");
	}//OnMouseDown
}
