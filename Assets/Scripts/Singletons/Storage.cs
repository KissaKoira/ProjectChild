﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storage : MonoBehaviour {
    // Make class static and destroy if script already exists
    private static Storage _instance; // **<- reference link to the class
    public static Storage Instance { get { return _instance; } }

    private void Awake() {
        if (_instance == null) {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    private const int MAX_STORAGE_SLOTS = 6;
    private const int STORAGE_SLOT_UNLOCK_LEVEL_RATE = 5;
    private int unlockedStorageSlotsAmount = 1;
    private List<SerializablePickableSO> storageContent = new List<SerializablePickableSO>();

    void Start() {
        // Add empty storage content slots
        for (int i = 0; i < unlockedStorageSlotsAmount; i++)
            storageContent.Add(new SerializablePickableSO());
    }

    public bool CheckIfEmptyStorageSlots() {
        // If there are empty values, there is an empty slot
        for (int i = 0; i < storageContent.Count; i++) {
            SerializablePickableSO serialized = storageContent[i];
            if (serialized.itemType == SerializablePickableSO.EMPTY)
                return true;
        }

        return false;
    }

    public void AddToStorage(PickableSO item) {
        for (int i = 0; i < storageContent.Count; i++) {
            SerializablePickableSO serialized = storageContent[i];

            // If this is the empty slot, add the item here
            if (serialized.itemType == SerializablePickableSO.EMPTY) {
                SerializablePickableSO ser = new SerializablePickableSO(item);
                storageContent[i] = ser;

                break;
            }
        }
    }

    public void CheckStorageUnlock(int level) {
        // + 1 to check what the next unlock level using the rate is
        int nextUnlockLevel = (unlockedStorageSlotsAmount + 1) * STORAGE_SLOT_UNLOCK_LEVEL_RATE;

        if (level >= nextUnlockLevel) {
            // Add new slot to the storages and an empty value
            unlockedStorageSlotsAmount++;
            storageContent.Add(null);
        }
    }

    public void SaveStorage(Save save) {
        save.unlockedStorageSlotsAmount = unlockedStorageSlotsAmount;
        save.storageContent = storageContent;
    }

    public void LoadStorage(Save save) {
        unlockedStorageSlotsAmount = save.unlockedStorageSlotsAmount;
        storageContent = save.storageContent;
    }
}