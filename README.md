# OverwatchUnityLogger
English | [中文](https://github.com/Shepherd0619/OverwatchUnityLogger/blob/master/README_zh-CN.md#overwatchunitylogger)

OverwatchLog is a logging utility for Unity, providing a more flexible and customizable alternative to Unity's built-in Debug.Log functions. It allows you to log messages with different log types, colors, and context objects.

## Features

- Log messages with different log types: Log, Warning, Error, Assert, and TrueLog.
- Customize log colors using the LogColor enum.
- Attach context objects to log messages for better debugging.
- More control over which log types to display with the MinLogType property.

## Usage

1. Import the OverwatchLog.cs script into your Unity project.
2. Use the OverwatchLog.Log, OverwatchLog.Warn, OverwatchLog.Error, OverwatchLog.LogException, and OverwatchLog.Assert methods to log messages with different log types.

```csharp
OverwatchLog.Log("This is a log message");
OverwatchLog.Warn("This is a warning message");
OverwatchLog.Error("This is an error message");
OverwatchLog.LogException(exception);
OverwatchLog.Assert(condition, "This is an assertion message");
```

3. Customize log colors by modifying the LogColor enum.

```csharp
public enum LogColor
{
    NONE = 0,
    BLUE,
    YELLOW,
    RED,
    GREEN,
    AQUA,
    WHITE,
}
```

4. Attach context objects to log messages for better debugging.

```csharp
OverwatchLog.Log("This is a log message", gameObject);
```

5. Control which log types to display by modifying the MinLogType property.

```csharp
OverwatchLog.MinLogType = OverwatchLogType.Warning;
```

## Differences from Unity's Debug.Log

OverwatchLog provides additional features and flexibility compared to Unity's built-in Debug.Log functions:

1. Log Types: OverwatchLog introduces different log types such as Warning, Error, Assert, and TrueLog, allowing for better categorization and organization of log messages.

2. Log Colors: OverwatchLog allows you to customize log colors using the LogColor enum, making it easier to visually distinguish different types of log messages.

3. Context Objects: OverwatchLog supports attaching context objects to log messages, providing additional information and context for debugging purposes.

4. MinLogType: OverwatchLog's MinLogType property allows you to control which log types to display, giving you more control over the verbosity of your logs.

## Best Practice

It is recommended for Unity headless build to implent this script.

If you are also using Springboot as a part of your Unity game server, this script can also help ya to make the log more obvious.

## Contributions

Contributions to the script are welcome. If you find any issues or have suggestions for improvements, please feel free to open an issue or submit a pull request.
