#pragma strict

private var Xpos : float;
private var Ypos : float;
private var max : boolean;

var Vert : boolean;
var maxAmount : int; // max amount to move
var step : float; // amount move per frame

function Start () 
{
	Xpos = transform.position.x;
	Ypos = transform.position.y;
}

function Update ()
{
	//Setting Max
	if(Vert)
	{
		if(transform.position.y >= Ypos + maxAmount)
			max = true; // reached max amount
		else if(transform.position.y <= Ypos)
			max = false;	
	}//if
	
	else
	{
		if(transform.position.x >= Xpos + maxAmount)
			max = true; // reached max amount
		else if(transform.position.x <= Xpos)
			max = false;
	}//else
	
	
	//Moving a platform
	if(Vert)//moving vertical
	{
		if(!max)//not at top
			transform.position.y += step; //add step amount to y positoo
		else
			transform.position.y -=step; //subtract step amount to y 
	}//if
	
	else//horizontal movement
	{
		if(!max)
			transform.position.x += step;
		else
			transform.position.x -= step;
	}//else

}//Update

