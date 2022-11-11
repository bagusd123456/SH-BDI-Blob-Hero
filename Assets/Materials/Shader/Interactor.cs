using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{   
    [SerializeField]
    float radius;
    float time;

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Shader.SetGlobalVector("_Position", transform.position);
        Shader.SetGlobalFloat("_Radius", radius);
    }

}