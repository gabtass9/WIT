using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perri : MonoBehaviour
{
  
    private UnityEngine.AI.NavMeshAgent nav;
    private int destPoint;
    private float speed;
    public Animator _animator;
    public GameObject character;
    public Transform target;
    [SerializeField] private Transform[] projectileSpawnPoint;
    [SerializeField] private GameObject projectilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
        character=GetComponent<GameObject>();
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
                if(hit.collider.tag == "Player")
                {

                    Debug.Log("LA PERRI TI PICCHIA UN SACCO");
                    foreach( Transform SpawnPoints in projectileSpawnPoint)
                    {
                        Instantiate(projectilePrefab,SpawnPoints.position,transform.rotation);
                    }
                    //ELIMINARE COMMENTO 
                    //METTERE QUI LA COSA CHE LA PERRI TIPO TI MENA
                    //ADESSO ASPETTO CHE TORNA GABRIELE PER CENARE
                    //PERCHE' HO VERAMENTE FAME SE NON TORNA LO MENO

                    //CAZZATE A PARTE
                    /* COSE DA FARE
                        IMPOSTARE ANIMAZIONE DELL' ATTACCO DELLA PERRI
                        ISTANZIARE I PROIETTILI DELLA PERRI
                        VEDERE SE COLPISCE O NO
                    */
                }
            }
        }
    }
}
