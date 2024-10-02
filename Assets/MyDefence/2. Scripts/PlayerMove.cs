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
        
        //�÷��̾��� ��ġ�� ������ ��� �̵�
        //transform.position += Vector3.right;
    }

    private void FixedUpdate()
    {
        //Move();

        //�ӵ� - �� �������� 1�ʿ� 1unit ��ŭ �̵�
        //transform.position += moveDirection * Time.fixedDeltaTime;

        //�ӵ� - �� �������� 1�ʿ� 5unit ��ŭ �̵�
        //transform.position += moveDirection * speed * Time.fixedDeltaTime;

        moveDirection = (target.transform.position - transform.position).normalized;

        //transform �̵� �Լ�
        //direction(����) : �̵��� ����
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