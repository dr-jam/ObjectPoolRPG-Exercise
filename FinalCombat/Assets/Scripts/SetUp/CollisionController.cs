using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{

    private float Damage;

    private void OnTriggerEnter2D(Collider2D other)
    {
        this.GetComponent<AttributesBase>().TakeDamage(other.gameObject.GetComponent<SkillsBase>().Damage, other.gameObject.GetComponent<SkillsBase>().AttackType);
        //GetTakeDamage(other.gameObject, this.gameObject);
        Destroy(other.gameObject);
    }

    private void GetTakeDamage(GameObject projectile, GameObject target)
    {
        // TODO: call TakeDamage within the target's attribute script
        // You may need to check to verify the types of attribute that is attached to the target

    }

    public float GetDamage()
    {
        return this.Damage;
    }
}
