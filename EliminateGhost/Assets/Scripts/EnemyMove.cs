using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{

    Transform tr;
    
    public float speed;

    void Start()
    {
        tr = GetComponent<Transform>();
        StartCoroutine(DestroySelf());
    }

    // Update is called once per frame
    void Update()
    {
        tr.Translate(Vector2.left * speed);   
    }

    IEnumerator DestroySelf()
    {
        yield return new WaitForSeconds(10.0f);
        Destroy(this.gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Weapon(Clone)")
        {
            GameObject.Find("GameManager").GetComponent<Score>().score += 10;
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
    }
}
