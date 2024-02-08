using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SG
{
    public class ConsumableItem : Item
    {
        [Header("Item Quantity")]
        public int maxItemAmount;
        public int currentItemAmount;

        [Header("Item Model")]
        public GameObject itemModel;

        [Header("Animations")]
        public string consumableAnimation;
        public bool isInteracting;

        public virtual void AttempToConsumeItem(AnimatorManager animatorManager, WeaponSlotManager weaponSlotManager, PlayerEffectManager playerEffectManager)
        {
            if (currentItemAmount > 0)
            {
                animatorManager.PlayTargetAnimation(consumableAnimation, isInteracting);
            }
            else
            {
                animatorManager.PlayTargetAnimation("Shrug", true);
            }
        }
    }
}