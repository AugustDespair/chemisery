using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReactionScript : MonoBehaviour
{

    public SpriteRenderer air;

    public string killsPlayer = "metal";
    public string killsItself = "base";

    public bool IsWater = false; 

    public void Start()
    {
        air = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {

        if (IsWater) 
        {
            if (collider.tag == "Player")
            {
                PlayerInteraction pi = collider.gameObject.GetComponent<PlayerInteraction>();
                if (string.Equals(killsPlayer, pi.itemHeld))
                {
                    // Metal has turned into a base. 
                    pi.setItemHeld(killsItself);
                }
            }
        }

        else
        {
            if (collider.tag == "Player")
        {
            PlayerInteraction pi = collider.gameObject.GetComponent<PlayerInteraction>();


            if (string.Equals(killsItself, pi.itemHeld)) 
            {
                pi.resetItemHeld();
                air.color = new Color(155f, 233f, 226f, 255f); 
                IsWater = true;
            } else {
                pi.resetItemHeld();
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        }

        
    }
}
