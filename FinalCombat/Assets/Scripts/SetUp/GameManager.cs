using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject PlayerCamera;
    [SerializeField] private GameObject BattleCamera;

    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject BattleHandler;
    // Start is called before the first frame update
    void Start()
    {
        this.PlayerCamera.SetActive(true);
        this.BattleCamera.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnterBattle()
    {
        this.PlayerCamera.SetActive(false);
        this.BattleCamera.SetActive(true);
        Player.GetComponent<PlayerMovement>().PlayerIsAllowedToMove = false;
        BattleHandler.GetComponent<BattleHandler>().SpawnCharacter(true);
        BattleHandler.GetComponent<BattleHandler>().SpawnCharacter(false);
    }

    public void ExitBattle()
    {
        this.PlayerCamera.SetActive(true);
        this.BattleCamera.SetActive(false);
        Player.GetComponent<PlayerMovement>().PlayerIsAllowedToMove = true;
        BattleHandler.GetComponent<BattleHandler>().DestroyCharacters();
    }
}
