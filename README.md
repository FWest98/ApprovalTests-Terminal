# ApprovalTests.Terminal

A dotnet tool for managing Approval Tests snapshots. Adapted from the [Verify Original](https://github.com/VerifyTests/Verify.Terminal)

![A screenshot of ApprovalTests.Terminal](res/screenshot.png)

## Installation

Install by running the following command:

```bash
dotnet tool install -g ApprovalTests.Terminal
```

## Review pending snapshots

```
USAGE:
    approvaltests review [OPTIONS]

OPTIONS:
    -h, --help                    Prints help information
    -w, --work <DIRECTORY>        The working directory to use
    -c, --context <LINE-COUNT>    The number of context lines to show. Defaults to 2
```

```
> dotnet approvaltests review
```

## Approve all pending snapshots

```
USAGE:
    approvaltests approve [OPTIONS]

OPTIONS:
    -h, --help                Prints help information
    -w, --work <DIRECTORY>    The working directory to use
    -y, --yes                 Confirm all prompts.
```

```
> dotnet approvaltests approve
```

## Reject all pending snapshots

```
USAGE:
    approvaltests reject [OPTIONS]

OPTIONS:
    -h, --help                Prints help information
    -w, --work <DIRECTORY>    The working directory to use
    -y, --yes                 Confirm all prompts.
```

```
> dotnet approvaltests reject
```

## Building

We're using [Cake](https://github.com/cake-build/cake) as a 
[dotnet tool](https://docs.microsoft.com/en-us/dotnet/core/tools/global-tools) 
for building. So make sure that you've restored Cake by running 
the following in the repository root:

```
> dotnet tool restore
```

After that, running the build is as easy as writing:

```
> dotnet cake
```