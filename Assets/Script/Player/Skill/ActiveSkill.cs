//#define DEFAULTCODING
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveSkill : BaseSkill
{
    [SerializeField] protected float cooldown;

    float currentCooldown;
#if DEFAULTCODING
    public override void Action()
    {

    }

    public void ReduceCooldown()
    {
        if(currentCooldown > 0)
        {
            currentCooldown -= Time.deltaTime;
        }
        else
        {
            currentCooldown = cooldown;
            Action();
        }
    }

    public virtual void Update()
    {

    }
#else

    public override void CastSkill()
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

#endif
}
