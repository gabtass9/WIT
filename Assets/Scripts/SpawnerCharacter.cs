using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerCharacter : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Character;
    void Start()
    {
        Character.transform.position=GameEvent.posizione;

        Debug.Log("SPAWNER"+GameEvent.posizione);
    }

}
