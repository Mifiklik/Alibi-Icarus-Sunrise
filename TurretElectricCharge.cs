using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretElectricCharge : MonoBehaviour
{
    public float speed;
    public float destroyTime;


    void Start()
    {
        Invoke("DestroyAmmo", destroyTime); // режим самоуничтожения для снаряда
    }


    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime); // снаряд летит
    }

    void DestroyAmmo()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {

        if (hitInfo.tag != "TargetZone")
        {
            if (hitInfo.GetComponent<HealthBar>())
            {
                hitInfo.GetComponent<HealthBar>().TurretDamage();
            }
            Destroy(gameObject);
        }
    }// при попадании по игроку наносит ему урон
}
