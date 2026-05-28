using System;
using System.Collections.Generic;
using UnityEngine;

public class CatCollector: MonoBehaviour
{
    private List<Cat> allSpawnedCats;

    private void Start()
    {
        allSpawnedCats = new List<Cat>();
    }

    private void OnEnable()
    {
        EventBus.Subscribe(GameEvents.BUTTON_PRESSED, CollectValidCats);
        EventBus.Subscribe(GameEvents.CAT_SPAWNED, AddCat);
    }

    private void OnDisable()
    {
        EventBus.Unsubscribe(GameEvents.BUTTON_PRESSED, CollectValidCats);
    }

    private void CollectValidCats()
    {
        for (int i = allSpawnedCats.Count - 1; i >= 0; i--)
        {
            Cat cat = allSpawnedCats[i];

            if (cat.Collectible && !cat.Collected)
            {
                cat.CatCollected();
                allSpawnedCats.RemoveAt(i);
            }
        }
    }

    private void AddCat(object cat)
    {
        allSpawnedCats.Add(cat as Cat);
    }
}