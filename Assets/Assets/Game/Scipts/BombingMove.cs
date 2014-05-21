using UnityEngine;
using System.Collections;

public class BombingMove : MonoBehaviour {
	public float[] spawnTimes;
	public float backSpeed = 0.1f;

	private float timer = 105.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(timer > 0)
			timer -= Time.deltaTime;//Adds to Time for Spawning and such
		else
			Application.LoadLevel("Win");//Successful Bombing Run, Frigate "Destroyed"

		this.transform.position = new Vector3(this.transform.position.x,0f,this.transform.position.z + backSpeed);
	}
}
