using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public Action OnReset;
    public Action OnDie;
    [SerializeField] private int _health;
    [SerializeField] private int _maxHealth;
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private UIManager _uiManager;

    private void OnEnable()
    {
        OnReset += Restart;
        OnDie += Die;
    }
    
    private void OnDisable()
    {
        OnReset -= Restart;
        OnDie -= Die;
    }

    private void Start()
    {
        _health = _maxHealth;
        _uiManager.OnHealthChanged?.Invoke(_health);
    }
    
    public void TakeDamage(int damage)
    {
        _health -= damage;
        _uiManager.OnHealthChanged?.Invoke(_health);
        
        if (_health == 0)
            Fail();
    }

    private void Fail()
    {
        _gameManager.Fail();
    }

    private void Restart()
    {
        _health = _maxHealth;
        _uiManager.OnHealthChanged?.Invoke(_health);
        _gameManager.Restart();
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}
