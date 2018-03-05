namespace FieldEffect.VCL.Server.Interfaces
{
    public interface IRdpServerVirtualChannel
    {
        void CloseChannel();
        void OpenChannel();
        string ReadChannel();
        void WriteChannel(string message);
    }
}