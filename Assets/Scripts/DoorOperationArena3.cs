using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorOperationArena3: MonoBehaviour
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
        SceneManager.LoadScene("Arena3");
        //CAMBIARE SCENA
    }
}
