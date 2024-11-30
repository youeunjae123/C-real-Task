using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int hp; // ü��
    public float moveSpeed; //���ǵ�
    public GameObject bullet; // �Ѿ� ������
    public Transform shotPoint; // �ѱ� ��ġ
    public float shootingCooltime=1; // ��ݼӵ�
    bool allowShooting = true; // �Ѿ� ��� ��� ����
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
   
    public void PGetDamage(int dmg) // enemy�� �¾����� �������� ����
    {
        hp -= dmg;

        if(hp <= 0)
        {
            Time.timeScale = 0;
            Debug.Log(score); // ���ӿ��� ���� �� ���� enemy�� ���� ���� ������ Debug�� ���
            Destroy(gameObject);
        }
    }

    void Shoot()
    {
        if (allowShooting && Input.GetMouseButton(0) && count != 10)  // �Ѿ� �߻� �ڵ�
        {
            
            GameObject newBullet = Instantiate(bullet, shotPoint.position, transform.rotation * Quaternion.Euler(0,0,-90));
            newBullet.GetComponent<Rigidbody2D>().AddForce(newBullet.transform.up * 200);
            count++;
            allowShooting = false;
            Invoke("EnableShooting", shootingCooltime);



        }
        


    }
    void specialshoot() // 10���� bullet�� ������ specialbullet �߻� �ڵ�
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


    void bossspawn() // �� 30������ ���������� ���� ��ȯ
    {
        if (mobcount== 30)
        {
            boss.rebossSpwan();
            mobcount=0;
        }
    }
}
