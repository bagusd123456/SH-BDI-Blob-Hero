using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public int enemyMax;
    public GameObject[] enemyPrefab;
    public List<GameObject> enemyList = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyList.Count < enemyMax)
        {
            enemyList.Add(Instantiate(enemyPrefab[Random.Range(0,enemyList.Count + 1)]));
        }

        for (int i = 0; i < enemyList.Count; i++)
        {
            if (enemyList[i] == null)
                enemyList.RemoveAt(i);
        }
    }
}
