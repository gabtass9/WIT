using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pathfinding : MonoBehaviour
{
    public Transform[] points;
  
    private UnityEngine.AI.NavMeshAgent nav;
    private int destPoint;
    private float speed;
    public Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void GoToNextPoint()
  {
  	if (points.Length == 0)
  	{
  		return;
  	}
  	nav.destination = points[destPoint].position;
  	destPoint = (destPoint + 1) % points.Length;
  }
  
    void FixedUpdate()
    {
        if (!nav.pathPending && nav.remainingDistance < 0.5f)
        _animator.SetFloat("Speed", 2.0f);
  	GoToNextPoint();
    }
}
