﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : CharacterParent {

    private PlayerStats stats;

    private Stat[] recoveryStats;

    // Testing purposes
    public float testDamageKeyU = 20;
    public int testXpKeyX = 20;

    // Checking trigger presses to avoid "input not always registering"
    private Collider triggerCollider;

    public override void Start() {
        characterType = CharacterType.Player;
        stats = PlayerStats.Instance;
        stats.player = this;    // Add this player to singleton variable for better access

        RefreshStats();

        base.Start();

        // Show player's hud
        hud.gameObject.SetActive(true);
    }

    public void RefreshStats() {
        shieldRecovery = stats.shieldRecovery.currentValue;
        staminaRecovery = stats.staminaRecovery.currentValue;
        ammoRecovery = stats.ammoRecovery.currentValue;

        dodgeRate = stats.dodgeRate.currentValue;
        criticalRate = stats.criticalRate.currentValue;
        rareItemFindRate = stats.rareItemFindRate.currentValue;

        piercingDmg = stats.piercingDmg.currentValue;
        kineticDmg = stats.kineticDmg.currentValue;
        energyDmg = stats.energyDmg.currentValue;

        piercingRes = stats.piercingRes.currentValue;
        kineticRes = stats.kineticRes.currentValue;
        energyRes = stats.energyRes.currentValue;

        attackSpd = stats.attackSpd.currentValue;
        movementSpd = stats.movementSpd.currentValue;
        fireRate = stats.fireRate.currentValue;

        // Some armor values are affected by stats
        RetrieveArmorValues();
    }

    protected override void Update() {
        base.Update();

        // Check trigger interact presses
        if (triggerCollider != null && Input.GetButtonDown("Interact")) {
            if (triggerCollider.CompareTag("Chest")) {
                triggerCollider.GetComponent<Chest>().OpenChest();
            }
        }

        // Test taking damage
        if (Input.GetKeyDown(KeyCode.U)) {
            TakeDamage(DamageType.Piercing, testDamageKeyU, 0);
        }
        
        // Test gaining xp
        if (Input.GetKeyDown(KeyCode.X)) {
            stats.GainXP(testXpKeyX);
        }


    }

    void OnDestroy() {
        if (hud != null)
            hud.gameObject.SetActive(false);    // Hide player's hud on destroy
    }

    /**************** Collisions ****************/

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Bullet")) {
            bulletController bullet = collision.gameObject.GetComponent<bulletController>();
            if (bullet.shooter == CharacterType.Enemy) {
                TakeDamage(bullet.damageType, bullet.damage, bullet.criticalRate);
            }
        }
    }

    void OnTriggerEnter(Collider collider) {
        triggerCollider = collider;

        if (collider.CompareTag("Chest")) {
            hud.ShowInteract(HUDCanvas.CHEST);
        }
    }

    void OnTriggerExit(Collider collider) {
        triggerCollider = null;

        if (collider.CompareTag("Chest")) {
            hud.HideInteract();
            CanvasMaster.Instance.chestCanvas.GetComponent<ChestCanvas>().CloseChest();
        }
    }
}
