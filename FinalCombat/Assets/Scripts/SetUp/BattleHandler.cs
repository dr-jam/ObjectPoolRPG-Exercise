using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BattleHandler : MonoBehaviour
{
    [SerializeField] private Transform PlayerPrefab;
    [SerializeField] private Transform EnemyPrefab;
    [SerializeField] private Transform HealthBarPrefab;
    [SerializeField] private Camera BattleCamera;
    public Texture2D PlayerSpiritSheet;
    public Texture2D EnemySpiritSheet;
    private Vector3 Position;
    private static BattleHandler BattleInstance;
    private GameObject[] Spawns;

    public static BattleHandler GetInstance()
    {
        return BattleInstance;
    }

    private void Awake()
    {
        BattleInstance = this;
    }
    public void SpawnCharacter(bool isPlayerTeam)
    {
        if (isPlayerTeam)
        {
            for (int i = 0; i < 3; i++)
            {
                Position = new Vector3(this.BattleCamera.transform.position.x + 3, this.BattleCamera.transform.position.y - 2 + i*2);
                var player = Instantiate(PlayerPrefab, Position, Quaternion.identity);
                player.gameObject.tag = "PlayerTeam";

                player.gameObject.AddComponent<Attack>();

                var HealthPosition = Position + new Vector3(0, 1, 0);
                var health = Instantiate(HealthBarPrefab, HealthPosition, Quaternion.identity);
                health.transform.parent = player.transform;
                EquipCharacter(player.gameObject);

                player.gameObject.AddComponent<AttributesBase>();
                player.gameObject.AddComponent<SkillsBase>();
            }
        }
        else
        {
            for (int i = 0; i < 3; i++)
            {
                Position = new Vector3(this.BattleCamera.transform.position.x - 3, this.BattleCamera.transform.position.y - 2 + i * 2);
                var enemy = Instantiate(EnemyPrefab, Position, Quaternion.identity);
                enemy.gameObject.tag = "EnemyTeam";
                var HealthPosition = Position + new Vector3(-1, 1, 0);
                var health = Instantiate(HealthBarPrefab, HealthPosition, Quaternion.identity);
                health.transform.parent = enemy.transform;
                EquipCharacter(enemy.gameObject);

                enemy.gameObject.AddComponent<AttributesBase>();
                enemy.gameObject.AddComponent<SkillsBase>();
            }
        }
    }

    private void EquipCharacter(GameObject character)
    {
        // TODO: randomly equip the character with a type of skill
        character.AddComponent<AttackBase>();
    }

    public void DestroyCharacters()
    {
        this.Spawns = FindGameObjectsWithTags(new string[] { "PlayerTeam", "EnemyTeam" });
        foreach (GameObject spawn in this.Spawns)
        {
            Destroy(spawn);
        }
    }

    GameObject[] FindGameObjectsWithTags(params string[] tags)
    {
        var all = new List<GameObject>();

        foreach (string t in tags)
        {
            var temp = GameObject.FindGameObjectsWithTag(t).ToList();
            all = all.Concat(temp).ToList();
        }

        return all.ToArray();
    }

}
