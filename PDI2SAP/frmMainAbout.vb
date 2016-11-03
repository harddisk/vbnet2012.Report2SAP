Imports System.Runtime.InteropServices

'<System.ComponentModel.DesignerCategory("Code")>
Partial Public Class frmMain

#Region " About menuitem "

    '   P/Invoke constants
    Private Const WM_SYSCOMMAND = &H112
    Private Const MF_STRING = &H0
    Private Const MF_SEPARATOR = &H800

    ' ID for the About item on the system menu
    Private SYSMENU_ABOUT_ID As Integer = &H1

    '   P/Invoke declarations
    <DllImport("user32.dll", CharSet:=CharSet.Auto, SetLastError:=True)>
    Private Shared Function GetSystemMenu(hWnd As IntPtr, bRevert As Boolean) As IntPtr
    End Function

    <DllImport("user32.dll", CharSet:=CharSet.Auto, SetLastError:=True)> _
    Private Shared Function AppendMenu(hMenu As IntPtr, uFlags As Integer, uIDNewItem As Integer, lpNewItem As String) As Boolean
    End Function

    <DllImport("user32.dll", CharSet:=CharSet.Auto, SetLastError:=True)> _
    Private Shared Function InsertMenu(hMenu As IntPtr, uPosition As Integer, uFlags As Integer, uIDNewItem As Integer, lpNewItem As String) As Boolean
    End Function

    Protected Overrides Sub WndProc(ByRef m As Message)
        MyBase.WndProc(m)
        If m.Msg = WM_SYSCOMMAND AndAlso m.WParam = SYSMENU_ABOUT_ID Then
            MessageBox.Show(String.Format("{1}{0}ver: {2}{0}{0}Author: {3}{0}{0}{4}",
                                          ControlChars.CrLf,
                                          My.Application.Info.ProductName,
                                          My.Application.Info.Version.ToString,
                                          "cw.tham@hyundai.com.my",
                                          My.Application.Info.Copyright),
                                      "About " & My.Application.Info.Title,
                                      MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Protected Overrides Sub OnHandleCreated(e As EventArgs)
        MyBase.OnHandleCreated(e)
        Dim hSysMenu = GetSystemMenu(Me.Handle, False)
        AppendMenu(hSysMenu, MF_SEPARATOR, 0, String.Empty)
        AppendMenu(hSysMenu, MF_STRING, SYSMENU_ABOUT_ID, "&About...")
    End Sub

#End Region

End Class