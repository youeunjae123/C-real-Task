using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blockitem : Item , IUseableItem
{
    public void PlaceBlock(Player user, Vector2 pos)
    {
        Debug.Log("대충 블럭이 설치됨");
    }


    public  void UseItem(Player user)
    {
        PlaceBlock(user,transform.position);
    }


    public override void EquipItem(Player user, bool offhand = true)
    {
        base.EquipItem(user, offhand);

        Debug.Log("그리고 설치 기능이 추가됨");
    }
}
