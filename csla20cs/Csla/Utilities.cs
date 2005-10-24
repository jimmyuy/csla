using System;
using System.Reflection;

namespace Csla
{
  internal static class Utilities
  {

    public static bool IsNumeric(object value)
    {
      double dbl;
      return double.TryParse(value.ToString(), System.Globalization.NumberStyles.Any,
        System.Globalization.NumberFormatInfo.InvariantInfo, out dbl);
    }

    public static object CallByName(object target, string methodName, CallType callType, params object[] args)
    {
      switch (callType)
      {
        case CallType.Get:
          {
            PropertyInfo p = target.GetType().GetProperty(methodName);
            return p.GetValue(target, args);
          }
        case CallType.Let:
        case CallType.Set:
          {
            PropertyInfo p = target.GetType().GetProperty(methodName);
            object[] index = null;
            args.CopyTo(index, 1);
            p.SetValue(target, args[0], index);
            return null;
          }
        case CallType.Method:
          {
            MethodInfo m = target.GetType().GetMethod(methodName);
            return m.Invoke(target, args);
          }
      }
      return null;
    }
  }


  internal enum CallType
  {
    Get,
    Let,
    Method,
    Set
  }
}
