using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseSkill : MonoBehaviour
{
    public float time;
    public float cooldownTime;
    public bool canCast;

    public int baseDamage;
    public float projectileSpeed = 25f;
    public GameObject prefabFX;
    public abstract void CastSkill();

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
