namespace ApprovalTests.Terminal;

public sealed class Snapshot
{
    public FilePath Received { get; }
    public FilePath Approved { get; }
    public bool IsRerouted { get; }

    public Snapshot(FilePath received)
    {
        Received = received.NotNull();
        Approved = GetApproved(Received);
    }

    public Snapshot(FilePath received, FilePath approved, bool isRerouted)
    {
        Received = received.NotNull();
        Approved = approved.NotNull();
        IsRerouted = isRerouted;
    }

    private static FilePath GetApproved(FilePath received)
    {
        static FilePath StripExtensions(FilePath path, out string? extension)
        {
            extension = path.GetExtension();

            while (path.HasExtension)
            {
                var current = path.GetExtension();
                path = path.RemoveExtension();

                if (current == ".received")
                {
                    break;
                }
            }

            return path;
        }

        var path = StripExtensions(received, out var extension);
        var approvedPath = path.AppendExtension(".approved");
        if (extension != null)
        {
            approvedPath = approvedPath.AppendExtension(extension);
        }

        return approvedPath;
    }
}