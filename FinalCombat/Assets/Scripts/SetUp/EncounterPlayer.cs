using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncounterPlayer : MonoBehaviour
{
    private GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        this.gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>(); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Encounters player
        if(collision.gameObject.name == "Player")
        {
            gm.EnterBattle();
        }
    }
}
