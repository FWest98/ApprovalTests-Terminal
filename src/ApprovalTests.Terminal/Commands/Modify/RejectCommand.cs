namespace ApprovalTests.Terminal.Commands;

public sealed class RejectCommand : ModifyCommand
{
    public override string Verb => "Reject";
    public override SnapshotAction Action => SnapshotAction.Reject;

    public RejectCommand(
        SnapshotFinder snapshotFinder,
        SnapshotManager snapshotManager)
            : base(snapshotFinder, snapshotManager)
    {
    }
}