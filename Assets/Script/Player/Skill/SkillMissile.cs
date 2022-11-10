using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class SkillMissile : BaseSkill
{
    public GameObject target;
    private GameObject GO;
    public Vector3 offset;
    public GameObject[] enemyArray;
    float closestDistance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enemyArray = GameObject.FindGameObjectsWithTag("Enemy");
        base.Update();
        TargetClose();
    }

    public void TargetClose()
    {
        closestDistance = Mathf.Infinity;
        foreach (var item in enemyArray)
        {
            Vector3 direction = transform.position - item.transform.position;

            float distance = Vector3.Distance(item.transform.position, this.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                target = item;
                if(item.GetComponent<EnemyCharacter>() != null)
                    if(item.GetComponent<EnemyCharacter>().isDead)
                        target = null;
            }
        }
    }

    public override void CastSkill()
    {
        if (canCast && target != null)
        {
            time = cooldownTime;
            GO = Instantiate(prefabFX, transform.position + offset, Quaternion.identity);
            GO.transform.Rotate(transform.position, 360f);
            GO.GetComponent<MissileBehavior>().target = target;
        }   
    }

    public override void OnLevelUp()
    {
        if (!gameObject.GetComponent<SkillMissile>().enabled)
            gameObject.GetComponent<SkillMissile>().enabled = true;

        else
        {
            if (cooldownTime > 0)
            {
                cooldownTime -= 0.2f / 1.5f;
                if (cooldownTime < 0) cooldownTime = 0.02f;
            }
        }

        
    }
}
