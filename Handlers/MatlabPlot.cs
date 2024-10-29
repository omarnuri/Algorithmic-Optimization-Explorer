#region сборка WPFMatlabPlotter, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// C:\Users\Omar\.nuget\packages\wpfmatlabplotter\1.0.1\lib\net461\WPFMatlabPlotter.dll
// Decompiled with ICSharpCode.Decompiler 8.1.1.7464
#endregion

using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WPFMatLabPlotter;

public class MatlabPlot : UserControl
{
    private IntPtr _foundWindow = IntPtr.Zero;

    private Window _parentWindow = null;

    [DllImport("User32.Dll")]
    private static extern void SetWindowText(IntPtr hwnd, string lpString);

    [DllImport("User32.Dll")]
    private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

    [DllImport("User32.dll")]
    private static extern int SendMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);

    [DllImport("User32.Dll")]
    private static extern void SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

    [DllImport("User32.Dll")]
    private static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

    [DllImport("User32.Dll")]
    private static extern long SetWindowLong(IntPtr hWnd, int nIndex, long dwNewLong);

    [DllImport("User32.Dll")]
    private static extern long GetWindowLong(IntPtr hWnd, int nIndex);

    [DllImport("User32.Dll")]
    private static extern ulong SetClassLongPtr(IntPtr hWnd, int nIndex, long dwNewLong);

    public MatlabPlot()
    {
        base.LayoutUpdated += MatlabPlot_LayoutUpdated;
    }

    public void GetInstanceWindow(string name, int time, int setDelay)
    {
        var timer = Stopwatch.StartNew();
        do
        {
            if (FindWindow("SunAwtFrame", name)!=IntPtr.Zero)
            {
                Thread.Sleep(setDelay);
                _foundWindow = FindWindow("SunAwtFrame", name);
            }
        } while (_foundWindow==IntPtr.Zero && timer.ElapsedMilliseconds<time);
        timer.Stop();
    }
    public void BuildGraph(string figureName, int HandlerWorkTime = 2000, int setDelayTime = 100)
    {
        _parentWindow = Window.GetWindow(this);
        GetInstanceWindow(figureName, HandlerWorkTime, setDelayTime);
        long windowLong = GetWindowLong(_foundWindow, -16);
        windowLong &= -13565953;
        SetWindowLong(_foundWindow, -16, windowLong);
        SetParent(_foundWindow, new WindowInteropHelper(_parentWindow).Handle);
        SetClassLongPtr(_foundWindow, 26, 3L);
    }


 



    public void DestroyGraph()
    {
        SendMessage(_foundWindow, 274u, 61536, 0);
        _foundWindow = IntPtr.Zero;
        _parentWindow = null;

    }

    private void MatlabPlot_LayoutUpdated(object sender, EventArgs e)
    {
        Point relativeCoordinates = GetRelativeCoordinates();
        MoveWindow(_foundWindow, Convert.ToInt32(relativeCoordinates.X), Convert.ToInt32(relativeCoordinates.Y), Convert.ToInt32(base.ActualWidth), Convert.ToInt32(base.ActualHeight), bRepaint: true);
    }

    private Point GetRelativeCoordinates()
    {
        Point result = new Point(0.0, 0.0);
        DependencyObject parent = VisualTreeHelper.GetParent(this);
        Point point = TransformToAncestor((Visual)parent).Transform(new Point(0.0, 0.0));
        result.X += point.X;
        result.Y += point.Y;
        while (parent != null)
        {
            Visual visual = (Visual)parent;
            parent = VisualTreeHelper.GetParent(parent);
            if (parent == null)
            {
                break;
            }

            point = visual.TransformToAncestor((Visual)parent).Transform(new Point(0.0, 0.0));
            result.X += point.X;
            result.Y += point.Y;
        }

        return result;
    }
}
#if false // Журнал декомпиляции
Элементов в кэше: "202"
------------------
Разрешить: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
Найдена одна сборка: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
Загрузить из: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.1\ref\net8.0\mscorlib.dll"
------------------
Разрешить: "PresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
Найдена одна сборка: "PresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
Внимание! Несовпадение версий. Ожидалось: "4.0.0.0", получено: "8.0.0.0"
Загрузить из: "C:\Program Files\dotnet\packs\Microsoft.WindowsDesktop.App.Ref\8.0.1\ref\net8.0\PresentationFramework.dll"
------------------
Разрешить: "WindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
Найдена одна сборка: "WindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
Внимание! Несовпадение версий. Ожидалось: "4.0.0.0", получено: "8.0.0.0"
Загрузить из: "C:\Program Files\dotnet\packs\Microsoft.WindowsDesktop.App.Ref\8.0.1\ref\net8.0\WindowsBase.dll"
------------------
Разрешить: "PresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
Найдена одна сборка: "PresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
Внимание! Несовпадение версий. Ожидалось: "4.0.0.0", получено: "8.0.0.0"
Загрузить из: "C:\Program Files\dotnet\packs\Microsoft.WindowsDesktop.App.Ref\8.0.1\ref\net8.0\PresentationCore.dll"
------------------
Разрешить: "Microsoft.Win32.Registry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Найдена одна сборка: "Microsoft.Win32.Registry, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Внимание! Несовпадение версий. Ожидалось: "0.0.0.0", получено: "8.0.0.0"
Загрузить из: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.1\ref\net8.0\Microsoft.Win32.Registry.dll"
------------------
Разрешить: "System.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Найдена одна сборка: "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Внимание! Несовпадение версий. Ожидалось: "0.0.0.0", получено: "8.0.0.0"
Загрузить из: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.1\ref\net8.0\System.Runtime.dll"
------------------
Разрешить: "System.Security.Principal.Windows, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Найдена одна сборка: "System.Security.Principal.Windows, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Внимание! Несовпадение версий. Ожидалось: "0.0.0.0", получено: "8.0.0.0"
Загрузить из: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.1\ref\net8.0\System.Security.Principal.Windows.dll"
------------------
Разрешить: "System.Security.Permissions, Version=0.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51"
Найдена одна сборка: "System.Security.Permissions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51"
Внимание! Несовпадение версий. Ожидалось: "0.0.0.0", получено: "8.0.0.0"
Загрузить из: "C:\Program Files\dotnet\packs\Microsoft.WindowsDesktop.App.Ref\8.0.1\ref\net8.0\System.Security.Permissions.dll"
------------------
Разрешить: "System.Collections, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Найдена одна сборка: "System.Collections, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Внимание! Несовпадение версий. Ожидалось: "0.0.0.0", получено: "8.0.0.0"
Загрузить из: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.1\ref\net8.0\System.Collections.dll"
------------------
Разрешить: "System.Collections.NonGeneric, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Найдена одна сборка: "System.Collections.NonGeneric, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Внимание! Несовпадение версий. Ожидалось: "0.0.0.0", получено: "8.0.0.0"
Загрузить из: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.1\ref\net8.0\System.Collections.NonGeneric.dll"
------------------
Разрешить: "System.Collections.Concurrent, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Найдена одна сборка: "System.Collections.Concurrent, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Внимание! Несовпадение версий. Ожидалось: "0.0.0.0", получено: "8.0.0.0"
Загрузить из: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.1\ref\net8.0\System.Collections.Concurrent.dll"
------------------
Разрешить: "System.ObjectModel, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Найдена одна сборка: "System.ObjectModel, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Внимание! Несовпадение версий. Ожидалось: "0.0.0.0", получено: "8.0.0.0"
Загрузить из: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.1\ref\net8.0\System.ObjectModel.dll"
------------------
Разрешить: "System.Console, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Найдена одна сборка: "System.Console, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Внимание! Несовпадение версий. Ожидалось: "0.0.0.0", получено: "8.0.0.0"
Загрузить из: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.1\ref\net8.0\System.Console.dll"
------------------
Разрешить: "System.Runtime.InteropServices, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Найдена одна сборка: "System.Runtime.InteropServices, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Внимание! Несовпадение версий. Ожидалось: "0.0.0.0", получено: "8.0.0.0"
Загрузить из: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.1\ref\net8.0\System.Runtime.InteropServices.dll"
------------------
Разрешить: "System.Diagnostics.Contracts, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Найдена одна сборка: "System.Diagnostics.Contracts, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Внимание! Несовпадение версий. Ожидалось: "0.0.0.0", получено: "8.0.0.0"
Загрузить из: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.1\ref\net8.0\System.Diagnostics.Contracts.dll"
------------------
Разрешить: "System.Diagnostics.StackTrace, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Найдена одна сборка: "System.Diagnostics.StackTrace, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Внимание! Несовпадение версий. Ожидалось: "0.0.0.0", получено: "8.0.0.0"
Загрузить из: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.1\ref\net8.0\System.Diagnostics.StackTrace.dll"
------------------
Разрешить: "System.Diagnostics.Tracing, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Найдена одна сборка: "System.Diagnostics.Tracing, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Внимание! Несовпадение версий. Ожидалось: "0.0.0.0", получено: "8.0.0.0"
Загрузить из: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.1\ref\net8.0\System.Diagnostics.Tracing.dll"
------------------
Разрешить: "System.IO.FileSystem.DriveInfo, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Найдена одна сборка: "System.IO.FileSystem.DriveInfo, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Внимание! Несовпадение версий. Ожидалось: "0.0.0.0", получено: "8.0.0.0"
Загрузить из: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.1\ref\net8.0\System.IO.FileSystem.DriveInfo.dll"
------------------
Разрешить: "System.IO.IsolatedStorage, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Найдена одна сборка: "System.IO.IsolatedStorage, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Внимание! Несовпадение версий. Ожидалось: "0.0.0.0", получено: "8.0.0.0"
Загрузить из: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.1\ref\net8.0\System.IO.IsolatedStorage.dll"
------------------
Разрешить: "System.ComponentModel, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Найдена одна сборка: "System.ComponentModel, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Внимание! Несовпадение версий. Ожидалось: "0.0.0.0", получено: "8.0.0.0"
Загрузить из: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.1\ref\net8.0\System.ComponentModel.dll"
------------------
Разрешить: "System.Threading.Thread, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Найдена одна сборка: "System.Threading.Thread, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Внимание! Несовпадение версий. Ожидалось: "0.0.0.0", получено: "8.0.0.0"
Загрузить из: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.1\ref\net8.0\System.Threading.Thread.dll"
------------------
Разрешить: "System.Reflection.Emit, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Найдена одна сборка: "System.Reflection.Emit, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Внимание! Несовпадение версий. Ожидалось: "0.0.0.0", получено: "8.0.0.0"
Загрузить из: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.1\ref\net8.0\System.Reflection.Emit.dll"
------------------
Разрешить: "System.Reflection.Emit.ILGeneration, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Найдена одна сборка: "System.Reflection.Emit.ILGeneration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Внимание! Несовпадение версий. Ожидалось: "0.0.0.0", получено: "8.0.0.0"
Загрузить из: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.1\ref\net8.0\System.Reflection.Emit.ILGeneration.dll"
------------------
Разрешить: "System.Reflection.Emit.Lightweight, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Найдена одна сборка: "System.Reflection.Emit.Lightweight, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Внимание! Несовпадение версий. Ожидалось: "0.0.0.0", получено: "8.0.0.0"
Загрузить из: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.1\ref\net8.0\System.Reflection.Emit.Lightweight.dll"
------------------
Разрешить: "System.Reflection.Primitives, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Найдена одна сборка: "System.Reflection.Primitives, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Внимание! Несовпадение версий. Ожидалось: "0.0.0.0", получено: "8.0.0.0"
Загрузить из: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.1\ref\net8.0\System.Reflection.Primitives.dll"
------------------
Разрешить: "System.Resources.Writer, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Найдена одна сборка: "System.Resources.Writer, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Внимание! Несовпадение версий. Ожидалось: "0.0.0.0", получено: "8.0.0.0"
Загрузить из: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.1\ref\net8.0\System.Resources.Writer.dll"
------------------
Разрешить: "System.Runtime.CompilerServices.VisualC, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Найдена одна сборка: "System.Runtime.CompilerServices.VisualC, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Внимание! Несовпадение версий. Ожидалось: "0.0.0.0", получено: "8.0.0.0"
Загрузить из: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.1\ref\net8.0\System.Runtime.CompilerServices.VisualC.dll"
------------------
Разрешить: "System.Runtime.Serialization.Formatters, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Найдена одна сборка: "System.Runtime.Serialization.Formatters, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Внимание! Несовпадение версий. Ожидалось: "0.0.0.0", получено: "8.0.0.0"
Загрузить из: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.1\ref\net8.0\System.Runtime.Serialization.Formatters.dll"
------------------
Разрешить: "System.Security.AccessControl, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Найдена одна сборка: "System.Security.AccessControl, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Внимание! Несовпадение версий. Ожидалось: "0.0.0.0", получено: "8.0.0.0"
Загрузить из: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.1\ref\net8.0\System.Security.AccessControl.dll"
------------------
Разрешить: "System.IO.FileSystem.AccessControl, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Найдена одна сборка: "System.IO.FileSystem.AccessControl, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Внимание! Несовпадение версий. Ожидалось: "0.0.0.0", получено: "8.0.0.0"
Загрузить из: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.1\ref\net8.0\System.IO.FileSystem.AccessControl.dll"
------------------
Разрешить: "System.Threading.AccessControl, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Найдена одна сборка: "System.Threading.AccessControl, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Внимание! Несовпадение версий. Ожидалось: "0.0.0.0", получено: "8.0.0.0"
Загрузить из: "C:\Program Files\dotnet\packs\Microsoft.WindowsDesktop.App.Ref\8.0.1\ref\net8.0\System.Threading.AccessControl.dll"
------------------
Разрешить: "System.Security.Claims, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Найдена одна сборка: "System.Security.Claims, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Внимание! Несовпадение версий. Ожидалось: "0.0.0.0", получено: "8.0.0.0"
Загрузить из: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.1\ref\net8.0\System.Security.Claims.dll"
------------------
Разрешить: "System.Security.Cryptography, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Найдена одна сборка: "System.Security.Cryptography, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Внимание! Несовпадение версий. Ожидалось: "0.0.0.0", получено: "8.0.0.0"
Загрузить из: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.1\ref\net8.0\System.Security.Cryptography.dll"
------------------
Разрешить: "System.Text.Encoding.Extensions, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Найдена одна сборка: "System.Text.Encoding.Extensions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Внимание! Несовпадение версий. Ожидалось: "0.0.0.0", получено: "8.0.0.0"
Загрузить из: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.1\ref\net8.0\System.Text.Encoding.Extensions.dll"
------------------
Разрешить: "System.Threading, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Найдена одна сборка: "System.Threading, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Внимание! Несовпадение версий. Ожидалось: "0.0.0.0", получено: "8.0.0.0"
Загрузить из: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.1\ref\net8.0\System.Threading.dll"
------------------
Разрешить: "System.Threading.Overlapped, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Найдена одна сборка: "System.Threading.Overlapped, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Внимание! Несовпадение версий. Ожидалось: "0.0.0.0", получено: "8.0.0.0"
Загрузить из: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.1\ref\net8.0\System.Threading.Overlapped.dll"
------------------
Разрешить: "System.Threading.ThreadPool, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Найдена одна сборка: "System.Threading.ThreadPool, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Внимание! Несовпадение версий. Ожидалось: "0.0.0.0", получено: "8.0.0.0"
Загрузить из: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.1\ref\net8.0\System.Threading.ThreadPool.dll"
------------------
Разрешить: "System.Threading.Tasks.Parallel, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Найдена одна сборка: "System.Threading.Tasks.Parallel, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Внимание! Несовпадение версий. Ожидалось: "0.0.0.0", получено: "8.0.0.0"
Загрузить из: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.1\ref\net8.0\System.Threading.Tasks.Parallel.dll"
------------------
Разрешить: "System.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
Найдена одна сборка: "System.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
Загрузить из: "C:\Program Files\dotnet\packs\Microsoft.WindowsDesktop.App.Ref\8.0.1\ref\net8.0\System.Xaml.dll"
------------------
Разрешить: "WindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
Найдена одна сборка: "WindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
Загрузить из: "C:\Program Files\dotnet\packs\Microsoft.WindowsDesktop.App.Ref\8.0.1\ref\net8.0\WindowsBase.dll"
------------------
Разрешить: "System.ObjectModel, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Найдена одна сборка: "System.ObjectModel, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Загрузить из: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.1\ref\net8.0\System.ObjectModel.dll"
------------------
Разрешить: "System.IO.Packaging, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Найдена одна сборка: "System.IO.Packaging, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Загрузить из: "C:\Program Files\dotnet\packs\Microsoft.WindowsDesktop.App.Ref\8.0.1\ref\net8.0\System.IO.Packaging.dll"
------------------
Разрешить: "System.Security.Permissions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51"
Найдена одна сборка: "System.Security.Permissions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51"
Загрузить из: "C:\Program Files\dotnet\packs\Microsoft.WindowsDesktop.App.Ref\8.0.1\ref\net8.0\System.Security.Permissions.dll"
------------------
Разрешить: "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Найдена одна сборка: "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Загрузить из: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.1\ref\net8.0\System.Runtime.dll"
------------------
Разрешить: "System.Security.AccessControl, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Найдена одна сборка: "System.Security.AccessControl, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Загрузить из: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.1\ref\net8.0\System.Security.AccessControl.dll"
------------------
Разрешить: "System.Windows.Extensions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51"
Найдена одна сборка: "System.Windows.Extensions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51"
Загрузить из: "C:\Program Files\dotnet\packs\Microsoft.WindowsDesktop.App.Ref\8.0.1\ref\net8.0\System.Windows.Extensions.dll"
------------------
Разрешить: "System.Drawing.Common, Version=8.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51"
Не удалось найти по имени: "System.Drawing.Common, Version=8.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51"
#endif
