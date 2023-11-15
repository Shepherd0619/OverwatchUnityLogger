# OverwatchUnityLogger

OverwatchLog是一个用于Unity的日志记录工具，提供了一个更灵活和可定制的替代方案，用于Unity内置的Debug.Log函数。它允许您使用不同的日志类型、颜色和上下文对象记录消息。

## 特点

- 使用不同的日志类型记录消息：Log、Warning、Error、Assert和TrueLog。
- 使用LogColor枚举自定义日志颜色。
- 附加上下文对象到日志消息以进行更好的调试。
- 使用MinLogType属性更好地控制显示哪些日志类型。

## 用法

1. 将OverwatchLog.cs脚本导入到您的Unity项目中。
2. 使用OverwatchLog.Log、OverwatchLog.Warn、OverwatchLog.Error、OverwatchLog.LogException和OverwatchLog.Assert方法以不同的日志类型记录消息。

```csharp
OverwatchLog.Log("这是一条日志消息");
OverwatchLog.Warn("这是一条警告消息");
OverwatchLog.Error("这是一条错误消息");
OverwatchLog.LogException(exception);
OverwatchLog.Assert(condition, "这是一条断言消息");
```

3. 通过修改LogColor枚举来自定义日志颜色。

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

4. 附加上下文对象到日志消息以进行更好的调试。

```csharp
OverwatchLog.Log("这是一条日志消息", gameObject);
```

5. 通过修改MinLogType属性来控制显示哪些日志类型。

```csharp
OverwatchLog.MinLogType = OverwatchLogType.Warning;
```

## 与Unity的Debug.Log的区别

与Unity内置的Debug.Log函数相比，OverwatchLog提供了额外的功能和灵活性：

1. 日志类型：OverwatchLog引入了不同的日志类型，如Warning、Error、Assert和TrueLog，可以更好地对日志消息进行分类和组织。

2. 日志颜色：OverwatchLog允许您使用LogColor枚举自定义日志颜色，使不同类型的日志消息更容易进行视觉区分。

3. 上下文对象：OverwatchLog支持将上下文对象附加到日志消息中，为调试提供额外的信息和上下文。

4. MinLogType：OverwatchLog的MinLogType属性允许您控制显示哪些日志类型，从而更好地控制日志的详细程度。

## 最佳实践

建议在Unity无头构建中实现此脚本。

如果您使用Springboot作为Unity游戏服务器的一部分，这个脚本也可以帮助您使日志更加明显。

## 贡献

欢迎对该脚本进行贡献。如果您发现任何问题或有改进建议，请随时在Issues中提出或提交Pull Requests。
