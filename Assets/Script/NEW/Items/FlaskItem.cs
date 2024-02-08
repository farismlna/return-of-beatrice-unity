using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SG
{
    [CreateAssetMenu(menuName = "Items/Consumable/Flask")]
    public class FlaskItem : ConsumableItem
    {
        [Header("Flask Type")]
        public bool estusFlask;
        public bool ashenFlask;

        [Header("Recovery Amount")]
        public int healthRecoverAmount;
        public int focusPointRecoverAmount;

        [Header("Recovery FX")]
        public GameObject recoveryFX;

        public override void AttempToConsumeItem(AnimatorManager animatorManager, WeaponSlotManager weaponSlotManager, PlayerEffectManager playerEffectManager)
        {
            base.AttempToConsumeItem(animatorManager, weaponSlotManager, playerEffectManager);
            GameObject flask = Instantiate(itemModel, weaponSlotManager.rightHandSlot.transform);
            playerEffectManager.currentParticleFX = recoveryFX;
            playerEffectManager.amountToBeHealed = healthRecoverAmount;
            playerEffectManager.instantiatedFXModel = flask;
            weaponSlotManager.rightHandSlot.UnloadWeapon();
        }
    }
}