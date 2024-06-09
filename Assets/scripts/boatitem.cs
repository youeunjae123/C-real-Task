using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boatitem : Item, IUseableItem
{
    

    public void Boat(Player user)
    {
        Debug.Log("대충 우클릭하면 대충 배에 탈수 있음");
    }

    public void UseItem(Player user)
    {
        Boat(user); // 배를 설치하고 탑승
    }


    public override void EquipItem(Player user, bool offhand = true)
    {
        base.EquipItem(user, offhand);

        Debug.Log("보트를 설치할수 있음");
    }
}
