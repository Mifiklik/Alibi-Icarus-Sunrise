using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IEnumerator = System.Collections.IEnumerator;

public class Damage : MonoBehaviour
{
    public GameObject menu;
    public Sprite[] sprites = new Sprite[2]; // спрайты для разных ситуаций в том числе для жизни и смерти
    public int health;
    public int pistolDamage;
    public int shotgunDamage;
    public bool winKill; //его нужно убить, чтоб победить

    public void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[0]; //выберается 1 спрайт
    }

    public void PistolDamage()
    {
        health -= pistolDamage;
        if (health <= 0)
        {
            if (gameObject.GetComponent<Turret>())
            {
                Destroy(gameObject.GetComponent<Turret>());
            }
            else if (gameObject.GetComponent<Spider>())
            {
                Destroy(gameObject.GetComponent<Spider>());
            }
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[1];
            Destroy(gameObject.GetComponent<Rigidbody2D>());
            Destroy(gameObject.GetComponent<BoxCollider2D>());
            if (winKill)
            {
                menu.GetComponent<WinMenu>().winReson = "kill";
                menu.GetComponent<WinMenu>().PlayerWin();
            }
        } //урон от писталета и если персонаж погиб то удаляются все ненужные его компанеты
    }

    public void ShotgunDamage()
    {
        health -= shotgunDamage;
        if (health <= 0)
        {
            if (gameObject.GetComponent<Turret>())
            {
                Destroy(gameObject.GetComponent<Turret>());
            }
            else if (gameObject.GetComponent<Spider>())
            {
                Destroy(gameObject.GetComponent<Spider>());
            }
            
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[1];
            Destroy(gameObject.GetComponent<Rigidbody2D>());
            Destroy(gameObject.GetComponent<BoxCollider2D>());

            if (winKill)
            {
                menu.GetComponent<WinMenu>().winReson = "kill";
               menu.GetComponent<WinMenu>().PlayerWin();
            }
        }//урон от дробовика и если персонаж погиб то удаляются все ненужные его компанеты
    }

    public void Stun()
    {
        if (gameObject.GetComponent<Turret>())
        {
            Debug.Log("To stun");
            gameObject.GetComponent<Turret>().stun = true;
        }
        else if (gameObject.GetComponent<Spider>())
        {
            gameObject.GetComponent<Spider>().stun = true;
        }
    }//В зависимости от насителя ссылается на его скрипт для определения времени оглушения
}
