using System.Collections;
using UnityEngine;

public class AlarmSystem : MonoBehaviour
{
    [SerializeField] private AudioSource _alarm;

    private Coroutine _coroutine;

    private float _volume = -0.05f;

    private bool _isSignalized = false;

    private void Awake()
    {
        _alarm.volume = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        _isSignalized = !_isSignalized;
        _volume = -_volume;

        if (_isSignalized)
        {
            _coroutine ??= StartCoroutine(ChangeValue());

            _alarm.Play();
        }
        else if (_alarm.volume == 0)
        {
            StopCoroutine(_coroutine);
            _alarm.Stop();
        }
    }

    private IEnumerator ChangeValue()
    {
        WaitForSeconds wait = new(0.1f);

        while (enabled)
        {
            _alarm.volume += _volume;

            yield return wait;
        }
    }
}
