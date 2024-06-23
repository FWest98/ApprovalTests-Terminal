namespace ApprovalTests.Terminal.Tests;

public sealed class SnapshotFinderTests
{
    [Fact]
    public void Should_Return_Expected_Snapshot()
    {
        // Given
        var environment = new FakeEnvironment(Spectre.IO.PlatformFamily.Linux);
        var filesystem = new FakeFileSystem(environment);
        var globber = new Globber(filesystem, environment);
        filesystem.CreateFile("/Working/lol.received.txt");
        filesystem.CreateFile("/Working/lol.approved.txt");
        var finder = new SnapshotFinder(filesystem, globber, environment);

        // When
        var result = finder.Find().SingleOrDefault();

        // Then
        result.ShouldNotBeNull();
        result.IsRerouted.ShouldBeFalse();
        result.Received.FullPath.ShouldBe("/Working/lol.received.txt");
        result.Approved.FullPath.ShouldBe("/Working/lol.approved.txt");
    }

    [Fact]
    public void Should_Return_Expected_Snapshot_For_Non_Framework_Specific_File()
    {
        // Given
        var environment = new FakeEnvironment(Spectre.IO.PlatformFamily.Linux);
        var filesystem = new FakeFileSystem(environment);
        var globber = new Globber(filesystem, environment);
        filesystem.CreateFile("/Working/lol.DotNet6_0.received.txt");
        filesystem.CreateFile("/Working/lol.approved.txt");
        var finder = new SnapshotFinder(filesystem, globber, environment);

        // When
        var result = finder.Find().SingleOrDefault();

        // Then
        result.ShouldNotBeNull();
        result.IsRerouted.ShouldBeTrue();
        result.Received.FullPath.ShouldBe("/Working/lol.DotNet6_0.received.txt");
        result.Approved.FullPath.ShouldBe("/Working/lol.approved.txt");
    }

    [Fact]
    public void Should_Return_Expected_Snapshot_For_Framework_Specific_File()
    {
        // Given
        var environment = new FakeEnvironment(Spectre.IO.PlatformFamily.Linux);
        var filesystem = new FakeFileSystem(environment);
        var globber = new Globber(filesystem, environment);
        filesystem.CreateFile("/Working/lol.DotNet6_0.received.txt");
        filesystem.CreateFile("/Working/lol.DotNet6_0.approved.txt");
        var finder = new SnapshotFinder(filesystem, globber, environment);

        // When
        var result = finder.Find().SingleOrDefault();

        // Then
        result.ShouldNotBeNull();
        result.IsRerouted.ShouldBeFalse();
        result.Received.FullPath.ShouldBe("/Working/lol.DotNet6_0.received.txt");
        result.Approved.FullPath.ShouldBe("/Working/lol.DotNet6_0.approved.txt");
    }
}