using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitable : MonoBehaviour
{
	public int bossNumber;
	public float health;
	void Start()
	{
		if(!GameEvent.perriIsAlive && bossNumber == 1)
		{
			Destroy(gameObject);
		}
		if(!GameEvent.ianniIsAlive && bossNumber == 2)
		{
			Destroy(gameObject);
		}
		if(!GameEvent.dodaroIsAlive && bossNumber == 3)
		{
			Destroy(gameObject);
		}

	}

	public void takeDamage(float damage)
	{
		health -= damage;
		Debug.Log(health);
		if(health <= 0){
			Die();
		}
	}

	public void Die()
	{
		Destroy(gameObject);
		if(bossNumber == 1)
		{
			GameEvent.perriIsAlive = false;
		}
		if(bossNumber == 2)
		{
			GameEvent.ianniIsAlive = false;
		}
		if(bossNumber == 3)
		{
			GameEvent.dodaroIsAlive = false;
		}
		
	}

}
