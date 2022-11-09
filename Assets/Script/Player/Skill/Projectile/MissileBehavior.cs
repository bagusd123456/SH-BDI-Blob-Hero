//#define DEFAULTCODING

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileBehavior : MonoBehaviour
{
#if DEFAULTCODING


//rotating homingMissile
    public BaseCharacter target;
    public override void Shoot()
    {
        if(target == null)
        {
            OnDestroyed();
            return;
        }
        Vector3 goPos = target.transform.position - transform.position;
        goPos.y = 0;
        transform.position += goPos.normalized * projectileSpeed * Time.deltaTime;

        if(goPos.sqrMagnitude < 1.5f)
        {
            OnDestroyed();
            target.TakeDamage(projectileDamage);
        }
    }
#else

    public GameObject target;
    public GameObject blowFX;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        ChangeDirection();
    }

    public void ChangeDirection()
    {
        Vector3 direction = target.transform.position - transform.position;
        direction.Normalize();

        float rotateAmount = Vector3.Cross(direction, transform.up).z;
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();

        rb.angularVelocity = transform.up * -rotateAmount * 25f;
        rb.velocity = direction * 25f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            if(other.GetComponent<EnemyCharacter>() != null)
            {
                other.GetComponent<EnemyCharacter>().TakeDamage(25);
            }
        }
        var go = Instantiate(blowFX, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
#endif
}
