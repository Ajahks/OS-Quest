using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Item.cs
 * 
 * This abstract class represents every item in the system!
 * Use subclasses for different types of items.
 * */
[System.Serializable]
[CreateAssetMenu(menuName = "Items/Cosmetic", fileName = "Cosmetic.asset")]
public class Cosmetic : Item
{
    public enum CosmeticType {
        Head, Torso, Aarm
    }

    public CosmeticType cosmeticType = CosmeticType.Torso;
}
