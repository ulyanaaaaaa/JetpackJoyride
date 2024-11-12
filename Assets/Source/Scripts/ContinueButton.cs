using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ContinueButton : MonoBehaviour
{
    [SerializeField] private DurationCount _durationCount;
    private PlayerHealth _player;
    private TextMeshProUGUI _text;
    private int _coinsForReset;

    private void Awake()
    {
        _player = FindObjectOfType<PlayerHealth>();
        _text = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        GetComponent<Image>().color = Color.green;
        _coinsForReset = _player.GetComponent<PlayerWallet>().Coins / 3;
        _text.text = $"continue for <sprite=0> {_coinsForReset}";

        StartPulsating();  
    }

    public void ClickReset()
    {
        if (_player.GetComponent<PlayerWallet>().TryBuy(_coinsForReset))
        {
            _player.OnReset?.Invoke();
            _durationCount.Continue();
        }
        else
        {
            GetComponent<Image>().color = Color.red;
            transform.DOKill();
        }
    }

    private void StartPulsating()
    {
        transform.DOScale(Vector3.one * 1.1f, 0.5f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutQuad);
    }
}

