using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBase : MonoBehaviour
{

    public void FireAttack(GameObject projectile, GameObject character)
    {
        var projectilePosition = new Vector3(character.transform.position.x - 1, character.transform.position.y);
        var proj = Instantiate(projectile, projectilePosition, Quaternion.identity);
        proj.GetComponent<ProjectileMotion>().Fire();
        Destroy(proj, 5f);
    }
}
