using System.Collections;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _lifeTime;

    private void OnEnable()
    {
        StartCoroutine(LifeTick());
    }
    
    private void Update()
    {
        transform.position += Vector3.left * _speed;
    }

    private IEnumerator LifeTick()
    {
        yield return new WaitForSeconds(_lifeTime);
        Die();
    }

    public void Die()
    {
        gameObject.SetActive(false);
    }
}
