using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sworditem : Item , IUseableItem
{
    public int damage;

    public void Attack(Player user, Transform enemy)
    {
        Debug.Log("대충 검으로 공격함");
    }

    public  void UseItem(Player user)
    {
        Attack(user, null);
    }


    public override void EquipItem(Player user, bool offhand = true)
    {
        base.EquipItem(user, offhand);

        Debug.Log("그리고 처단 기능이 추가됨");
    }
}
