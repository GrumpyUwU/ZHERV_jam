using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shopManager : MonoBehaviour
{
    public GameObject Pilot;
    public GameObject Mecha;
    public bool Shopping;
    
    private MechaController mechaController;
    private PilotController pilotController;
    

    private void Awake() {
        pilotController = Pilot.GetComponent<PilotController>();
        mechaController = Mecha.GetComponent<MechaController>();
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the colliding object has a specific tag or layer
        if (collision.gameObject.CompareTag("Pilot"))
        {
            Shopping = true;

        }
    }

    void OnCollisionExit(Collision collision)
    {
        // Check if the colliding object has a specific tag or layer
        if (collision.gameObject.CompareTag("Pilot"))
        {
            Shopping = false;
        }
    }

    private void Update() {
        if(Shopping){
            if (Input.GetKeyDown(KeyCode.E)){
                mechaController.Durability=100f;
            }
        }
    }
    
}
