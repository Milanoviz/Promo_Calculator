namespace Modules.Core.Scripts.Services.Save.Modules
{
    public interface ISaveModule
    {
        string Id { get; }
        string ToJson();
        void FromJson(string json);
    }
}