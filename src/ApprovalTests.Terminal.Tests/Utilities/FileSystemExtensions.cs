namespace ApprovalTests.Terminal.Tests;

internal static class FileSystemExtensions
{
    public static FakeFile SetEmbedded(this FakeFile file, string path)
    {
        file.SetTextContent(EmbeddedResourceReader.LoadResourceStream(path));
        return file;
    }
}
