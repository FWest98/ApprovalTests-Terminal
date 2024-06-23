namespace ApprovalTests.Terminal.Commands;

public sealed class ApproveCommand : ModifyCommand
{
    public override string Verb { get; } = "Approve";
    public override SnapshotAction Action { get; } = SnapshotAction.Approve;

    public ApproveCommand(
        SnapshotFinder snapshotFinder,
        SnapshotManager snapshotManager)
            : base(snapshotFinder, snapshotManager)
    {
    }
}