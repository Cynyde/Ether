using UnityEngine;
using System.Collections;

public class BattlefieldRangeCheck : MonoBehaviour {

	public GameObject playerObject;

	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
	}

	void OnGUI()
	{
		
		if(CheckDist())
		{
			GUI.Box(new Rect(Screen.width/2-150, Screen.height/2-32, 300,64), "Outside the operation area");
		}
		else
		{
			GUI.Box(new Rect(100, 100, 300,64), "Distance" + Mathf.Sqrt((float)(Mathf.Pow((float)playerObject.transform.position.x, 2.0f) + Mathf.Pow((float)playerObject.transform.position.y, 2.0f) + Mathf.Pow((float)playerObject.transform.position.z, 2.0f))));
		}
	}

	bool CheckDist()
	{
		if(Mathf.Sqrt((float)(Mathf.Pow((float)playerObject.transform.position.x, 2.0f) + Mathf.Pow((float)playerObject.transform.position.y, 2.0f) + Mathf.Pow((float)playerObject.transform.position.z, 2.0f))) > 1000.0f)
			return true;
		else
			return false;
	}
}
