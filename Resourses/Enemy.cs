using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{


    public Player plr;
    public int hp=1;
    public float moveSpeed=3.7f;
    public float coolTime;

    float curTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        plr = GameObject.Find("Player").GetComponent<Player>(); // �÷��̾��� ������Ʈ ����
    }

    // Update is called once per frame
    void Update()
    {
        curTime -= Time.deltaTime;
        Move();
    }

    void Move()
    {
        Vector3 moveVector = (plr.transform.position - transform.position).normalized * moveSpeed; // �÷��̾ ���󰡴� �ڵ�
        transform.position += moveVector * Time.deltaTime;
    }

    void OnCollisionStay2D(Collision2D collision) // �÷��̾�� �ε������� �÷��̾�� �������� �ְ� �ڵ� �Ҹ�
    {
        if(collision.gameObject == plr.gameObject && curTime <=0)
        {
            curTime = coolTime;
            plr.PGetDamage(1);
            Destroy(gameObject);
        }

    }

    public void GetDamage() // bullet�� �¾����� �������� ����
    {
        hp -= 1;
        if(hp <= 0)
        {
            plr.score+=5;
            Destroy(gameObject);
            plr.mobcount++;
        }
    }


    public void Getsuperdamage() // specialbullet���� �¾����� �������� ����
    {
        hp -= 10;
        if(hp <=0)
        {
            plr.score +=5;
            Destroy(gameObject);
            plr.mobcount++;
        }
    }
}
