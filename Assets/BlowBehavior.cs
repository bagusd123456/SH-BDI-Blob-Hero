using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlowBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
            if (other.GetComponent<EnemyCharacter>() != null)
                other.GetComponent<EnemyCharacter>().TakeDamage(20);
    }
}
