using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpawner : MonoBehaviour
{
    [SerializeField] private GameObject npcPrefab;
    private GameObject[] _npcs;
    public int npc_count;
    // Start is called before the first frame update
    void Start()
    {
        /*npc_count = 6;
        _npcs = new GameObject[npc_count];
         for(int i=0; i<npc_count; i++)
        {
            if(_npcs[i] == null)
            {
                _npcs[i] = Instantiate(npcPrefab) as GameObject;
                _npcs[i].transform.position = new Vector3(2794.769f,32.20991f,3.538221f);
                
            }
        }*/
        for (int i =0;i<npc_count;i++)
        {
            GameObject g=Instantiate(npcPrefab) as GameObject;
            Vector3 position=new Vector3(Random.Range(0,2700),32.209f,Random.Range(-6,5));
            g.transform.position=position;
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
