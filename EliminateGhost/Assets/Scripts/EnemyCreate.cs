using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreate : MonoBehaviour
{
    public GameObject prefabEnemy;

    public Vector2 limitMax;
    public Vector2 limitMin;

    void Start()
    {
        StartCoroutine(CreateEnemy());      
    }

    void Update()
    {
        
    }

    IEnumerator CreateEnemy()
    {
        while (true)
        {
            float locationX = Random.Range(limitMin.x, limitMax.x);
            float locationY = Random.Range(limitMin.y, limitMax.y);
            Vector2 creatingPoint = new Vector2(locationX, locationY);

            Instantiate(prefabEnemy, creatingPoint, Quaternion.identity);

            float creatingTime = Random.Range(0.5f, 3.0f);
            yield return new WaitForSeconds(creatingTime);

        }
    }
}
