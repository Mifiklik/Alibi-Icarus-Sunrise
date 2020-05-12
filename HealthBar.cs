using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Image bar;
    public float fill;
    public float health = 5;
    private float currentHealth;
   

    public GameObject player;

    public int turretDamage;
    public int spiderDamage;

    public float forceMedication;


    public GameObject menu;

 void Start()
    {
        fill = 1f;
        currentHealth = health; // HP - bar заполнен полностью


    }


    void Update()
    {
        bar.fillAmount = fill; // регулирует заполнение HP - bar в зависимости от уровня здоровья

        fill = currentHealth / health;
        Debug.Log("current health = " + currentHealth + " fill = " + fill);

    }

    public void SpiderDamage() //Урон от робота-паука. В виде функции, потому что так можно добавить новых особенностей именно этому типу урона
    {
        currentHealth -= spiderDamage;
        if (currentHealth <= 0)
        {

            fill = 0f;
            menu.GetComponent<DieMenu>().killer = "spider";
            menu.GetComponent<DieMenu>().PlayerDie();
            Debug.Log("DieMenu");
        }

    }
    public void TurretDamage() //Урон от турелли. В виде функции, потому что так можно добавить новых особенностей именно этому типу урона
    {
        currentHealth -= turretDamage;
        if (currentHealth <= 0)
        {

            fill = 0f;
            menu.GetComponent<DieMenu>().killer = "turret";
            menu.GetComponent<DieMenu>().PlayerDie();
            Debug.Log("DieMenu");
        }
    }



    private void OnTriggerEnter2D(Collider2D hitInfo)
    {

        if (hitInfo.gameObject.tag == "AidKit")
        {
            Heal();
            Destroy(hitInfo.gameObject);
        }

    }

   
        public void Heal()
        {
            currentHealth += forceMedication;
            if (currentHealth > health)
            {
                currentHealth = health;
            }
        }


    
}
