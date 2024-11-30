using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Player plr;
    public boss boss;
    
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Enemy enemy = collider.GetComponent<Enemy>(); // enemy에 부딪쳤을때 코드
        if(enemy)
        {
            enemy.GetDamage();
            Destroy(gameObject);
        }
    }
    void OnTriggerStay2D(Collider2D collider)
    {
        boss boss = collider.GetComponent<boss>(); // boss에 부딪쳤을때 코드
        if(boss)
        {
            boss.GetDamage();
            Destroy(gameObject) ;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
