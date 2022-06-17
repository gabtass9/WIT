using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pathfinding : MonoBehaviour
{
  
    private UnityEngine.AI.NavMeshAgent nav;
    private int destPoint;
    private float speed;
    public Animator _animator;
    public Transform target;
    [SerializeField] private GameObject fireballPrefab;
    private GameObject _fireball;

    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
        _animator.SetFloat("Speed", 0.2f);
    }

    // Update is called once per frame
  
    void Update()
    {
        float distance = Vector3.Distance(transform.position,target.position);
        if(distance > 10)
        {
            nav.SetDestination(target.position);
            _animator.SetFloat("Speed", 0.2f);
            _animator.SetBool("IsAttacking",false);
        }
        else
        {
            nav.SetDestination(transform.position);
            _animator.SetFloat("Speed", 0.0f);
            RaycastHit hit;
            Ray ray = new Ray(transform.position, transform.forward);
            if(Physics.SphereCast(ray,0.75f,out hit))
            {
                GameObject hitObject = hit.transform.gameObject;
                if(hitObject.GetComponent<PlayerCharacter>())
                {
                    _animator.SetBool("IsAttacking",true);
                     if(_fireball == null)
                    {
                        _fireball = Instantiate(fireballPrefab) as GameObject;
                        //_fireball.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                        _fireball.transform.position = transform.position+new Vector3(0,2.0f,1.5f);
                        _fireball.transform.rotation = transform.rotation;
                    }
                }
            }
        }
    }
}
