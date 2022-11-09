using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MeteorBehavior : MonoBehaviour
{
    public GameObject blowFX;
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
        var go = Instantiate(blowFX, transform.position, Quaternion.identity);
        MeteorProjectile meteor = FindObjectOfType<MeteorProjectile>();
        go.transform.localScale = new Vector3(go.transform.localScale.x * meteor.scaleUp, go.transform.localScale.y * meteor.scaleUp, go.transform.localScale.z * meteor.scaleUp);
        Destroy(gameObject);
    }
}
