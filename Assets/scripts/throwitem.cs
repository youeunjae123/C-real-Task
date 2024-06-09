using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class throwitem : Item, IUseableItem
{
    

    public void Throw(Player user)
    {
        Debug.Log("대충 오브젝트를 던짐");
    }

    public void UseItem(Player user)
    {
        Throw(user);
    }


    public override void EquipItem(Player user, bool offhand = true)
    {
        base.EquipItem(user, offhand);

        Debug.Log("오브젝트를 던질수 있음");
    }
}
