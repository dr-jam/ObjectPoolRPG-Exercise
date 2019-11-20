using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleActionHandler : MonoBehaviour
{
    [SerializeField] private GameManager gm;
    [SerializeField] private GameObject BattleHandler;
    private GameObject[] playerTeam;
    private GameObject[] enemyTeam;
    // Contains characters from both player and enemy teams.
    private GameObject[] bothTeams;
    

    // Start is called before the first frame update
    void Start()
    {
        this.gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        this.playerTeam = GameObject.FindGameObjectsWithTag("PlayerTeam");
        this.enemyTeam = GameObject.FindGameObjectsWithTag("EnemyTeam");
    }

    public void StartBattle()
    {
        bool gameOver = false;

        while (!gameOver)
        {
            // TODO: Display health status of each character using the health bars.
            UpdateHealthBar();

            // TODO: Determine order of attack based on the formula given.
            DetermineAttackOrder();

            // TODO: Pass into the AttackBase component of each character the projectile and character.
            //       BattleHandler has a component called AttackBase. 

            // TODO: Simulate battle using attack order by calling TakeDamage functions.

            // TODO: Rotate a character 90 degrees as if it has been killed when their 
            // TODO: Display winner in console when opposite team is defeated.
            //       Use the GetHealth function to help you.

        }
    }

    public GameObject[] DetermineAttackOrder()
    {
        // TODO: Determine order of attack based on the formula given.
        GameObject[] attackOrder = null;
        
        return attackOrder;
    }

    public void UpdateHealthBar()
    {
        // TODO: Display health status of each character using the health bars.

    }

    public void Escape()
    {
        gm.ExitBattle();
    }
}
