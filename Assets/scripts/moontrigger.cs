using UnityEngine;

public class MoonTrigger : MonoBehaviour
{
    public BarrierDestroy barrier;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            barrier.BreakBarrier();
        }
    }
}