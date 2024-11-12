using System.Collections.Generic;
using UnityEngine;

public class BombPooler : MonoBehaviour
{
    [SerializeField] private Bomb _bombPrefab; 
    [SerializeField] private int _poolSize = 10; 
    [field: SerializeField] private List<Bomb> bombPool = new List<Bomb>();

    private void Start()
    {
        for (int i = 0; i < _poolSize; i++)
        {
            Bomb bomb = Instantiate(_bombPrefab);
            bombPool.Add(bomb);
            bomb.gameObject.SetActive(false); 
        }
    }

    public Bomb GetCoin()
    {
        foreach (Bomb bomb in bombPool)
        {
            if (!bomb.gameObject.activeInHierarchy)
            {
                return bomb;
            }
        }
        
        Bomb newBomb = Instantiate(_bombPrefab);
        newBomb.gameObject.SetActive(false);
        bombPool.Add(newBomb);
        return newBomb;
    }
}
