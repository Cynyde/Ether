using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AsteroidBehavior : MonoBehaviour {
	
	public Object asteroidPrefab;
	public List<GameObject> asteroids;
	
	public int numAsteroids = 7;
	public float moveSpeed = 1.0f;
	
	
	// Use this for initialization
	void Start () {		
		for(int i = 0; i < numAsteroids; i++)
		{
			Spawn();
		}
	}
	
	// Update is called once per frame
	void Update () {
		DespawnAsteroidsCheck();
	}
	
	void DespawnAsteroidsCheck()
	{
		for(int i = 0; i < asteroids.Count; i++)
		{
			if(asteroids[i].transform.position.z < -17)
			{
				Destroy(asteroids[i]);
				asteroids.RemoveAt(i);
				Spawn();
			}
			else
			{
				asteroids[i].transform.position = new Vector3(asteroids[i].transform.position.x, asteroids[i].transform.position.y, asteroids[i].transform.position.z - moveSpeed);
			}
		}
	}
	
	void Spawn()
	{
		GameObject tempAsteroid = (GameObject)Instantiate(asteroidPrefab, new Vector3((float)Random.Range(-40,40), (float)Random.Range(-40, 40), (float)Random.Range(150, 275)), Quaternion.identity);
		tempAsteroid.transform.rotation = Random.rotation;
		asteroids.Add(tempAsteroid);
	}
}
