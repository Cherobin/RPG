using UnityEngine;

namespace RPG
{
    [CreateAssetMenu(menuName = "Item/New Item", fileName = "New Item")]
    public class Item : ScriptableObject
    {
        public int id;
        public string itemName;
        public ItemType itemType;
        public int damageValue;
        public int defenseValue;
    }

}