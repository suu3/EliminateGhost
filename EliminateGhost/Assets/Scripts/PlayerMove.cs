using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed;
    
    //move
    Transform tr;
    float limitPointMin = -6.02f;
    float limitPointMax = 6.02f;

    //jump
    Rigidbody2D rigid;

    //create weapone
    public GameObject prefabWeapon;
    public bool check = true;

    void Start()
    {
        tr = GetComponent<Transform>();
        rigid = GetComponent<Rigidbody2D>();
        tr.position = new Vector2(-5.74f, -1.88f);
    }

    // Update is called once per frame
    void Update()
    {
        //좌우 키보드 사용
        if (Input.GetKey(KeyCode.RightArrow))
        {
            tr.position = new Vector2(tr.position.x + 0.01f * speed, tr.position.y);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            tr.position = new Vector2(tr.position.x - 0.01f * speed, tr.position.y);
        }

        //limit
        if(tr.position.x < limitPointMin)
        {
            tr.position = new Vector2(limitPointMin, tr.position.y);
        }

        if (tr.position.x > limitPointMax)
        {
            tr.position = new Vector2(limitPointMax, tr.position.y);
        }

        //jump
        if(rigid.velocity.y == 0 && Input.GetKey(KeyCode.UpArrow))
        {
            rigid.velocity = Vector2.zero;
            rigid.AddForce(Vector2.up * 5f, ForceMode2D.Impulse);
        }


        // Weapon 생성
        if (Input.GetKey(KeyCode.Space)&&check)
        {
            check = false;
            StartCoroutine(ShootWeapon());
        }

    }

    IEnumerator ShootWeapon()
    {
        Instantiate(prefabWeapon, new Vector2(tr.position.x + 1.65f, tr.position.y + 0.66f), Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        check = true;
    }
}
