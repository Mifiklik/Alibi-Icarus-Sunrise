using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WeaponSwitch : MonoBehaviour
{
    public int weaponSwitch = 0;
    public GameObject pistolsUI;
    public GameObject shotgunUI;
    public GameObject tazerUI;
    void Start()
    {
        SelectWeapon();
    }

    
    void Update()
    {
        switch (weaponSwitch)
        {
            case 0:
                pistolsUI.SetActive(true);
                shotgunUI.SetActive(false);
                tazerUI.SetActive(false);
                break;
            case 1:
                pistolsUI.SetActive(false);
                shotgunUI.SetActive(true);
                tazerUI.SetActive(false);
                break;
            case 2:
                pistolsUI.SetActive(false);
                shotgunUI.SetActive(false);
                tazerUI.SetActive(true);
                break;
        }// в зависимости от выбранного оружи выводит нужный интерфейс
        int currentWeapon = weaponSwitch;
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (weaponSwitch >= transform.childCount - 1)
            {
                weaponSwitch = 0;
            }
            else
            {
                weaponSwitch++;
            }
            
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (weaponSwitch <= 0)
            {
                weaponSwitch = transform.childCount - 1;
            }
            else
            {
                weaponSwitch--;
            }

        }// позволяет выбирать оружие колёсиком мыши

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            weaponSwitch = 0;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2)
        {
            weaponSwitch = 1;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 3)
        {
            weaponSwitch = 2;
        }
        //выбор оружия цифрами

        if (currentWeapon != weaponSwitch)
        {
            SelectWeapon();
        }// выводит нужное оружие
    }

    void SelectWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == weaponSwitch)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            i++;
        }
    }
}
