using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinExit : MonoBehaviour
{
    public GameObject menu;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            menu.GetComponent<WinMenu>().winReson = "exit";
            menu.GetComponent<WinMenu>().PlayerWin();
        }
    }// этот скрипт помогает понять, что победа совершилась птём побега из уровня
}
