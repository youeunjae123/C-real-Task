using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shielditem : Item, IUseableItem
{
    

    public void Shield(Player user)
    {
        Debug.Log("대충 방패로 공격을 막음");
    }

    public void UseItem(Player user)
    {
        Shield(user); // 대충 우클릭하면 공격을 막음
    }


    public override void EquipItem(Player user, bool offhand = true)
    {
        base.EquipItem(user, offhand);

        Debug.Log("방패로 막을수 있게됨");
    }
}
