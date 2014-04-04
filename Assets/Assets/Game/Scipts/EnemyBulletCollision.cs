using UnityEngine;
using System.Collections;

public class EnemyBulletCollision : MonoBehaviour {
	
	public int damage = 5;
	
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Player")
			PlayerManagement.health -= damage;
	}
}
