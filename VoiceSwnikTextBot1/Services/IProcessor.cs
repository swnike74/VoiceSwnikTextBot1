namespace VoiceSwnikTextBot1.Services
{
    public interface IProcessor
    {
        int NumOfSymbols(string message);
        int SumOfDigits(string message);
    }
}