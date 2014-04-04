using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerManagement : MonoBehaviour {
	
	public AudioClip laser;
	
	public Object playerPrefab;
	public Object projectilePrefab;
	
	public List<GameObject> bullets;
	
	public int lives = 3;
	public static int health = 100;
	public static int score = 0;
	
	public Transform target;
	public float speed = 5.0f;
	public float fireSpeed = 1.0f;
	public float bulletVelocity = 30.0f;
	private float fireTimer = 0;
	
	void OnGUI()
	{
		if(EnemyManagement.bossHealth > 0)
			GUI.Box(new Rect(Screen.width * 0.025f, Screen.height * 0.05f, 150,65), "Score: " + score.ToString() + "\n\nHealth: " + health.ToString() + "\nLives: " + lives.ToString());
		else if(health < 0)
		{
			GUI.Box(new Rect(Screen.width/2-75, Screen.height/2-32, 150,65), "You Lose... \n\nScore: " + PlayerManagement.score.ToString());
			if(GUI.Button(new Rect(Screen.width/2-75, Screen.height/2+32, 150,25), "Main Menu"))
				Application.LoadLevel("MainMenu");
		}
	}
	
	void Start()
	{
		health = 100;
		lives = 3;
		score = 0;
	}
	
	void Awake()
	{
		QualitySettings.vSyncCount = 1;	
	}
	
	// Update is called once per frame
	void Update () {
		
		
		CheckHealthandLives();
		
		//Camera Index 0 = 3rd Person
		//Camera Index 1 = Top Down
        //Camera Index 2 = Side Scroll
        #region Keyboard Input
        if (Input.GetKey(KeyCode.W))
		{
			switch(CameraSwitch.cameraIndex)
			{
				case 0:
					target.position = new Vector3(target.position.x, target.position.y + speed, target.position.z);
					break;
					
				case 1:
					target.position = new Vector3(target.position.x, target.position.y, target.position.z + speed);
					break;
					
				case 2:
					target.position = new Vector3(target.position.x, target.position.y + speed, target.position.z);
					break;
			}
		}	
		
		if(Input.GetKey(KeyCode.S))
		{
			switch(CameraSwitch.cameraIndex)
			{
				case 0:
					target.position = new Vector3(target.position.x, target.position.y - speed, target.position.z);
					break;
					
				case 1:
					target.position = new Vector3(target.position.x, target.position.y, target.position.z - speed);
					break;
					
				case 2:
					target.position = new Vector3(target.position.x, target.position.y - speed, target.position.z);
					break;
			}
		}
		
		if(Input.GetKey(KeyCode.A))
		{
			switch(CameraSwitch.cameraIndex)
			{
				case 0:
					target.position = new Vector3(target.position.x - speed, target.position.y, target.position.z);
					break;
					
				case 1:
					target.position = new Vector3(target.position.x - speed, target.position.y, target.position.z);
					break;
					
				case 2:
					target.position = new Vector3(target.position.x, target.position.y, target.position.z - speed);
					break;
			}
		}
		
		if(Input.GetKey(KeyCode.D))
		{
			switch(CameraSwitch.cameraIndex)
			{
				case 0:
					target.position = new Vector3(target.position.x + speed, target.position.y, target.position.z);
					break;
					
				case 1:
					target.position = new Vector3(target.position.x + speed, target.position.y, target.position.z);
					break;
					
				case 2:
					target.position = new Vector3(target.position.x, target.position.y, target.position.z + speed);
					break;
			}
		}
				
		if(Input.GetKey(KeyCode.Space) && fireTimer <= 0)
		{
			bullets.Add((GameObject)Instantiate(projectilePrefab, new Vector3(target.position.x + Random.Range(-1,2), target.position.y + Random.Range(-1,2), target.position.z + 1.5f + Random.Range(-0.5f,0.5f)), Quaternion.identity));
			fireTimer = fireSpeed;
			audio.PlayOneShot(laser);
		}
		else
			fireTimer -= 0.05f;

		#endregion

        #region Controller Input
		if (Input.GetAxis("Left Joystick Y") < 0)
		{
			switch(CameraSwitch.cameraIndex)
			{
			case 0:
				target.position = new Vector3(target.position.x, target.position.y + speed, target.position.z);
				break;
				
			case 1:
				target.position = new Vector3(target.position.x, target.position.y, target.position.z + speed);
				break;
				
			case 2:
				target.position = new Vector3(target.position.x, target.position.y + speed, target.position.z);
				break;
			}
		}	
		
		if(Input.GetAxis("Left Joystick Y") > 0)
		{
			switch(CameraSwitch.cameraIndex)
			{
			case 0:
				target.position = new Vector3(target.position.x, target.position.y - speed, target.position.z);
				break;
				
			case 1:
				target.position = new Vector3(target.position.x, target.position.y, target.position.z - speed);
				break;
				
			case 2:
				target.position = new Vector3(target.position.x, target.position.y - speed, target.position.z);
				break;
			}
		}
		
		if(Input.GetAxis("Left Joystick X") < 0)
		{
			switch(CameraSwitch.cameraIndex)
			{
			case 0:
				target.position = new Vector3(target.position.x - speed, target.position.y, target.position.z);
				break;
				
			case 1:
				target.position = new Vector3(target.position.x - speed, target.position.y, target.position.z);
				break;
				
			case 2:
				target.position = new Vector3(target.position.x, target.position.y, target.position.z - speed);
				break;
			}
		}
		
		if(Input.GetAxis("Left Joystick X") > 0)
		{
			switch(CameraSwitch.cameraIndex)
			{
			case 0:
				target.position = new Vector3(target.position.x + speed, target.position.y, target.position.z);
				break;
				
			case 1:
				target.position = new Vector3(target.position.x + speed, target.position.y, target.position.z);
				break;
				
			case 2:
				target.position = new Vector3(target.position.x, target.position.y, target.position.z + speed);
				break;
			}
		}
		
		if(Input.GetAxis("Right Trigger") > 0 && fireTimer <= 0) //R2
		{
			bullets.Add((GameObject)Instantiate(projectilePrefab, new Vector3(target.position.x + Random.Range(-1,2), target.position.y + Random.Range(-1,2), target.position.z + 1.5f + Random.Range(-0.5f,0.5f)), Quaternion.identity));
			fireTimer = fireSpeed;
			audio.PlayOneShot(laser);
		}
		else
			fireTimer -= 0.05f;

        #endregion

        target.position = CheckPosition(target.position);

		CheckBullets();
	}
	
	void CheckHealthandLives()
	{
		if(lives <= 0)
			Application.LoadLevel("MainMenu");
		else if(health <= 0)
		{
			lives--;
			health = 100;
		}
	}
	
	void CheckBullets()
	{
		for(int i = 0; i < bullets.Count; i++)
		{
			if(bullets[i].transform.position.z > 147)
			{
				Destroy(bullets[i]);
				bullets.RemoveAt(i);
			}
			else
			{
				bullets[i].transform.position = new Vector3(bullets[i].transform.position.x, bullets[i].transform.position.y, bullets[i].transform.position.z + bulletVelocity);
			}
		}
	}

	//Limits Player Movement to Screen --Obselete Code
	Vector3 CheckPosition(Vector3 input)
	{
		Vector3 output = input;
		
		//Check X
		if(input.x > 8.5f)
			output = new Vector3(8.5f, input.y, input.z);
		else if(input.x < -8.5f)
			output = new Vector3(-8.5f, input.y, input.z);

		//Check Y
		if(input.y > 3.5f)
			output =  new Vector3(input.x, 3.5f, input.z);
		else if(input.y < -5.5f)
			output =  new Vector3(input.x, -5.5f, input.z);
		
		//Check Z
		if(CameraSwitch.cameraIndex == 1)
		{
			//Top Down
			if(input.z > 12.5f)
				output =  new Vector3(input.x, input.y, 12.5f);
			else if(input.z < 3.5f)
				output =  new Vector3(input.x, input.y, 3.5f);
		}
		else
		{
			//Side Scroll
			if(input.z > 16.5f)
				output =  new Vector3(input.x, input.y, 16.5f);
			else if(input.z < -0.5f)
				output =  new Vector3(input.x, input.y, -0.5f);
			
		}
		return output;
	}
}
