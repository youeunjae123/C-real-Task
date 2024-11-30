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
        plr = GameObject.Find("Player").GetComponent<Player>(); // 플레이어의 컴포넌트 참조
    }

    // Update is called once per frame
    void Update()
    {
        curTime -= Time.deltaTime;
        Move();
    }

    void Move()
    {
        Vector3 moveVector = (plr.transform.position - transform.position).normalized * moveSpeed; // 플레이어를 따라가는 코드
        transform.position += moveVector * Time.deltaTime;
    }

    void OnCollisionStay2D(Collision2D collision) // 플레이어에게 부딪쳤을때 플레이어에게 데미지를 주고 자동 소멸
    {
        if(collision.gameObject == plr.gameObject && curTime <=0)
        {
            curTime = coolTime;
            plr.PGetDamage(1);
            Destroy(gameObject);
        }

    }

    public void GetDamage() // bullet에 맞았을때 데미지를 입음
    {
        hp -= 1;
        if(hp <= 0)
        {
            plr.score+=5;
            Destroy(gameObject);
            plr.mobcount++;
        }
    }


    public void Getsuperdamage() // specialbullet에게 맞았을때 데미지를 입음
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
