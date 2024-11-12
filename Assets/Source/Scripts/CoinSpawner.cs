using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    private CoinPooler _coinPooler;
    [SerializeField] private float _timeDelay;
    [SerializeField] private float _yRange;
    [SerializeField] private int _coinCount;
    [SerializeField] private float _coinDelay;
    private Coroutine _spawnTick;

    private void Awake()
    {
        _coinPooler = GetComponent<CoinPooler>();
    }

    private void Start()
    {
        _spawnTick = StartCoroutine(SpawnTick());
    }

    private IEnumerator SpawnTick()
    {
        while (true)
        {
            float newPos = Random.Range(-_yRange, _yRange);
          
            for (int i = 0; i < _coinCount; i++)
            {
                yield return new WaitForSeconds(_coinDelay);   
                SpawnCoin(newPos);
                i++;
            }

            yield return new WaitForSeconds(_timeDelay);   
        }
    }

    private void SpawnCoin(float yPos)
    {
        Vector3 spawnPosition = new Vector3(transform.position.x, yPos, 0); 
        Coin coin = _coinPooler.GetCoin(); 
        coin.transform.position = spawnPosition; 
        coin.gameObject.SetActive(true);
        
    }
}
