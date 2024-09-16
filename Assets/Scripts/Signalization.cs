using System.Collections;
using UnityEngine;

public class Signalization : MonoBehaviour
{
    [SerializeField] private AudioSource _alarm;

    private Coroutine _coroutine;

    private float _volumeStep = 0.05f;

    private void Awake()
    {
        _alarm.volume = 0;
    }

    public void Signal(bool isSignal)
    {
        if (isSignal == true)
            StartAlarm();
        else
            StopAlarm();
    }

    private void StartAlarm()
    {
        float targetVolume = 1;

        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(ChangeValue(targetVolume));

        _alarm.Play();
    }

    private void StopAlarm()
    {
        float targetVolume = 0;

        StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(ChangeValue(targetVolume));
    }

    private IEnumerator ChangeValue(float targetVolume)
    {
        WaitForSeconds wait = new(0.1f);

        while (_alarm.volume!=targetVolume)
        {
            _alarm.volume = Mathf.MoveTowards(_alarm.volume, targetVolume, _volumeStep);

            yield return wait;
        }

        if (_alarm.volume == 0)
            _alarm.Stop();
    }
}
