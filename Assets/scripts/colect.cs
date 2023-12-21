using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colect : MonoBehaviour
{
    public float price = 2.5f;
    private PlayerHandler playerHandler;
    private void Awake() {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if(player!=null){
            playerHandler = player.GetComponent<PlayerHandler>();
        }
        
    }

    void OnCollisionEnter(Collision collision)
        {
            // Check if the colliding object has a specific tag or layer
            if (collision.gameObject.CompareTag("Mecha")||collision.gameObject.CompareTag("Pilot"))
            {
                playerHandler.money(price);
                 Destroy(transform.parent.gameObject);
            }
        }

}
