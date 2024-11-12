using System;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public Action<int> OnHealthChanged;
    public Action<int> OnCoinsChanged;
    public Action<int> OnAllCoinsChanged;
    [SerializeField] private TextMeshProUGUI _healthCount;
    [SerializeField] private TextMeshProUGUI _coinsCount;
    [SerializeField] private TextMeshProUGUI _allCoinsCount;

    private void OnEnable()
    {
        OnCoinsChanged += CoinsCount;
        OnHealthChanged += HealthCount;
        OnAllCoinsChanged += AllCoinsCount;
    }
    
    private void OnDisable()
    {
        OnCoinsChanged -= CoinsCount;
        OnHealthChanged -= HealthCount;
        OnAllCoinsChanged -= AllCoinsCount;
    }

    private void HealthCount(int count)
    {
        if (count == 3)
        {
            _healthCount.text = $"<sprite=2><sprite=2><sprite=2>";
        }
        else if (count == 2)
        {
            _healthCount.text = $"<sprite=2><sprite=2><sprite=0>";
        }
        else if (count == 1)
        {
            _healthCount.text = $"<sprite=2><sprite=0><sprite=0>";
        }
        else if (count == 0)
        {
            _healthCount.text = $"<sprite=0><sprite=0><sprite=0>";
        }
    }

    private void CoinsCount(int count)
    {
        _coinsCount.text = $"<sprite=0> {count}";
    }
    
    private void AllCoinsCount(int count)
    {
        _allCoinsCount.text = $"<sprite=0> {count}";
    }
}
