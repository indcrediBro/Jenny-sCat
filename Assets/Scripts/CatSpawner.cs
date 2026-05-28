using UnityEngine;

public class CatSpawner : MonoBehaviour
{
    [SerializeField] private Cat prefab;
    [SerializeField] private float spawnInterval = 1f;
    [SerializeField] private bool moveRight = true;

    private float timer;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            timer = 0f;
            Spawn();
        }
    }

    private void Spawn()
    {
        Cat spawned = Instantiate(prefab, transform.position, Quaternion.identity);
        Vector3 direction = moveRight ? Vector3.right : Vector3.left;
        EventBus.Publish(GameEvents.CAT_SPAWNED, spawned);
        spawned.Initialize(direction);
    }
}
