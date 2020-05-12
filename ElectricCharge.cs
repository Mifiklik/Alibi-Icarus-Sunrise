using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricCharge : MonoBehaviour
{
    public float speed;
    public float destroyTime;
    public int damage = 30;


    void Start()
    {
        Invoke("DestroyAmmo", destroyTime); // сапуск процесса самоунитожения
    }


    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime); //движение снаряда
    }

    void DestroyAmmo()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.tag != "TargetZone")
        {
            if (hitInfo.GetComponent<ElectricDoor>())
            {
                hitInfo.GetComponent<ElectricDoor>().Open();
            }
            else if (hitInfo.GetComponent<Damage>())
            {
                hitInfo.GetComponent<Damage>().Stun();
            }
            Destroy(gameObject);
        }
        //Не взаимодействует с зоной взаимодействия,при контакте с железной дверью открывает её а при контакте с врагом ссылается на скрипт для оглушения его
    }
}
