using DG.Tweening;
using UnityEngine;

public class PlayButton : MonoBehaviour
{
    private void Start()
    {
        StartPulsating();
    }
    
    private void StartPulsating()
    {
        transform.DOScale(Vector3.one * 1.1f, 0.5f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutQuad);
    }
}
