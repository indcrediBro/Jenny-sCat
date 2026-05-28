using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private InputActionReference inputAction;

    private void Update()
    {
        if (inputAction.action.triggered)
        {
            CollectValidCats();
        }
    }

    private void CollectValidCats()
    {
        Debug.Log("Collecting valid cats");
        EventBus.Publish(GameEvents.BUTTON_PRESSED);
    }
}