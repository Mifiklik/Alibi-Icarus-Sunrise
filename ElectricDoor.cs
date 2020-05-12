using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricDoor : MonoBehaviour
{
    public void Open()
    {
        Debug.Log("Door is otkrita");
        transform.rotation *= Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z + 89f);
        Destroy(gameObject.GetComponent<ElectricDoor>()); //открытие железной двери
    }
}
