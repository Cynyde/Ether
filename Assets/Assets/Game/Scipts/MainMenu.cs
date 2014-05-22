using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	void Start()
	{
		Screen.lockCursor = false;
	}

	void OnPlayClick()
	{
		Application.LoadLevel("GameSpace");
	}
	
	void OnCreditsClick()
	{
		Application.LoadLevel("Credits");
	}
	
	void OnExitClick()
	{
		Application.Quit();
	}
	
	void OnBackClick()
	{
		Application.LoadLevel("MainMenu");	
	}
}
