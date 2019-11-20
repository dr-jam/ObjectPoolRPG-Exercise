using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillsBase: MonoBehaviour
{
    public float Damage;
    public string AttackType;

    public SkillsBase(float damage = 5, string AttackType = "physical")
    {
        this.Damage = damage;
        this.AttackType = AttackType;
    }

    public float GetDamage()
    {
        return this.Damage;
    }

    public string GetAttackType()
    {
        return this.AttackType;
    }
}
