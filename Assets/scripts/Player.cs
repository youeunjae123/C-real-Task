using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour
{

    
    public Item mainHand;

    public Item offHand;
    private void Start()
    {
        new Sworditem()
        {
            damage = 10,
        }.EquipItem(this, false);


        IUseableItem useable = (IUseableItem)mainHand;
        if(useable != null )
        {
            useable.UseItem(this);
        }


        new Fooditem()
        {
            nutrition = 5,
        }.EquipItem(this, true);


        

    }
}



