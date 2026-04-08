using UnityEngine;

public class star : MonoBehaviour
{
    [SerializeField] private int value = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Make sure your player GameObject has tag "Player"
        if (!other.CompareTag("Player")) return;

        if (CollectUIstar.Instance != null)
            CollectUIstar.Instance.Add(value);

        Destroy(gameObject);
    }
}