using UnityEngine;
using System.Collections;
//including some .NET for dynamic arrays called List in C#
using System.Collections.Generic;

public class CameraSwitch : MonoBehaviour {
	
	public static int cameraIndex = 0;
	
	// Use this for initialization
	void Start () {
		nextCamera();
	}
	
	// Update is called once per frame
	void Update () {	
		//Calls user input to cycle through cameras
		if(Input.GetKeyDown("q")){prevCamera();}
		if(Input.GetKeyDown("e")){nextCamera();}

		if(Input.GetKeyDown(KeyCode.JoystickButton4)){prevCamera();}
		if(Input.GetKeyDown(KeyCode.JoystickButton5)){nextCamera();}
	}
	
	void nextCamera()
	{
		cameraIndex++;
		if(cameraIndex > 2)
			cameraIndex = 0;
		camSwap(cameraIndex);
	}
	
	void prevCamera()
	{
		cameraIndex--;
		if(cameraIndex < 0)
			cameraIndex = 2;
		camSwap(cameraIndex);
	}
	
	void camSwap(int currentCam)
	{
		GameObject[] cameras = GameObject.FindGameObjectsWithTag("Camera");
		foreach(GameObject cams in cameras)
		{
			Camera theCam = cams.GetComponent<Camera>() as Camera;
			theCam.enabled = false;
		}
		
		Camera usedCamera = cameras[cameraIndex].GetComponent<Camera>() as Camera;
		usedCamera.enabled = true;
	}
}
