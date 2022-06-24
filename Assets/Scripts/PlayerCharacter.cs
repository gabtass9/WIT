using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerCharacter : MonoBehaviour
{
    public int health;
    public int arenaNumber;
    [SerializeField] private Slider healthBar;
    [SerializeField] private Image fillImg;
    [SerializeField] private Text gameOver;
    private float barValueDamage;
    private Image healthBarBackground;
    private bool damaged;
    // Start is called before the first frame update
    void Start()
    {
        gameOver.enabled = false;
        barValueDamage = healthBar.maxValue / health;
        healthBarBackground = healthBar.GetComponentInChildren <Image> ();
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            Death();
            if(damaged)
            {
                //INSERIRE IMMAGINE PER DANNO SUBITO
            }
            else
            {
                //TORNARE TRAMITE LERP A SCHERMATA NORMALE
            }
            damaged = false;
        }
    }
    public void Hurt(int damage) 
    {
        damaged = true;
        health -= damage;
        //healthBar.value -= barValueDamage;
        healthBar.value -=damage;
    }
    public void Death ()
    {
        fillImg.enabled = false;
        gameOver.enabled = true;
        //Time.timeScale = 0; stoppa il gioco
        StartCoroutine(waitAndExit());
       
    }   
    IEnumerator waitAndExit()
    {
        yield return new WaitForSeconds(3);
        if(arenaNumber == 1)
        {
            SceneManager.LoadScene("Arena");
        }
        if(arenaNumber == 2)
        {
            SceneManager.LoadScene("Arena2");
        }
        if(arenaNumber == 3)
        {
            SceneManager.LoadScene("Arena3");
        }
    }
}
