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
        enemyArray = GameObject.FindGameObjectsWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
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
            }
        }
    }

    public override void CastSkill()
    {
        if (canCast)
        {
            time = cooldownTime;
            GO = Instantiate(prefabFX, transform.position + offset, Quaternion.identity);
            GO.transform.Rotate(transform.position, 360f);
            GO.GetComponent<MissileBehavior>().target = target;
        }   
    }

    
}
