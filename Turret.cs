using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IEnumerator = System.Collections.IEnumerator;

public class Turret : MonoBehaviour
{
    private GameObject player; // Для определения местоположения игрока
    public GameObject ammo; //снаряд
    public Transform shotDirection; //Место выстрела 1 и 2
    public int timeStun; // Время оглушения
    public bool stun = false; // Для проверки оглушён ли объект

    private float timeShot; //время до атаки
    public float startTime; // время между атаками, т.е. timeSot после атаки откатывается до начального значения времени ааки

    public void Start()
    {
        player = GameObject.FindWithTag("Player"); // ищет игрока
    }

    void Update()
    {
        if (!stun)
        {
            Vector3 difference = player.transform.position - transform.position;
            float rotateZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotateZ);
        } // крутится в сторону игрока
        
        if (stun)
        {
            Debug.Log("Stun is ready");
            StartCoroutine ("Stun");
        }
    }//вводит в оглушение если попали электрошокером

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !stun)
        {
            if (timeShot <= 0)
            {
                Instantiate(ammo, shotDirection.position, transform.rotation);
                timeShot = startTime;
                
            }
            else
            {
                timeShot -= Time.deltaTime;
            }
            Debug.Log("Pif Paf");
        } 
        
    }// если игрок наглеет и заходит на территорию турелли,, то она стреляет

    public IEnumerator Stun()
    {
        Debug.Log("Stun...");
        yield return new WaitForSeconds(timeStun);
        stun = false;

    }// сопрограмма для оглушения
}
