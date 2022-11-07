using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public void Init(string name)
    {
        gameObject.name = name;
    }
    public void Remove()
    {
        Destroy(gameObject);
    }
}
