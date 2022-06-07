using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingAI : MonoBehaviour
{
    private Animator _animator;
    public float speed = 4.0f;      
    public const float baseSpeed = 3.0f;          //parametri di configurazione
    public float obstacleRange = 5f;
    private bool _alive; //dobbiamo assicurarci che si muova solo quando è vivo
    // Start is called before the first frame update
    void Start()
    {
        _alive = true; //setto vivo l' oggetto in movimento
        _animator = GetComponent<Animator>();
        _animator.SetFloat("Speed", speed);
        Debug.Log(speed);
    }

    // Update is called once per frame
    void Update()
    { 
        if(_alive)
        {
            transform.Translate(0,0,speed * Time.deltaTime);
            Ray ray = new Ray(transform.position, transform.forward); //si muove in avanti in continuazione
           
            RaycastHit hit;
            if(Physics.SphereCast(ray, 0.75f, out hit)) //esegui il raycasting con una circonferenza attorno al raggio
            {
                GameObject hitObject = hit.transform.gameObject;
                if(hit.distance < obstacleRange)
                {
                    float angle = Random.Range(-40,40);
                    transform.Rotate(0,angle,0); 
                }
            }
        }
    }
    public void SetAlive(bool alive)
    {
        _alive = alive;
    }
}
