using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pathfinding : MonoBehaviour
{
  
    private UnityEngine.AI.NavMeshAgent nav;
    private int destPoint;
    private int counter;
    private float speed;
    public Animator _animator;
    public Transform target;
    [SerializeField] private GameObject fireballPrefab;
    private GameObject _fireball;

    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
        _animator.SetFloat("Speed", 1.0f);
        _animator.SetBool("IsAttacking",false);
    }

    // Update is called once per frame
  
    void Update()
    {
        float distance = Vector3.Distance(transform.position,target.position);
        if(distance > 10)
        {
            nav.SetDestination(target.position);
            _animator.SetFloat("Speed", 1.0f);
            _animator.SetBool("IsAttacking",false);
        }
        else
        {
            nav.SetDestination(transform.position);
            _animator.SetFloat("Speed", 0.0f);
            _animator.SetBool("IsAttacking",false);
            Vector3 lookVector = target.position - transform.position;                   //***********************************************************************
            Quaternion rot = Quaternion.LookRotation(lookVector);                    //Con questo codice il boss se si ferma mi guarda sempre, tiene lo sguardo fisso su di me
            transform.rotation = Quaternion.Slerp(transform.rotation, rot, 1);      //************************************************************************
            RaycastHit hit;
            Ray ray = new Ray(transform.position, transform.forward);
            if(Physics.SphereCast(ray,0.75f,out hit))
            {
                GameObject hitObject = hit.transform.gameObject;
                if(hitObject.GetComponent<PlayerCharacter>()) //VA SETTATO BENE QUESTO NUMERO
                {
                    
                    /*
                        SICCOME L' ANIMAZIONE SI RIPETE SE LA FIREBALL NON E' NULLA 
                        BISOGNA GESTIRE I TEMPI DI VOLO MASSIMI DELLA FIREBALL
                        AD ESEMPIO SE LA FIREBALL VOLA PER PIù DI 10 UNITA'(CHE E' LA DISTANZA DA CUI SPARA LA PERRI)
                        SI DOVREBBE DISTRUGGERE
                    */
                    if(_fireball == null && !this._animator.GetCurrentAnimatorStateInfo(0).IsName("Throwing"))
                    {
                        _animator.SetBool("IsAttacking",true);
                        _fireball = Instantiate(fireballPrefab) as GameObject;
                        _fireball.transform.position = transform.position+new Vector3(0,2.0f,1.5f);
                        _fireball.transform.rotation = transform.rotation;
                    }
                    if(this._animator.GetCurrentAnimatorStateInfo(0).IsName("Throwing") && this._animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
                    {
                        _animator.SetBool("IsAttacking",false);

                    }
                }
            }
        }
    }
}
