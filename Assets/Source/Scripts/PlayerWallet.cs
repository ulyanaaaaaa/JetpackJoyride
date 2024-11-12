using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class PlayerWallet : MonoBehaviour
{
    [field: SerializeField] private List<Coin> _coins = new List<Coin>();
    [field: SerializeField] private List<Coin> _allCoins = new List<Coin>();
    [SerializeField] private UIManager _uiManager;
    
    private string _filePath;

    private void Awake()
    {
        _filePath = Path.Combine(Application.persistentDataPath, "coinData.json"); 
        LoadCoins();
    }

    private void OnEnable()
    {
        _coins.Clear();
        _uiManager.OnCoinsChanged?.Invoke(_coins.Count);
    }

    public bool TryBuy(int price)
    {
        if (_allCoins.Count >= price)
        {
            _allCoins.RemoveRange(0, price); 
            SaveCoins(); 
            _uiManager.OnAllCoinsChanged?.Invoke(_allCoins.Count); 
            return true;
        }
        else
        {
            return false;
        } 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Coin coin))
        {
            _coins.Add(coin); 
            _allCoins.Add(coin);
            SaveCoins();
            _uiManager.OnAllCoinsChanged?.Invoke(_allCoins.Count);
            _uiManager.OnCoinsChanged?.Invoke(_coins.Count); 
            coin.Die();
        }
    }

    private void SaveCoins()
    {
        CoinData coinData = new CoinData();
        coinData.AllCoins = _allCoins;
        string json = JsonUtility.ToJson(coinData); 
        File.WriteAllText(_filePath, json);
    }
    
    private void LoadCoins() {
        if (File.Exists(_filePath))
        {
            string json = File.ReadAllText(_filePath);
            CoinData coinData = JsonUtility.FromJson<CoinData>(json); 
            _allCoins = coinData.AllCoins; 
            _uiManager.OnAllCoinsChanged?.Invoke(_allCoins.Count); 
        } 
    }

    public int Coins => _coins.Count;
}

[Serializable]
public class CoinData
{
    public List<Coin> AllCoins = new List<Coin>();
}
