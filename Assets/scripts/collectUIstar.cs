using TMPro;
using UnityEngine;

public class CollectUIstar : MonoBehaviour
{
    public static CollectUIstar Instance;

    [SerializeField] private TMP_Text collectText;
    private int count = 0;

    private void Awake()
    {
        Instance = this;
        UpdateText();
    }

    public void Add(int amount)
    {
        count += amount;
        UpdateText();
    }

    private void UpdateText()
    {
        if (collectText != null)
            collectText.text = "" + count;
    }
}