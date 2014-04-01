using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyManagement : MonoBehaviour {

	public Object kamikazePrefab;
	public Object dpsPrefab;
	public Object tankPrefab;
	public Object projectilePrefab;
	public Object bossPrefab;
	public Object playerPrefab;
	
	private GameObject boss;
	
	public static int bossHealth = 450;
	
	public List<GameObject> enemies;
	public List<GameObject> bullets;
	
	public float timeToBoss = 500;
	
	public int maxEnemies = 10;
	
	public float moveSpeed = 0.01f;
	public float shootSpeed = 0.1f;
	public float bulletVelocity = 0.75f;
	
	void Start()
	{
		for(int i = 0; i < 5; i++)
			SpawnEnemy();
		
		bossHealth = 450;
		timeToBoss = 500;
	}
	
	void Update () {
		for(int i = 0; i < enemies.Count; i++)
		{
			enemies[i].transform.position = new Vector3(enemies[i].transform.position.x, enemies[i].transform.position.y,enemies[i].transform.position.z - moveSpeed);
		}
		
		for(int i = 0; i < enemies.Count; i++)
		{
			shootSpeed -= 0.0025f;
			
			if(shootSpeed <= 0)
				if(Random.Range(1,5)%2 == 0)
					Fire(enemies[i]);
		}
		
		timeToBoss -= 0.05f;
		if(timeToBoss <=0 && boss == null)
			SpawnBoss();
		
		if(enemies.Count < maxEnemies && timeToBoss > 0)
		{
			if(Random.Range(1,5)%2 == 0)
				SpawnEnemy();
		}
		
		if(timeToBoss < 0.0f && boss.transform.position.z >= 18)
			boss.transform.position = new Vector3(boss.transform.position.x, boss.transform.position.y, boss.transform.position.z - moveSpeed * 1.5f);
		
		if(timeToBoss < 0.0f && Random.Range(1,5)%2 == 0 && bossHealth > 0)
			Fire(boss);
		
		CheckBullets();
		DespawnEnemiesCheck();
	}
	
	void CheckBullets()
	{
		for(int i = 0; i < bullets.Count; i++)
		{
			if(bullets[i].transform.position.z < -17)
			{
				Destroy(bullets[i]);
				bullets.RemoveAt(i);
			}
			else
			{
				bullets[i].transform.position = new Vector3(bullets[i].transform.position.x, bullets[i].transform.position.y, bullets[i].transform.position.z - bulletVelocity);
			}
		}
	}
	
	void SpawnEnemy()
	{
		//1-3 Kamikaze
		//4-7 DPS
		//8-10 Tank
		int x = Random.Range(1,10); 
		if(x < 4)
			enemies.Add((GameObject)Instantiate(kamikazePrefab, new Vector3(Random.Range(-8,8), Random.Range(-5, 3), Random.Range(150, 275)), Quaternion.identity));
		else if(x > 7)
			enemies.Add((GameObject)Instantiate(tankPrefab, new Vector3(Random.Range(-8,8), Random.Range(-5, 3), Random.Range(150, 275)), Quaternion.identity));
		else
			enemies.Add((GameObject)Instantiate(dpsPrefab, new Vector3(Random.Range(-8,8), Random.Range(-5, 3), Random.Range(150, 275)), Quaternion.identity));
		
		enemies[enemies.Count-1].transform.Rotate(0.0f, 180.0f, 0.0f);
	}
	
	void DespawnEnemiesCheck()
	{
		for(int i = 0; i < enemies.Count; i++)
		{
			if(enemies[i].transform.position.z < -17)
			{
				Destroy(enemies[i]);
				enemies.RemoveAt(i);
			}
			else
			{
				enemies[i].transform.position = new Vector3(enemies[i].transform.position.x, enemies[i].transform.position.y, enemies[i].transform.position.z - moveSpeed);
			}
		}
		
		if(bossHealth <=0 && boss != null)
		{	
			PlayerManagement.score += Random.Range(750, 1000);
			Destroy(boss);
			boss = null;
		}
	}
	
	void Fire(GameObject enemy)
	{
		bullets.Add((GameObject)Instantiate(projectilePrefab, new Vector3(enemy.transform.position.x + Random.Range(-5, 5), enemy.transform.position.y + Random.Range(-5, 5), enemy.transform.position.z - 0.5f), Quaternion.identity));
		shootSpeed = 0.1f;
	}
	
	void SpawnBoss()
	{
		boss = (GameObject)Instantiate(bossPrefab, new Vector3(0, 0, Random.Range(150, 165)), Quaternion.identity);
		boss.transform.Rotate(0.0f, 180.0f, 0.0f);
	}
	
	void OnGUI()
	{
		if(bossHealth <= 0)
		{
			GUI.Box(new Rect(Screen.width/2-75, Screen.height/2-32, 150,65), "YOU WIN! \n\nScore: " + PlayerManagement.score.ToString());
			if(GUI.Button(new Rect(Screen.width/2-75, Screen.height/2+32, 150,25), "Main Menu"))
				Application.LoadLevel("MainMenu");
		}
	}
}
