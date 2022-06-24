using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractMensa: MonoBehaviour
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
        if(GameEvent.FrequenzaMensa<4)
        {
            GameEvent.FrequenzaMensa++;
            GameEvent.Health=1.25f*GameEvent.FrequenzaMensa*100;
        }

        //CAMBIARE SCENA
    }
}
