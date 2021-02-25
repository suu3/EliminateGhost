using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMove : MonoBehaviour
{
    Transform tr;
    public float speed;

    void Start()
    {
        tr = GetComponent<Transform>();
        StartCoroutine(DestroySelf());
    }

    void Update()
    {
        tr.Translate(Vector2.right * speed);
    }

    IEnumerator DestroySelf()
    {
        yield return new WaitForSeconds(5.0f);
        Destroy(this.gameObject);
    }
}
