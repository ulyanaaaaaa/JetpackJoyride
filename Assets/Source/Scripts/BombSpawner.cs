using System.Collections;
using UnityEngine;

public class BombSpawner : MonoBehaviour
{
    private BombPooler _bombPooler;
    [SerializeField] private float _timeDelay;
    [SerializeField] private float _yRange;
    private Coroutine _spawnTick;

    private void Start()
    {
        _bombPooler = GetComponent<BombPooler>();
        _spawnTick = StartCoroutine(SpawnTick());
    }

    private IEnumerator SpawnTick()
    {
        while (true)
        {
            float newPos = Random.Range(-_yRange, _yRange);
            SpawnBomb(newPos);
            yield return new WaitForSeconds(_timeDelay);   
        }
    }

    private void SpawnBomb(float yPos)
    {
        Vector3 spawnPosition = new Vector3(transform.position.x, yPos, 0); 
        Bomb bomb = _bombPooler.GetCoin(); 
        bomb.transform.position = spawnPosition; 
        bomb.gameObject.SetActive(true);
        
    }
}
