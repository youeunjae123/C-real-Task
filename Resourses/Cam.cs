using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    public Player player;
    public float smooth;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.Lerp(transform.position, player.transform.position, smooth); // ��ġ�� �÷��̾��� ��ġ���� õõ�� �̵�
    }
}
