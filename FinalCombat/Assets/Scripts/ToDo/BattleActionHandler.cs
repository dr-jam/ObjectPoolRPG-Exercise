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
            // TODO: Determine order of attack based on the formula given.
            DetermineAttackOrder();

            /* TODO: For each character 
                     1. Give a random set of skills 
                     2. Give a random target on the opposite team
                     3. Calculate damage according to the skill of the character and target 
                     4. Have target take the damage 
                     5. Change the health bar
                     6. Set a delay timer so that the animation can finish before going to the next character 
                     7. Rotate a character 90 degrees as if it has been killed when their health reaches zero or below */

        }
    }


    public GameObject[] DetermineAttackOrder()
    {
        // TODO: Determine order of attack based on the formula given.
        GameObject[] attackOrder = null;
        
        return attackOrder;
    }


    public void Escape()
    {
        gm.ExitBattle();
    }
}
