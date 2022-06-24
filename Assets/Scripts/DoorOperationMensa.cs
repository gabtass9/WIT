using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorOperationMensa: MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void Operate()
    {
         GameEvent.posizione=transform.position;
        GameEvent.posizione.z=0.0f;
        SceneManager.LoadScene("Mensa");
        //CAMBIARE SCENA
    }
}
