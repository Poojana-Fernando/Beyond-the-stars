using UnityEngine;

public class moon : MonoBehaviour
{
    [SerializeField] private int value = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Make sure your player GameObject has tag "Player"
        if (!other.CompareTag("Player")) return;

        if (CollectUImoon.Instance != null)
            CollectUImoon.Instance.Add(value);

        Destroy(gameObject);
    }
}