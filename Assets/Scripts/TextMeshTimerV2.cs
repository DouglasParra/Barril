using System;
using UnityEngine;
using UnityEngine.UI;

public class TextMeshTimerV2 : MonoBehaviour
{
    private Text _textMesh;
    private bool _isRunning;
    private bool _wasRunningLastUpdate;
    private float _elapsedSeconds;
    private float _timeLastUpdate;

    private TimeSpan timeSpan;

    void Start()
    {
        _textMesh = GetComponent<Text>();
        InvokeRepeating("updateTextMesh", 0, 0.2f);
    }

    public void StartTimer()
    {
        _isRunning = true;
    }

    public void StopTimer()
    {
        _isRunning = false;
    }

    public void CheckpointTimer(float chk)
    {
        // _elapsedSeconds recebe o float de acordo com os segundos passados
        _elapsedSeconds = chk;
        timeSpan = TimeSpan.FromSeconds(_elapsedSeconds);
        _textMesh.text = string.Format("{0:D2}:{1:D2}:{2:D3}", timeSpan.Minutes, timeSpan.Seconds, timeSpan.Milliseconds);
    }

    private void updateTextMesh()
    {
        if (!_isRunning)
        {
            _wasRunningLastUpdate = false;
            return;
        }

        if (_wasRunningLastUpdate)
        {
            var deltaTime = Time.time - _timeLastUpdate;
            _elapsedSeconds += deltaTime;
        }

        timeSpan = TimeSpan.FromSeconds(_elapsedSeconds);
        //Debug.Log(timeSpan.TotalSeconds + " - " + _elapsedSeconds);
        _textMesh.text = string.Format("{0:D2}:{1:D2}:{2:D3}", timeSpan.Minutes, timeSpan.Seconds, timeSpan.Milliseconds);

        //Debug.Log(timeSpan.Minutes + " - " + timeSpan.Seconds + " - " + timeSpan.Milliseconds);

        _timeLastUpdate = Time.time;
        _wasRunningLastUpdate = true;
    }
}