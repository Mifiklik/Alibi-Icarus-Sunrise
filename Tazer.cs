using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tazer : MonoBehaviour
{
    public GameObject ammo; //снаряд
    public int ammoPlus; //Сколько добавляется при подборе боеприпасов
    public int currentAmmo; // Кол-во боеприпасов
    public Transform shotDirection; //Место выстрела 1 и 2

    private float timeShot;
    public float startTime;

    [SerializeField]
    public Text ammoCount;

    private void Start()
    {
        ammoCount.text = currentAmmo.ToString();
    }
    void Update()
    {
        if (timeShot <= 0)
        {
            if (currentAmmo > 0 && Input.GetMouseButtonDown(0))
            {
                Instantiate(ammo, shotDirection.position, transform.rotation);
                currentAmmo--;
                timeShot = startTime;


            }
        }
        else
        {
            timeShot -= Time.deltaTime;
        }// стрельба с отсечкой времени


        ammoCount.text = currentAmmo.ToString();



    }


    


}
