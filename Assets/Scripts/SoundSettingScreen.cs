using UnityEngine;
using UnityEngine.UI;

public class SoundSettingScreen : UIScreen
{
    [SerializeField] private Button _UIButton;
    [SerializeField] private Text _volume;
    [SerializeField] private GameSound _sound;

    private bool _isOpened = false;

    private void Awake()
    {
        _UIButton.onClick.AddListener(OnUIButtonClick);
        _sound.VolumeChanged += ShowVolumeInPercentage;
        Disable();
    }

    private void OnUIButtonClick()
    {
        if (_isOpened) Disable();
        else Enable();

        _isOpened = !_isOpened;
    }

    private void ShowVolumeInPercentage(float volume)
    {
        var valueInPercentage = Mathf.RoundToInt(volume * 100);
        _volume.text = $"Звук: {valueInPercentage} %";
    }
}