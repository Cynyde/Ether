using UnityEngine;
using System.Collections;

public class BattlefieldRangeCheck : MonoBehaviour {

	public GameObject playerObject;
	public int battlefieldRange = 1000;
	private float dist = 0;
	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Arrow();
	}

	void OnGUI()
	{
		if(playerObject == null)
			Application.LoadLevel("Lose");
		else
		{
			dist = Mathf.Sqrt((float)(Mathf.Pow((float)playerObject.transform.position.x, 2.0f) + Mathf.Pow((float)playerObject.transform.position.y, 2.0f) + Mathf.Pow((float)playerObject.transform.position.z, 2.0f)));
			if(CheckDist())
				GUI.Box(new Rect(Screen.width/2-150, Screen.height/2-32, 300,64), "Outside the operation area!\nGET BACK TO THE SHIT PILOT!\n\nDistance: " + dist);
			else
				GUI.Box(new Rect(100, 100, 300,64), "Distance: " + dist);
		}
	}

	bool CheckDist()
	{
		if(dist > battlefieldRange)
			return true;
		else
			return false;
	}

	void Arrow()
	{

	}
}
