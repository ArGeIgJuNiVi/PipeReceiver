using System.IO.Pipes;

namespace PipeSender;

public class _
{
    public static void Main(string[] args)
    {
        using AnonymousPipeClientStream pipe = new(PipeDirection.In, args[0]);
        byte[] lengthBytes = new byte[4];
        pipe.BeginRead(lengthBytes, 0, 4, null, null);
        int length = BitConverter.ToInt32(lengthBytes);
        byte[] bytes = new byte[length];
        pipe.Read(bytes, 0, length);
        Console.WriteLine(new string([.. bytes.Select((val) => (char)val)]));
    }
}