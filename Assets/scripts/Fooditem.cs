using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fooditem : Item, IUseableItem
{
    public float nutrition;

    public void Eat(Player user)
    {
        Debug.Log("대충 음식을 먹음");
    }

    public  void UseItem(Player user)
    {
        Eat(user);
    }

    public override void EquipItem(Player user, bool offhand = true)
    {
        base.EquipItem(user, offhand);

        Debug.Log("그리고 먹기 기능이 추가됨");
    }

}
