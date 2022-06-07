using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpawner : MonoBehaviour
{
    [SerializeField] private GameObject npcPrefab;
    private GameObject[] _npcs;
    public int npc_count;
    private float speed = 6.0f;
    // Start is called before the first frame update
    void Start()
    {
        npc_count = 6;
        _npcs = new GameObject[npc_count];
    }

    // Update is called once per frame
    void Update()
    {
        for(int i=0; i<npc_count; i++)
        {
            if(_npcs[i] == null)
            {
                _npcs[i] = Instantiate(npcPrefab) as GameObject;
                _npcs[i].transform.position = new Vector3(2794.769f,32.20991f,3.538221f);
                _npcs[i].GetComponent<WanderingAI>().speed = speed;
                float angle = Random.Range(0,360f);
                _npcs[i].transform.Rotate(0,angle,0);
            }
        }
    }
}
