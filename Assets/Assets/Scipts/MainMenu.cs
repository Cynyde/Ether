using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	
	void OnPlayClick()
	{
		Application.LoadLevel("Game");
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
