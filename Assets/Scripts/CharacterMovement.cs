using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

	public CharacterController controller;
	public Transform camera;

	public Animator _animator;

	public float _speed = 6.0f;
	public float turningTime = .1f;
	public float turnVelocity;

	private float verticalVelocity;
	private float jumpForce = 4.5f;
	private float gravity = 10.0f; 

	private float _punchDamage = 10.0f; 
	private float shortRange = 1.0f;
	private float longRange = 200.0f;
	private string[] attacks = {"punch", "kick"};
	private string attack;
    public float impactForce = 80f;
    public int instatiateblePenDrives = 10;

    public GameObject pendrivePrefab;


    

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        Debug.Log("Pennette disponibili --> " + instatiateblePenDrives);

        if(controller.isGrounded){
        	verticalVelocity = -gravity * Time.deltaTime;
        	if(Input.GetButton("Jump")){
        		verticalVelocity = jumpForce;
                _animator.SetBool("jump", true);
        	}else{
                _animator.SetBool("jump", false);
            }
        	if(Input.GetButton("Running")){
        		//_speed *= 2;
                _animator.SetBool("run", true);
        	}else{
                _animator.SetBool("run", false);
            }
        }else{
        	verticalVelocity -= gravity * Time.deltaTime;
        }

        if(Input.GetKey(KeyCode.Mouse0)){
        		Debug.Log("ATTACK");
        		if(ShortAttack()){
					string attack = attacks[Random.Range(0, 2)];
        			_animator.SetBool(attack, true);
        			Debug.Log("SHORT ATTACK");
        		}
        		else if(longHit()){
        			LongAttack();
        			_animator.SetBool("longRange", true);
        			Debug.Log("LONG ATTACK");
        		}
        		
        }
        else{
        		if(_animator.GetBool(attacks[0])){
	        		Debug.Log(attack);
	        		_animator.SetBool(attacks[0], false);
        		}
        		else if(_animator.GetBool(attacks[1])){
        			_animator.SetBool(attacks[1], false);
        		}else if(_animator.GetBool("longRange")){
					_animator.SetBool("longRange", false);
        		}
        }
		Vector3 moveDirection = Vector3.zero;
        if(direction.magnitude >= 0.1){
        	float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + camera.eulerAngles.y;
        	float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnVelocity, turningTime);
        	transform.rotation = Quaternion.Euler(0f, angle, 0f);
        	moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
        }
        _animator.SetFloat("speed", direction.magnitude);
        moveDirection.y = verticalVelocity;
        controller.Move(moveDirection.normalized * _speed * Time.deltaTime);
    }

    bool ShortAttack(){
    	RaycastHit hit;
    	bool hitted = false;
    	if(Physics.Raycast(GameObject.FindWithTag("Player").transform.position + controller.center , transform.forward, out hit, shortRange)){
    		Debug.Log(hit.transform.name);
    		Hitable target = hit.transform.GetComponent<Hitable>();
    		if(target != null){
    			target.takeDamage(_punchDamage);
    			hitted = true;
    		}
            if(hit.rigidbody != null){
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }
    	}
    	return hitted;
    }
    bool longHit(){
		return Physics.Raycast(GameObject.FindWithTag("Player").transform.position + controller.center , controller.transform.forward, longRange);
    }
    void LongAttack(){
    	RaycastHit hit;
    	
    	if(Physics.Raycast(GameObject.FindWithTag("Player").transform.position + controller.center , controller.transform.forward, out hit, longRange)){
    		Debug.Log(hit.transform.name);
    		Hitable target = hit.transform.GetComponent<Hitable>();
    		if(target != null && instatiateblePenDrives > 0){
    			Instantiate(pendrivePrefab);
    			target.takeDamage(_punchDamage);
    			instatiateblePenDrives -= 1;
    		}
    		else if(instatiateblePenDrives == 0){
	           	StartCoroutine(wait());
	            
    		}
            if(hit.rigidbody != null && instatiateblePenDrives > 0){
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }
    	}
    	//return hitted;
    }

    IEnumerator wait(){
    	Debug.Log("PENNETTE FINITE");
    	yield return new WaitForSeconds(10);
    	Debug.Log("PENNETTE RICARICATE");
    	instatiateblePenDrives = 10;
    }

}
