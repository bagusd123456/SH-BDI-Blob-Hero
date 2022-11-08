//#define DEFAULTCODING
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobMissile : MonoBehaviour
{
#if DEFAULTCODING
    public HomingProjectile projectile;
    public List<EnemyCharacter> enemyCharacters = new List<EnemyCharacter>;
    public EnemyCharacter character;

    public override void Action()
    {
        base.Action();
        if (targetEnemy = null) return;
        var prj = Instantiate(projectile);
        prj.transform.position = transform.position + Vector3.forward;
        prj.target = targetEnemy;
    }

    public void FindTarget()
    {
        float closestDistance = Mathf.Infinity;
        EnemyCharacter closestEnemy = null;
        foreach (EnemyCharacter en in enemyCharacters)
        {
            if (en.isDead) continue;
            Vector3 goPos = en.transform.position - transform.position;
            Debug.Log("Magnitude Target" + goPos.sqrMagnitude + " ===" + en.name);
            if(goPos.sqrMagnitude < closestDistance)
            {
                closestDistance = goPos.sqrMagnitude;
                closestEnemy = en;
            }
        }

        targetEnemy = closestEnemy;
    }

    public override void Update()
    {
        base.Update();
        FindTarget();
    }
#else
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
