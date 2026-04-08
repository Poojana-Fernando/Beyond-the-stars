using UnityEngine;

public class BarrierDestroy : MonoBehaviour
{
    public GameObject particleEffect;
    public LineRenderer line;
    public EdgeCollider2D edge;

    public void BreakBarrier()
    {
        StartCoroutine(BreakEffect());
    }

    System.Collections.IEnumerator BreakEffect()
    {
        // Spawn particles along the line
        for (int i = 0; i < line.positionCount; i++)
        {
            Instantiate(particleEffect, line.GetPosition(i), Quaternion.identity);
        }

        // Fade out line
        float duration = 1f;
        float t = 0;

        Color startColor = line.startColor;

        while (t < duration)
        {
            t += Time.deltaTime;
            float alpha = Mathf.Lerp(1, 0, t / duration);

            Color c = startColor;
            c.a = alpha;

            line.startColor = c;
            line.endColor = c;

            yield return null;
        }

        // Disable collider + line
        edge.enabled = false;
        line.enabled = false;
    }
}