using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    private float _currentCount = 0f;
    private readonly float _increaseAmount = 0.5f;
    private float _period = 0.5f;

    private Coroutine _countCoroutine;

    public event Action<float> CountChanged;

    public float CurrentCount { get { return _currentCount; }
        private set
        {
            _currentCount = value;

            CountChanged?.Invoke(_currentCount);
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            CountHandle();
    }

    private void CountHandle()
    {
        if(_countCoroutine == null)
        {
            _countCoroutine = StartCoroutine(Count());
        }
        else
        {
            StopCoroutine(_countCoroutine);
            _countCoroutine = null;
        }
    }

    private IEnumerator Count()
    {
        WaitForSeconds period = new WaitForSeconds(_period);

        while (gameObject.activeSelf == true)
        {
            yield return period;

            CurrentCount += _increaseAmount;
        }
    }
}
