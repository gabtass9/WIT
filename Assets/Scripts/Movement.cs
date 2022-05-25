using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CharacterController))]

public class Movement : MonoBehaviour
{
    public float speed =6.0f;
    private CharacterController _charController;
    public float gravity=-9.8f;

    void Start()
    {
        _charController=GetComponent<CharacterController>();
    }
    // Update is called once per frame
    void Update()
    {
        float deltaX=Input.GetAxis("Horizontal")*speed;
        float deltaZ=Input.GetAxis("Vertical")*speed;
        Vector3 movements=new Vector3(deltaX,0,deltaZ);
        movements=Vector3.ClampMagnitude(movements,speed);
        movements.y=gravity;
        movements*=Time.deltaTime;
        movements=transform.TransformDirection(movements);
        _charController.Move(movements);
    }
}
