using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBattle : MonoBehaviour
{
    public void SetUp(bool isPlayerTeam)
    {
        if (isPlayerTeam)
        {
            this.gameObject.GetComponent<Renderer>().material.mainTexture = BattleHandler.GetInstance().PlayerSpiritSheet;
        }
        else
        {
            this.gameObject.GetComponent<Renderer>().material.mainTexture = BattleHandler.GetInstance().EnemySpiritSheet;
        }
    }
}
