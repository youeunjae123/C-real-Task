using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class specialbullet : MonoBehaviour
{
    public Player plr;
    public Enemy enemy;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 3); // 3���� �ڵ� �Ҹ�
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Enemy enemy = collider.GetComponent<Enemy>(); // enemy���� �ε������� �ڵ�
        if (enemy)
        {
            enemy.Getsuperdamage(); 
            
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
