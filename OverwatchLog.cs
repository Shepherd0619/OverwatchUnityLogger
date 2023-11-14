// OverwatchLog
// Shepherd0619
// A enhanced logger for Unity.
using System;
using System.Text;

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

public enum OverwatchLogType
{
    Log = 1,
    Warning,
    Error,
    Assert,
    TrueLog,
}

public class OverwatchLog
{
#if UNITY_EDITOR
    public static OverwatchLogType MinLogType = OverwatchLogType.Log;
#else
    public static OverwatchLogType MinLogType = OverwatchLogType.Log;
#endif

    // 检查日志类型是否需要显示
    private static bool IsShow(OverwatchLogType type)
    {
        int ret = (int)type - (int)MinLogType;
        if (ret < 0) return false;
        return true;
    }

    // 根据颜色枚举返回对应的颜色标签字符串
    private static string ColorString(LogColor color)
    {
        string ret = null;
        switch (color)
        {
            case LogColor.BLUE:
                ret = "<color=blue>";
                break;
            case LogColor.YELLOW:
                ret = "<color=yellow>";
                break;
            case LogColor.RED:
                ret = "<color=red>";
                break;
            case LogColor.GREEN:
                ret = "<color=green>";
                break;
            case LogColor.AQUA:
                ret = "<color=aqua>";
                break;
            case LogColor.WHITE:
                ret = "<color=white>";
                break;
        }
        return ret;
    }

    // 内部日志打印方法
    static void LogInner(OverwatchLogType type, string msg, LogColor color, UnityEngine.Object context)
    {
        if (!IsShow(type)) return;

        var stringBuilder = new StringBuilder();
        stringBuilder.Append(msg ?? "Null");

#if UNITY_EDITOR
        string colorString = ColorString(color);
        if (colorString != null)
        {
            stringBuilder.Insert(0, colorString);
            stringBuilder.Append("</color>");
        }
#endif

        stringBuilder.Insert(0,
            string.Format("Unity {2}<{0} - {1:HH:mm:ss.fff}> ",
                System.Threading.Thread.CurrentThread.ManagedThreadId, DateTime.Now,
                type.ToString()));
        var message = stringBuilder;
        switch (type)
        {
            case OverwatchLogType.TrueLog:
            case OverwatchLogType.Log:
                UnityEngine.Debug.Log(message, context);
                break;
            case OverwatchLogType.Error:
                UnityEngine.Debug.LogError(message, context);
                break;
            case OverwatchLogType.Warning:
                UnityEngine.Debug.LogWarning(message, context);
                break;
            case OverwatchLogType.Assert:
                UnityEngine.Debug.LogAssertion(message, context);
                break;
            default:
                break;
        }
    }

    // 打印普通日志
    public static void Log(string log, UnityEngine.Object context = null)
    {
        if (!IsShow(OverwatchLogType.Log)) return;
        LogInner(OverwatchLogType.Log, log, LogColor.NONE, context);
    }

    // 打印警告日志
    public static void Warn(string log, UnityEngine.Object context = null)
    {
        if (!IsShow(OverwatchLogType.Warning)) return;
        LogInner(OverwatchLogType.Warning, log, LogColor.NONE, context);
    }

    // 打印错误日志
    public static void Error(string log, UnityEngine.Object context = null)
    {
        if (!IsShow(OverwatchLogType.Error)) return;
        LogInner(OverwatchLogType.Error, log, LogColor.NONE, context);
    }

    // 打印异常日志
    public static void LogException(Exception ex, UnityEngine.Object context = null)
    {
        if (!IsShow(OverwatchLogType.Error)) return;
        LogInner(OverwatchLogType.Error, ex.ToString(), LogColor.NONE, context);
    }

    // 打印断言日志
    public static void Assert(bool condition, string log = "")
    {
        if (!IsShow(OverwatchLogType.Assert)) return;
        LogInner(OverwatchLogType.Assert, log, LogColor.NONE, null);
    }
}
