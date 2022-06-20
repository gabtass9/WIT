using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    public GameObject optionsMenu;
    public GameObject mmenu;

    void Start()
    {
        for (int i = 0; i < optionsMenu.transform.childCount; i++)
        {
            GameObject child = optionsMenu.transform.GetChild(i).gameObject;
            if (child != null)
                child.SetActive(false);
        }
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    public void OptionsGame()
    {
         for (int i = 0; i < optionsMenu.transform.childCount; i++)
        {
            GameObject child = optionsMenu.transform.GetChild(i).gameObject;
            if (child != null)
                child.SetActive(true);
        }
         for (int i = 0; i < mmenu.transform.childCount; i++)
        {
            GameObject child = mmenu.transform.GetChild(i).gameObject;
            if (child != null)
                child.SetActive(false);
        }
    }
    public void BackGame()
    {
         for (int i = 0; i < optionsMenu.transform.childCount; i++)
        {
            GameObject child = optionsMenu.transform.GetChild(i).gameObject;
            if (child != null)
                child.SetActive(false);
        }
         for (int i = 0; i < mmenu.transform.childCount; i++)
        {
            GameObject child = mmenu.transform.GetChild(i).gameObject;
            if (child != null)
                child.SetActive(true);
        }
    }
    public void QuitGame()
    {
       Debug.Log("stai uscendo dal gioco");
        //Application.Quit();

    }
}
