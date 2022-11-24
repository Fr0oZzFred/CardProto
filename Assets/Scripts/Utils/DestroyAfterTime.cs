using System.Collections;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    [SerializeField]
    private GameObject _gameObjectToDestroy = null;

    [SerializeField]
    private float _timeBeforeDestroy = 1;

    [SerializeField]
    private bool _beginOnStart = true;

    private void Start()
    {
        if (_beginOnStart)
            StartDestroy();
    }

    public void StartDestroy()
    {
        StartCoroutine(Destruction());
    }

    private IEnumerator Destruction()
    {
        yield return new WaitForSeconds(_timeBeforeDestroy);

        Destroy(_gameObjectToDestroy);
    }
}
