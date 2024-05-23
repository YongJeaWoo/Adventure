using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemList", menuName = "Item/ItemList")]
public class ItemList : ScriptableObject
{
    [SerializeField] protected List<Item> itemsList;
    public List<Item> ItemsList { get => itemsList; set => itemsList = value; }
}
