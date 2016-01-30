using UnityEngine;
using System.Collections;

public class ControlsButton : MonoBehaviour {

	//these are set in the inspector of the PlayButton
	public Texture2D controlsNormal;
	public Texture2D controlsHover;
	
	void OnMouseEnter ()
	{
		//when hovering use this texture
		guiTexture.texture = controlsHover;
	}//OnMouseEnter
	
	void OnMouseExit ()
	{
		//when not hovering use this texture
		guiTexture.texture = controlsNormal;
	}//OnMouseExit
	
	void OnMouseDown ()
	{
		//load game scene
		Application.LoadLevel("Controls");
	}//OnMouseDown
}
