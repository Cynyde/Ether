using UnityEngine;
using System.Collections;

public class BulletCollision : MonoBehaviour {
	
	public int damage = 5;
	
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Enemy")
		{
			other.gameObject.transform.position = new Vector3(0,0,-17);
			PlayerManagement.score += Random.Range(5, 25);
		}
		else if(other.gameObject.tag == "Boss")
		{
			EnemyManagement.bossHealth -= damage;
		}
	}
}
