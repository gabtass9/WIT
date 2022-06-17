using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private SettingPopup settingsPopup;
    private int _score;
    // Start is called before the first frame update
    void Start()
    {
        settingsPopup.Close();
    }
    private void OnEnemyHit()
    {
    }
    // Update is called once per frame
    void Update() //TEST CODE
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            settingsPopup.Open();
        }
    }
    public void OnOpenSettings()
    {
        settingsPopup.Open();
    }
    public void OnPointerDown()
    {
    }
}
