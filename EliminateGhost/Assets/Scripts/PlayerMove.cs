﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //move
    public float speed;
    Transform tr;
    float limitPointMin = -6.02f;
    float limitPointMax = 6.02f;

    //jump
    Rigidbody2D rigid;

    //create weapon
    public GameObject prefabWeapon;
    public bool check = true;

    //game over
    public GameObject GameOver;
    public int count = 1;

    void Start()
    {
        tr = GetComponent<Transform>();
        rigid = GetComponent<Rigidbody2D>();
        tr.position = new Vector2(-5.74f, -1.88f);
        GameOver.SetActive(false);
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

    //Life
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (count == 1)
        {
            Destroy(collision.gameObject);
            Destroy(GameObject.Find("Life3"));
            count += 1;
        }
        else if (count == 2)
        {
            Destroy(collision.gameObject);
            Destroy(GameObject.Find("Life2"));
            count += 1;
        }
        else if (count == 3)
        {
            Destroy(collision.gameObject);
            Destroy(GameObject.Find("Life1"));
            count += 1;
        }
        else if (count == 4)
        {
            GameOver.SetActive(true);
            Application.Quit();
        }
    }
}
