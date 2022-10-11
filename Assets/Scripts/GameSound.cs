using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class GameSound : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private Slider _volumeSlider;
    private SoundData _savableData;

    public event UnityAction<float> VolumeChanged;

    private float Volume
    {
        set
        {
            _audioSource.volume = value;
            _volumeSlider.value = value;
            VolumeChanged?.Invoke(value);
            _savableData.Volume = value;
            _savableData.Save();
        }
    }

    private void Awake()
    {
        _savableData = new SoundData("Sound_volume");
        _savableData.LoadingSuccessful += OnSavedDataLoaded;
        _volumeSlider.onValueChanged.AddListener(SetCurrentVolume);
    }

    private void Start() => _savableData.Load();

    private void OnSavedDataLoaded() => Volume = _savableData.Volume;

    private void SetCurrentVolume(float value) => Volume = value;
}