public class SoundData : SavableData
{
    public SoundData(string fileName) : base(fileName) { }

    public float Volume = 1f;

    public void Load()
    {
        SoundData data = jsonData.Read<SoundData>(path);
        if (data != null)
        {
            Volume = data.Volume;
            ConfirmDataAvailability();
        }
    }
}