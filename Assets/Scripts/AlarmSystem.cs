using System.Collections;
using UnityEngine;

public class AlarmSystem : MonoBehaviour
{
    [SerializeField] private AudioSource _alarm;

    private Coroutine _coroutine;

    private bool _isSignalized = false;

    private void Awake()
    {
        _alarm.volume = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Thief thief))
            _isSignalized = !_isSignalized;

        if (_isSignalized == true)
            StartAlarm();
        else
            StopAlarm();
    }

    private void StartAlarm()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(ChangeValue(0.05f));

        _alarm.Play();
    }

    private void StopAlarm()
    {
        StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(ChangeValue(-0.05f));
    }

    private IEnumerator ChangeValue(float volume)
    {
        bool isWorking = true;

        WaitForSeconds wait = new(0.1f);

        while (isWorking)
        {
            _alarm.volume += volume;

            yield return wait;

            if (_alarm.volume == 0)
            {
                _alarm.Stop();
                isWorking = false;
            }
            else if(_alarm.volume == 1)
            {
                isWorking = false;
            }
        }
    }
}
