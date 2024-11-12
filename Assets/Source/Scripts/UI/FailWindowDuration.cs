using TMPro;
using UnityEngine;

public class FailWindowDuration : MonoBehaviour
{
    private TextMeshProUGUI _text;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    public void SetDuration(float duration)
    {
        _text.text = $"Your duration: {duration:0000}м";
    }
}
