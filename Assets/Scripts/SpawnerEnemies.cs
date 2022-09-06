using System.Collections;
using UnityEngine;

public class SpawnerEnemies : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Transform[] _spawnPoints;
    
    private float _cooldown;

    private void Start()
    {
        _cooldown = 2f;

        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        var waitForSeconds = new WaitForSeconds(_cooldown);

        for (int i = 0; i < _spawnPoints.Length; i++)
        {
            Instantiate(_enemy, _spawnPoints[i].position, Quaternion.identity);

            yield return waitForSeconds;
        }
    }
}