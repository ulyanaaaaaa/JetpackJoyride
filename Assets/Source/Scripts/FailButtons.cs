using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailButtons : MonoBehaviour
{
    private PlayerHealth _player;

    private void Awake()
    {
        _player = FindObjectOfType<PlayerHealth>();
    }
    
    public void Click()
    {
        _player.OnDie?.Invoke();
    }
}
