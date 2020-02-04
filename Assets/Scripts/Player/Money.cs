using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName = "Items/Money", fileName = "Money.asset")]
public class Money : Item
{
    // The value of this currency, per item
    public int value = 10;
}
