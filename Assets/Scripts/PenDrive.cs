using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenDrive : MonoBehaviour
{
    private float speed = 10.0f;
	public int damage = 1;
    // Update is called once per frame

    void Start(){
    	transform.position = GameObject.FindWithTag("Player").transform.position;
        transform.eulerAngles = new Vector3(
            transform.eulerAngles.x,
            transform.eulerAngles.y + 180,
            transform.eulerAngles.z
        );
    }

    void Update()
    {
        transform.Translate(0,0,speed*Time.deltaTime);
        Object.Destroy(gameObject, 3.0f);
    }

    /*void OnTriggerEnter(Collider other){
    	Hitable target = other.GetComponent<Hitable>();
    	if (target != null){
    		Debug.Log("Player Hit");
        }
    	
    }*/
}
