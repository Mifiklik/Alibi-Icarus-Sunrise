using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    
    public float dumping = 1.5f; //плавность камеры
    public Vector2 offset = new Vector2(2f, 1f); // задаваемый отступ
    public bool isLeft;
    private Transform player;
    private int lastX;

    private void Start()
    {
        offset = new Vector2(Mathf.Abs(offset.x), offset.y);
        FindePlayer();
    }

    public void FindePlayer()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
            transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, transform.position.z); // перемещает камееру к игроку
        
    }


    void Update()
    {


            Vector3 target;
                target = new Vector3(player.position.x + offset.x, player.position.y + offset.y, transform.position.z);

            Vector3 currentPosition = Vector3.Lerp(transform.position, target, dumping * Time.deltaTime);
            transform.position = currentPosition; // изменение положения камеры к игроку

    }
}
