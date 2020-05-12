using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Spider : MonoBehaviour
{
    private GameObject player; // Для определения местоположения игрока
    public int timeStun; // Время оглушения
    public bool stun = false; // Для проверки оглушён ли объект
    public float speed; //Скорость передвижения

    private float timeShot; //время до атаки
    public float startTime; // время между атаками, т.е. timeSot после атаки откатывается до начального значения времени ааки



    public void Start()
    {
        player = GameObject.FindWithTag("Player"); //ищет игрока
    }

    void Update()
    {
       

        if (stun)
        {
            Debug.Log("Stun is ready");
            StartCoroutine("Stun");
        } // запускает оглушение 
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !stun)
        {
            Vector3 difference = player.transform.position - transform.position;
            float rotateZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotateZ);
            transform.Translate(Vector2.right * speed * Time.deltaTime); //поворот к игроку и движение прямо
        }

       
    }
    private void OnCollisionStay2D(Collision2D collision)
    {

        if (collision.gameObject.GetComponent<HealthBar>())
        {
            if (timeShot <= 0)
            {
                player.GetComponent<HealthBar>().SpiderDamage();
                timeShot = startTime;

            }
            else
            {
                timeShot -= Time.deltaTime;
            }

        }
    }// наносит игроку урон раз в ккакое-то время при контакте




    public IEnumerator Stun()
    {
        Debug.Log("Stun...");
        yield return new WaitForSeconds(timeStun);
        stun = false;
    }

}
