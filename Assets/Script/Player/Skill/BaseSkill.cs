using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseSkill : MonoBehaviour
{
    public string skillName;
    public string skillDescription;
    public float time;
    public float cooldownTime;
    public bool canCast;

    public int baseDamage;
    public float projectileSpeed = 25f;
    public GameObject prefabFX;

    public int level = 1;
    public abstract void CastSkill();
    public abstract void OnLevelUp();

    public void Update()
    {
        CheckSkill();
    }

    public void CheckSkill()
    {
        if (time < 0)
            canCast = true;
        else
        {
            time -= Time.deltaTime;
            canCast = false;
        }
    }
}
