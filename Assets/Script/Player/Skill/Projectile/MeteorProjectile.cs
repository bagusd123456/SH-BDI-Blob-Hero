using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorProjectile : BaseSkill
{
    //public override void Shoot()
    //{
    //    Vector3 ground = transform.position;
    //    ground.y = 0;
    //}

    public GameObject blowFX;
    public float scaleUp = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }

    public override void CastSkill()
    {
        if (canCast)
        {
            time = cooldownTime;
            var go = Instantiate(prefabFX, transform.position + Vector3.up * 10f, Quaternion.identity);
            go.GetComponent<MeteorBehavior>().blowFX = blowFX;
        }
        
    }

    public override void OnLevelUp()
    {
        if (!gameObject.GetComponent<MeteorProjectile>().enabled)
            gameObject.GetComponent<MeteorProjectile>().enabled = true;

        else
            scaleUp += 0.2f;

        //base.OnLevelUp();
    }
}
