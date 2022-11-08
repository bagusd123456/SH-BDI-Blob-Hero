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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * 5 * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        var go = Instantiate(prefabFX, transform.position,Quaternion.identity);

        Destroy(gameObject);
    }

    public override void CastSkill()
    {
        throw new System.NotImplementedException();
    }
}
