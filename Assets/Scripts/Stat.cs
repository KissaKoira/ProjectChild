﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stat {
    public int level { get; private set; }

    public const int STARTING_STAT = 0, MAX_BASE_STAT_VALUES = 15;

    // Name of the stat
    [System.NonSerialized]
    public string name;

    // Current value of the stat which gets affected by the level
    [System.NonSerialized]
    private float CurrentValue;
    public float currentValue { get { return CurrentValue; } }

    // Used for calculating current value of the stat
    [System.NonSerialized]
    private float minValue, maxValue, valuePerLevel;

    public Stat(string name, int level, float minValue, float maxValue) {
        this.name = name;
        this.minValue = minValue;
        this.maxValue = maxValue;
        this.valuePerLevel = (maxValue - minValue) / MAX_BASE_STAT_VALUES;
        SetLevel(level);
    }

    /// <summary>
    /// Loads necessary values from the serialized stat.
    /// </summary>
    /// <param name="loadFrom">Loaded stat</param>
    public void LoadStat(Stat loadFrom) {
        this.level = loadFrom.level;
    }

    /// <summary>
    /// Sets current level and calculates currentValue based on level.
    /// </summary>
    /// <param name="level">Level to set</param>
    private void SetLevel(int level) {
        this.level = level;
        this.CurrentValue = minValue + (valuePerLevel * this.level);
    }

    /// <summary>
    /// Increases level of the stat if it is not full.
    /// </summary>
    /// <returns>True if level was not full before increasing</returns>
    public bool IncreaseLevel() {
        if (this.level == MAX_BASE_STAT_VALUES) {
            return false;
        }

        SetLevel(this.level + 1);
        return true;
    }
}
