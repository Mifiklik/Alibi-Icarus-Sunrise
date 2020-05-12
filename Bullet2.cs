using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet2 : MonoBehaviour
{
    public float speed;
    public float destroyTime;


    void Start()
    {
        Invoke("DestroyAmmo", destroyTime);  // Запусает уничожение после заданного вреени
    }

    
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime); // Движение снаряда
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
                hitInfo.GetComponent<Damage>().PistolDamage(); // Если это противник, то наносит ему урон
            }
            Destroy(gameObject);  // при контакте с чем-либо кроме другого снаряда или зоны взаимодействия уничтожится 
        }
    }
}
