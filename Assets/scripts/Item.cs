using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{


    public virtual void EquipItem(Player user, bool offhand = false)
    {
        if(offhand)
        {
            user.offHand = this;
        }
        else
        {
            user.mainHand = this;
        }

        Debug.Log("아이템을 장착함");  
    }
}
