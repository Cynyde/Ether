using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BombingMove : MonoBehaviour {
	
	public Transform target;
	public Object enemyPrefab;
	public List<GameObject> enemies;

	public float speed = 5.0f;

	public float backSpeed = 0.1f;

	private float timer = 105.0f;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		/*Batarangs
		if(((int)timer)%5 == 0)//Spawn every 5 seconds roughly
			enemies.Add((GameObject)Instantiate(enemyPrefab, new Vector3(Random.Range(-28,28), 0, 20), Quaternion.identity));
		*/
		//if(timer%5 == 0)
			//enemies.Add((GameObject)Instantiate(enemyPrefab, new Vector3(Random.Range(-28,28), 0, 20), Quaternion.identity));


		if(timer > 0)
			timer -= Time.deltaTime;//Adds to Time for Spawning and such
		else
			Application.LoadLevel("Win");//Successful Bombing Run, Frigate "Destroyed"

		this.transform.position = new Vector3(this.transform.position.x,0f,this.transform.position.z + backSpeed);

		InputHandler();
		if(enemies.Count > 0)
			CheckEnemiesAndFire();
	}

	void CheckEnemiesAndFire()
	{
		//Check to move
		for (int i = 0; i < enemies.Count; i++)
		{
			if(enemies[i].transform.position.z < -20)
				enemies[i].transform.position = new Vector3(Random.Range(-28,28), 0, 25);
			else
			enemies[i].transform.position = new Vector3(enemies[i].transform.position.x,enemies[i].transform.position.y,enemies[i].transform.position.z - speed*0.5f);
		}

		//Fire (for later usage)
	}

	void InputHandler()
	{
		if(Input.GetKey(KeyCode.W))//Up
			target.position = new Vector3(target.position.x, target.position.y, target.position.z+speed);
		
		if(Input.GetKey(KeyCode.S))//Down
			target.position = new Vector3(target.position.x, target.position.y, target.position.z-speed);
		
		if(Input.GetKey(KeyCode.A))//Left
			target.position = new Vector3(target.position.x-speed, target.position.y, target.position.z);
		
		if(Input.GetKey(KeyCode.D))//Right
			target.position = new Vector3(target.position.x+speed, target.position.y, target.position.z);

		target.position = CheckPosition(target.position);
	}

	Vector3 CheckPosition(Vector3 input)
	{
		//Check X
		if(input.x > 31f)
			return new Vector3(31f, input.y, input.z);
		else if(input.x < -31f)
			return new Vector3(-31f, input.y, input.z);

		//Check Z
		if(input.z > 15f)
			return new Vector3(input.x, input.y, 15f);
		else if(input.z < -17f)
			return new Vector3(input.x, input.y, -17f);

		return input;
	}
}
