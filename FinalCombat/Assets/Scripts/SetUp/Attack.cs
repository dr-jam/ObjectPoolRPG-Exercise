using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private GameObject Projectile;
    private GameObject[] ProjectileSpawn;

    public void FireAttack()
    {
        this.ProjectileSpawn = GameObject.FindGameObjectsWithTag("PlayerTeam");

        foreach (GameObject spawn in ProjectileSpawn)
        {
            var projectilePosition = new Vector3(spawn.transform.position.x - 1, spawn.transform.position.y);
            var proj = Instantiate(this.Projectile, projectilePosition, Quaternion.identity);
            proj.transform.Rotate(0, 0, 90);
            proj.GetComponent<ProjectileMotion>().Fire();
            Destroy(proj, 5f);
        }
    }
}
