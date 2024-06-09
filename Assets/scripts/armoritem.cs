using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class armoritem : Item, IUseableItem
{
    

    public void Armor(Player user)
    {
        Debug.Log("갑옷이 데미지를 줄임");
    }

    public void UseItem(Player user)
    {
        Armor(user); // 갑옷을 입음
    }


    public override void EquipItem(Player user, bool offhand = true)
    {
        base.EquipItem(user, offhand);

        Debug.Log("그리고 막기기능이 추가됨");
    }
}