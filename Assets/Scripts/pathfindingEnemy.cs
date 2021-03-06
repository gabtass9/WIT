using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class pathfindingEnemy : MonoBehaviour
{
    public Transform[] points;
  private NavMeshAgent nav;
  private int destPoint;
  public Animator _animator;
    void Start()
    {
       nav = GetComponent<NavMeshAgent>(); 
        _animator.SetFloat("Speed", 1.0f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!nav.pathPending && nav.remainingDistance < 2.5f)
        {
            	GoToNextPoint();
        }

    }
    void GoToNextPoint()
  {
  	if (points.Length == 0)
  	{
  		return;
  	}
  	nav.destination = points[destPoint].position;
  	destPoint = Random.Range(0,points.Length);
  }
}
