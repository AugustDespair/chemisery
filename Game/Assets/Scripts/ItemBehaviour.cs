using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehaviour : MonoBehaviour
{
    public string group = "metal";

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            collider.gameObject.GetComponent<PlayerInteraction>().setItemHeld(group);
            gameObject.SetActive(false);
        }
    }
}
