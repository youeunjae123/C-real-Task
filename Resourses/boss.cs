using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss : MonoBehaviour
{

    public GameObject Boss;
    public Player plr;
    public int hp = 50;
    public float moveSpeed = 2.0f;
    public float coolTime;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;


    float curTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        plr = GameObject.Find("Player").GetComponent<Player>(); //플레이어의 컴포넌트 참조
    }

    // Update is called once per frame
    void Update()
    {
        curTime -= Time.deltaTime;
        Move();

        

    }

    void Move()
    {
        Vector3 moveVector = (plr.transform.position - transform.position).normalized * moveSpeed;
        transform.position += moveVector * Time.deltaTime; // 플레이어를 따라가는 코드
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject == plr.gameObject && curTime <= 0)
        {
            curTime = coolTime;
            plr.PGetDamage(3); // 플레이어 에게 부딪쳤을때
            
        }

    }

    public void GetDamage()
    {
        hp -= 1;
        if (hp <= 0)
        {
            plr.score+=5;
            Destroy(gameObject); // 일반 bullet을 맞았을때
        }
    }


    public void Getsuperdamage()
    {
        hp -= 5;
        if (hp <= 0)
        {
            plr.score+=5;
            Destroy(gameObject); // specialbullet을 맞았을때 
        }
    }

    public void rebossSpwan()
    {
        
            float randomX = Random.Range(minX, maxX); 
            float randomY = Random.Range(minY, maxY);
            Vector3 spawnPosition = new Vector3(randomX, randomY, 0f);
            GameObject newboss = Instantiate(Boss, spawnPosition, Quaternion.identity); //보스를 맵안에 랜덤으로 생성

            
        

    }
}
