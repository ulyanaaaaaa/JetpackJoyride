using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _failWindow;
    [SerializeField] private DurationCount _durationCount;

    public void Fail()
    {
        _failWindow.SetActive(true);
        _durationCount.Fail();
    }

    public void Restart()
    {
        _failWindow.SetActive(false);
        _durationCount.Continue();
    }
}
