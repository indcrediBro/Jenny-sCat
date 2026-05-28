using System;
using UnityEngine;

public class Cat: MonoBehaviour
{
    private bool collectible = true;
    public bool Collectible => collectible;

    private bool collected;
    public bool Collected => collected;

    [SerializeField] private int pointsOnCollect;
    [SerializeField] private float uncollectedSpeed = 30f;
    [SerializeField] private float collectedSpeed = 30f;
    [SerializeField] private float floatAmplitude = 0.5f;
    [SerializeField] private float floatFrequency = 2f;
    [SerializeField] private Vector3 moveDirection;

    private Vector3 startPosition;
    private float randomOffset;

    public void Initialize(Vector3 direction)
    {
        moveDirection = direction.normalized;
    }

    private void Update()
    {
        if (collected)
        {
            MoveColleced();
        }
        else
        {
            MoveUncollected();
        }
    }

    private void MoveColleced()
    {
        transform.position =
            Vector3.MoveTowards(transform.position, Vector3.up * -4.5f, collectedSpeed * Time.deltaTime);
    }

    private void MoveUncollected()
    {
        transform.position += moveDirection * uncollectedSpeed * Time.deltaTime;

        float yOffset = Mathf.Sin((Time.time + randomOffset) * floatFrequency) * floatAmplitude;

        Vector3 pos = transform.position;
        pos.y = startPosition.y + yOffset;
        transform.position = pos;

        startPosition += moveDirection * uncollectedSpeed * Time.deltaTime;
    }

    public void CatCollected()
    {
        collectible = false;
        collected = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            CatCollected();
            EventBus.Publish(GameEvents.CAT_COLLECTED, pointsOnCollect);
        }
    }
}