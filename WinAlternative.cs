using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinAlternative : MonoBehaviour
{
    public GameObject menu;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            menu.GetComponent<WinMenu>().winReson = "alternative";
            menu.GetComponent<WinMenu>().PlayerWin();
        }
    } // Этот скрипт выводит концовку, которая является пасхалкой и при этом самым приятным концом, а за одно каноничным и помогает создать возможность выбора
}
