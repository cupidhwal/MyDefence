using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMove : MonoBehaviour
{
    private float speed;

    private Vector3 moveDirection;
    private GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        speed = 5.0f;

        target = GameObject.FindGameObjectWithTag("Finish");
    }

    // Update is called once per frame
    void Update()
    {
        //Handle();
        
        //플레이어의 위치를 앞으로 계속 이동
        //transform.position += Vector3.right;
    }

    private void FixedUpdate()
    {
        //Move();

        //속도 - 앞 방향으로 1초에 1unit 만큼 이동
        //transform.position += moveDirection * Time.fixedDeltaTime;

        //속도 - 앞 방향으로 1초에 5unit 만큼 이동
        //transform.position += moveDirection * speed * Time.fixedDeltaTime;

        moveDirection = (target.transform.position - transform.position).normalized;

        //transform 이동 함수
        //direction(방향) : 이동할 방향
        transform.Translate(moveDirection * Time.fixedDeltaTime * speed);
    }

    /*void Handle()
    {
        moveVertical = Input.GetAxisRaw("Vertical");
        moveHorizontal = Input.GetAxisRaw("Horizontal");

        moveDirection = new Vector3(moveHorizontal, 0, moveVertical);
    }*//*

    void Move()
    {
        transform.position = target.transform.position;
    }*/
}

/*
Time.deltaTime
 */