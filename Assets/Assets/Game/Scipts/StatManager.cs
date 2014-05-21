using UnityEngine;
using System.Collections;

public class StatManager : MonoBehaviour {

	public int playerHealth = 100;
	public int playerDamage = 3;
	public int lives = 3;

	public int enemyHealth = 10;
	public int enemyDamage = 5;
	public int numEnemies = 1;

	public GameObject playerPrefab;
	public GameObject frigatePrefab;
	public GameObject fighterPrefab;

	private GameObject playerPosition;
	private GameObject frigatePosition;
	private GameObject[] enemiesPositions;
	private int[] enemiesHealth;

	private bool inRange = false;

	// Use this for initialization
	void Start () {
	}

	// Once the script is made
	void OnAwake () {
		enemiesPositions = new GameObject[numEnemies];
		enemiesHealth = new int[numEnemies];

		//Spawn Enemies
		SpawnEnemies();

		DontDestroyOnLoad(this);
	}

	//GUI calls
	void OnGUI()
	{
		if(Vector3.Distance(playerPosition.transform.position,frigatePosition.transform.position) <= 200)
		{
			inRange = true;
			GUI.Label(new Rect(Screen.width/2-150, Screen.height/2-128, 300,64), "Press 'B' to begin bombing run.");
		}
		else
			inRange = false;
	}

	// Update is called once per frame
	void Update () {
		//Spawn Frigate
		frigatePosition = frigatePrefab;
		
		//Spawn Player
		playerPosition = playerPrefab;

		if(playerPosition == null)
		{
			Debug.Log("Player Position Invalid");
			Application.Quit();
		}

		if(playerHealth <= 0)//Decrement Lives and Reset Health
		{
			lives--;
			playerHealth = 100;
		}
		
		if(lives <= 0)//Lose Game
			Application.LoadLevel("Lose");

		if(frigatePosition == null)//Win Game
			Application.LoadLevel("Win");

		if(Input.GetKeyDown("b") && inRange)//'b' pressed and in range, then bombs away
		{
			Application.LoadLevel("GameBombingRun");
		}
	}

	private void SpawnEnemies()
	{
		//Spawn Fighters
		for (int i = 0; i < enemiesPositions.Length; i++) 
		{
			enemiesPositions[i] = (GameObject)Instantiate(fighterPrefab as Object, new Vector3(50.0f * i, 0.0f, 1500.0f), Quaternion.identity);
			Debug.Log("Created Enemy " + i);
		}
	}

	private void RespawnEntities()
	{
		//Spawn Player
		if(playerPosition != null)
			playerPosition = (GameObject)Instantiate(playerPrefab as Object, playerPosition.transform.position, playerPosition.transform.rotation);

		//Spawn Frigate
		if(frigatePosition != null)
			frigatePosition = (GameObject)Instantiate(frigatePrefab as Object, frigatePosition.transform.position, frigatePosition.transform.rotation);

		//Spawn Fighters
		for (int i = 0; i < enemiesPositions.Length; i++) {
			enemiesPositions[i] = (GameObject)Instantiate(enemiesPositions[i], enemiesPositions[i].transform.position, enemiesPositions[i].transform.rotation);
			Debug.Log("Recreated Enemy " + i);
		}
	}
}
