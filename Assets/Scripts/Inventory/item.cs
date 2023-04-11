using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="ItemData",menuName ="Items/InventoryItemCanEat")]
public class item : ScriptableObject
{
    public string Name = "Item";
    public Sprite Sprite;
    public bool CanEat = true;
    public int HungryIfEat;
    public int StressIfEat;
    public int FatigueIfEat;
    public int HpIfEat;

}
