using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitable : MonoBehaviour
{

	public float health = 1000f;

	public void takeDamage(float damage){
		health -= damage;
		Debug.Log(health);
		if(health <= 0){
			Die();
		}
	}

	public void Die(){
		Destroy(gameObject);
	}

}
