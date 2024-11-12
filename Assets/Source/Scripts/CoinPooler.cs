using System.Collections.Generic;
using UnityEngine;

public class CoinPooler : MonoBehaviour
{
    [SerializeField] private Coin _coinPrefab; 
    [SerializeField] private int _poolSize = 10; 
    [field: SerializeField]private List<Coin> coinPool = new List<Coin>();

    private void Start()
    {
        for (int i = 0; i < _poolSize; i++)
        {
            Coin coin = Instantiate(_coinPrefab);
            coin.gameObject.SetActive(false); 
            coinPool.Add(coin);
        }
    }

    public Coin GetCoin()
    {
        foreach (Coin coin in coinPool)
        {
            if (!coin.gameObject.activeInHierarchy)
            {
                return coin;
            }
        }
        
        Coin newCoin = Instantiate(_coinPrefab);
        newCoin.gameObject.SetActive(false);
        coinPool.Add(newCoin);
        return newCoin;
    }
}
