using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributesBase: MonoBehaviour
{
    // This is the base class for player attributes.
    public float Health = 100.0f;
    public float Agility = 50.0f;
    public float Vitality = 10.0f;
    public float Vigor = 20.0f;
    public SkillsBase Skill;
    private HealthBarController healthBarController;
    private GameObject HealthBar;
    private GameObject ScrollingText;
    private float Capacity = 100.0f;

    private void Start()
    {
        this.healthBarController = this.gameObject.GetComponentInChildren<HealthBarController>();
    }
    // This is the base damage formula.
    public float Attack()
    {
        return 10.0f;
    }

    public virtual float GetHealth()
    {
        return this.Health;
    }
    private void Update()
    {
        //this.healthBarController.ChangeValue(this.Health);
    }

    public virtual void TakeDamage(float damageAmount, string attackType)
	{
		this.Health = this.Health - damageAmount;

        if (this.Health < 0.0f)
        {
            this.Health = 0.0f;
        }
        Debug.Log(this.Health);
        this.healthBarController.ChangeValue(this.Health / this.Capacity);

        if (this.Capacity < 0.0f)
        {
            this.Capacity = 0.0f;
        }

        if (this.ScrollingText)
        {
            this.ShowScrollingText(damageAmount.ToString());
        }

        // TODO: calculate attribute adjustments based on attackType
    }

    private void ShowScrollingText(string message)
    {
        var scrollingText = Instantiate(this.ScrollingText, this.transform.position, Quaternion.identity);
        scrollingText.GetComponent<TextMesh>().text = message;
    }

    private void OnTriggerEnter(Collider other)
    {
        var damage = other.GetComponent<SkillsBase>().GetDamage();
        var type = other.GetComponent<SkillsBase>().GetAttackType();
        TakeDamage(damage, type);
    }
}
