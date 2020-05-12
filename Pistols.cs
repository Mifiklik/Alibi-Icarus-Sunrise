using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Pistols : MonoBehaviour
{
    public GameObject ammo; //снаряд
    public int ammoPlus; //Сколько добавляется при подборе боеприпасов
    public int currentAmmo; // Кол-во боеприпасов
    public Transform shotDirection1; //Место выстрела 1 и 2
    public Transform shotDirection2;

    private float timeShotL;
    private float timeShotR;
    public float startTime;

    [SerializeField]
    public Text ammoCount;

    private void Start()
    {
        ammoCount.text = currentAmmo.ToString();
    }
    void Update()
    {
        if (timeShotL <= 0)
        {
            if (currentAmmo > 0 && Input.GetMouseButtonDown(0))
            {
                Instantiate(ammo, shotDirection1.position, transform.rotation); 
                currentAmmo--;
                timeShotL = startTime;
              
                
            }
        }
        else
        {
            timeShotL -= Time.deltaTime;
        } //Выстрел из левого пистолета с задержко, чтоб игрок не ог спамить матронами

        if (timeShotR <= 0)
        {
            if (currentAmmo > 0 && Input.GetMouseButtonDown(1))
            {
                Instantiate(ammo, shotDirection2.position, transform.rotation);
                currentAmmo--;
                timeShotR = startTime;
            }
        }
        else
        {
            timeShotR -= Time.deltaTime;
        }//Выстрел из правого пистолета с задержко, чтоб игрок не ог спамить матронами




        ammoCount.text = currentAmmo.ToString();

       

    }

   

   

 
}
