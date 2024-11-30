using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int hp; // 체력
    public float moveSpeed; //스피드
    public GameObject bullet; // 총알 프리펩
    public Transform shotPoint; // 총구 위치
    public float shootingCooltime=1; // 사격속도
    bool allowShooting = true; // 총알 사격 허용 여부
    public int score = 0;
    public GameObject specialbullet;
    public int count = 0;
    bool allowspecialshooting = true;
    public boss boss;
    public int mobcount=0;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Rotate();
        Shoot();
        specialshoot();
        bossspawn();

    }

    void Move()
    {

        float hor = Input.GetAxisRaw("Horizontal");
        float ver = Input.GetAxisRaw("Vertical");


        Vector3 moveVector = new Vector2(hor, ver).normalized;
        transform.position += moveVector * Time.deltaTime * moveSpeed;
    }

    void Rotate()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float dx = mousePosition.x - transform.position.x;
        float dy = mousePosition.y - transform.position.y;

        float angle = Mathf.Atan2(dy, dx)* Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
   
    public void PGetDamage(int dmg) // enemy에 맞았을때 데미지를 입음
    {
        hp -= dmg;

        if(hp <= 0)
        {
            Time.timeScale = 0;
            Debug.Log(score); // 게임에서 죽은 후 잡은 enemy의 수의 따른 점수를 Debug에 출력
            Destroy(gameObject);
        }
    }

    void Shoot()
    {
        if (allowShooting && Input.GetMouseButton(0) && count != 10)  // 총알 발사 코드
        {
            
            GameObject newBullet = Instantiate(bullet, shotPoint.position, transform.rotation * Quaternion.Euler(0,0,-90));
            newBullet.GetComponent<Rigidbody2D>().AddForce(newBullet.transform.up * 200);
            count++;
            allowShooting = false;
            Invoke("EnableShooting", shootingCooltime);



        }
        


    }
    void specialshoot() // 10발의 bullet을 쐈을때 specialbullet 발사 코드
    {
        if (count == 10)
        {
            GameObject newspecialbullet = Instantiate(specialbullet, shotPoint.position, transform.rotation * Quaternion.Euler(0, 0, -90));
            newspecialbullet.GetComponent<Rigidbody2D>().AddForce(newspecialbullet.transform.up * 200);
            count = 0;
            
            
        }
        
    }



    void EnableShooting()
    {
        allowShooting=true;
    }


    void bossspawn() // 적 30마리를 잡을때마다 보스 소환
    {
        if (mobcount== 30)
        {
            boss.rebossSpwan();
            mobcount=0;
        }
    }
}
