﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(EnemySO)), CanEditMultipleObjects]
public class EnemySOEditor : Editor {

    public SerializedProperty
        nameProp,
        // Stats
        shieldRecovery, staminaRecovery, ammoRecovery, dodgeRate, criticalRate,
        piercingDmg, kineticDmg, energyDmg, piercingRes, kineticRes, energyRes,
        attackSpd, movementSpd, fireRate;

    void OnEnable() {
        // Setup the SerializedProperties
        nameProp = serializedObject.FindProperty("name");
        // Stats
        shieldRecovery = serializedObject.FindProperty("shieldRecovery");
        staminaRecovery = serializedObject.FindProperty("staminaRecovery");
        ammoRecovery = serializedObject.FindProperty("ammoRecovery");

        dodgeRate = serializedObject.FindProperty("dodgeRate");
        criticalRate = serializedObject.FindProperty("criticalRate");

        piercingDmg = serializedObject.FindProperty("piercingDmg");
        kineticDmg = serializedObject.FindProperty("kineticDmg");
        energyDmg = serializedObject.FindProperty("energyDmg");

        piercingRes = serializedObject.FindProperty("piercingRes");
        kineticRes = serializedObject.FindProperty("kineticRes");
        energyRes = serializedObject.FindProperty("energyRes");

        attackSpd = serializedObject.FindProperty("attackSpd");
        movementSpd = serializedObject.FindProperty("movementSpd");
        fireRate = serializedObject.FindProperty("fireRate");
    }

    public override void OnInspectorGUI() {
        serializedObject.Update();

        EditorGUILayout.PropertyField(nameProp);
        EditorGUILayout.LabelField($"Recovery speed: {Stat.RECOVERY_MIN_SPEED} - {Stat.RECOVERY_MAX_SPEED}", EditorStyles.boldLabel);
        EditorGUILayout.PropertyField(shieldRecovery);
        EditorGUILayout.PropertyField(staminaRecovery);
        EditorGUILayout.PropertyField(ammoRecovery);
        EditorGUILayout.Space();
        EditorGUILayout.LabelField($"Dodge rate: {Stat.DODGE_MIN_PERCENT}% - {Stat.DODGE_MAX_PERCENT}%", EditorStyles.boldLabel);
        EditorGUILayout.PropertyField(dodgeRate);
        EditorGUILayout.Space();
        EditorGUILayout.LabelField($"Critical hit rate: {Stat.CRITICAL_MIN_PERCENT}% - {Stat.CRITICAL_MAX_PERCENT}%", EditorStyles.boldLabel);
        EditorGUILayout.PropertyField(criticalRate);
        EditorGUILayout.Space();
        EditorGUILayout.LabelField($"Damage boost: {Stat.DAMAGE_MIN_PERCENT}% - {Stat.DAMAGE_MAX_PERCENT}%", EditorStyles.boldLabel);
        EditorGUILayout.PropertyField(piercingDmg);
        EditorGUILayout.PropertyField(kineticDmg);
        EditorGUILayout.PropertyField(energyDmg);
        EditorGUILayout.Space();
        EditorGUILayout.LabelField($"Resistance: {Stat.RESISTANCE_MIN_PERCENT}% - {Stat.RESISTANCE_MAX_PERCENT}%", EditorStyles.boldLabel);
        EditorGUILayout.PropertyField(piercingRes);
        EditorGUILayout.PropertyField(kineticRes);
        EditorGUILayout.PropertyField(energyRes);
        EditorGUILayout.Space();
        EditorGUILayout.LabelField($"Movements speed boost: {Stat.MOVEMENT_MIN_SPEED} - {Stat.MOVEMENT_MAX_SPEED}", EditorStyles.boldLabel);
        EditorGUILayout.PropertyField(movementSpd);
        EditorGUILayout.Space();
        EditorGUILayout.LabelField($"Attack speed: {Stat.ATTACK_MIN_SPEED} - {Stat.ATTACK_MAX_SPEED}", EditorStyles.boldLabel);
        EditorGUILayout.PropertyField(attackSpd);
        EditorGUILayout.Space();
        EditorGUILayout.LabelField($"Fire rate speed: {Stat.FIRE_RATE_MIN_SPEED} - {Stat.FIRE_RATE_MAX_SPEED}", EditorStyles.boldLabel);
        EditorGUILayout.PropertyField(fireRate);

        serializedObject.ApplyModifiedProperties();
    }
}
