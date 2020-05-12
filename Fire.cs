using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fire : MonoBehaviour
{
    public float offset;
    public bool masterKey = false; //Наличие отмычек
    public int countOfMasterKey = 0; //Количество отмычек
    public Text masterKeyText;
    public int ammoPlusTazer, ammoPlusShotgun, ammoPlusPistols;
    public GameObject tazer, shotgun, pistols;


    void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotateZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotateZ + offset); //вращает персонажа за мышкой

        if (countOfMasterKey >= 1)
        {
            masterKey = true;
        }
        else
        {
            masterKey = false;
        }
        masterKeyText.text = (countOfMasterKey / 2).ToString(); // проверяет наличие отмычек и выводит их количество

        tazer.GetComponent<Tazer>().ammoCount.text = tazer.GetComponent<Tazer>().currentAmmo.ToString();
        pistols.GetComponent<Pistols>().ammoCount.text = pistols.GetComponent<Pistols>().currentAmmo.ToString();
        shotgun.GetComponent<Shotgun>().ammoCount.text = shotgun.GetComponent<Shotgun>().currentAmmo.ToString(); // эти строчки отвечают за отображение снарядов оружия
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<Door>() && Input.GetKey(KeyCode.F) && masterKey)
        {
            Debug.Log("Door is otkrita");
            collision.transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z - 89f);
            collision.GetComponent<Door>().enabled = false;
            //Destroy(collision.GetComponent<Door>());
            countOfMasterKey--;
        } // при взаимодействии с дверью и при наличии отмычек открывает её

    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.GetComponent<MasterKey>())
        {
            countOfMasterKey += 2 ;
            Destroy(other.gameObject);
        }
        else if (other.GetComponent<TazerClips>())
        {
            tazer.GetComponent<Tazer>().currentAmmo += ammoPlusTazer;
            Destroy(other.gameObject);
           
        }
        else if (other.GetComponent<PistolClip>())
        {
            pistols.GetComponent<Pistols>().currentAmmo += ammoPlusPistols;
            Destroy(other.gameObject);
           
        }
        else if (other.GetComponent<ShotgunClip>())
        {
            shotgun.GetComponent<Shotgun>().currentAmmo += ammoPlusShotgun;
            Destroy(other.gameObject);

        }// эти строчки отвечают за спор снарядов для оружия
    }
}
