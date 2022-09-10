using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReactionScript : MonoBehaviour
{

    public string killsPlayer = "metal";
    public string killsItself = "base";

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            PlayerInteraction pi = collider.gameObject.GetComponent<PlayerInteraction>();
            if (string.Equals(killsPlayer, pi.itemHeld))
            {
                pi.resetItemHeld();
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            } else if (string.Equals(killsItself, pi.itemHeld))
            {
                pi.resetItemHeld();
                gameObject.SetActive(false);
            }
        }
    }
}
