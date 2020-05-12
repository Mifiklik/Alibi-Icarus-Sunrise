using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fraction : MonoBehaviour
{
    public float speed;
    public float destroyTime;
    public int damage = 30;


    void Start()
    {
        Invoke("DestroyAmmo", destroyTime); // запуск режима самоунитжения снаряда через определённое время
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

        if (hitInfo.tag != "Bullet" && hitInfo.tag != "TargetZone")
        {
            if (hitInfo.GetComponent<Damage>())
            {
                hitInfo.GetComponent<Damage>().ShotgunDamage();
            }
            Destroy(gameObject);
        }
    }//не взимодействует с другими снарядами и зонами взаимодействия, а при попадании по врагу вызывает соответствующий скрипт для нанесения урона
}
