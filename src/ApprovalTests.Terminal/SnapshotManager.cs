namespace ApprovalTests.Terminal;

public sealed class SnapshotManager
{
    private readonly IFileSystem _fileSystem;

    public SnapshotManager(IFileSystem fileSystem)
    {
        _fileSystem = fileSystem;
    }

    public bool Process(Snapshot snapshot, SnapshotAction action)
    {
        return action switch
        {
            SnapshotAction.Approve => Approve(snapshot),
            SnapshotAction.Reject => Reject(snapshot),
            _ => throw new InvalidOperationException("Unknown snapshot action"),
        };
    }

    public bool Approve(Snapshot snapshot)
    {
        try
        {
            // Delete the approved file
            if (_fileSystem.File.Exists(snapshot.Approved))
            {
                _fileSystem.File.Delete(snapshot.Approved);
                if (_fileSystem.File.Exists(snapshot.Approved))
                {
                    // Could not delete the file
                    return false;
                }
            }

            // Now move the file
            _fileSystem.File.Move(snapshot.Received, snapshot.Approved);
        }
        catch
        {
            return false;
        }

        return true;
    }

    public bool Reject(Snapshot snapshot)
    {
        try
        {
            // Delete the received file
            if (_fileSystem.File.Exists(snapshot.Received))
            {
                _fileSystem.File.Delete(snapshot.Received);
                if (_fileSystem.File.Exists(snapshot.Received))
                {
                    // Could not delete the file
                    return false;
                }
            }
        }
        catch
        {
            return false;
        }

        return true;
    }
}