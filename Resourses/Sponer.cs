using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sponer : MonoBehaviour
{
    public GameObject Enemy;
    float time = 0;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime; // enemy���� ��Ÿ�� 
        spon();
    }

    void spon()
    {
        if (time >= 1.25)
        {
            float randomX = Random.Range(minX, maxX);
            float randomY = Random.Range(minY, maxY);
            Vector3 spawnPosition = new Vector3(randomX, randomY, 0f);
            GameObject newEnemy = Instantiate(Enemy, spawnPosition, Quaternion.identity); // 1.25�ʸ� ��Ÿ������ �ʾȿ� enemy�� ���� ��ȯ
            time = 0;
        }
    }
}

