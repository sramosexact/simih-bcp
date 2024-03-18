Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Windows.Forms


Public Class Rapi

    <Runtime.InteropServices.DllImport("rapi.dll", CharSet:=CharSet.Unicode)> _
    Private Shared Function CeCloseHandle(ByVal hobject As Integer) As Integer
    End Function

    <DllImport("rapi.dll", CharSet:=CharSet.Unicode)> _
    Private Shared Function CeCreateFile(ByVal lpfilename As String, ByVal dwDesiredAccess As Integer, ByVal dwShareMode As Integer, ByVal lpSecurityAttributes As Integer, _
        ByVal dwCreationDisposition As Integer, ByVal dwFlagsAndAttributes As Integer, ByVal hTemplatefile As Integer) As Integer
    End Function

    <DllImport("rapi.dll", CharSet:=CharSet.Unicode)> _
    Private Shared Function CeRapiInitEx(ByVal prapiinit As RAPIINIT) As Long
    End Function

    <DllImport("rapi.dll", CharSet:=CharSet.Unicode)> _
    Private Shared Function CeRapiInit() As Integer
    End Function

    <DllImport("rapi.dll", CharSet:=CharSet.Unicode)> _
    Private Shared Function CeRapiUninit() As Integer
    End Function


    <DllImport("rapi.dll", CharSet:=CharSet.Unicode)> _
    Private Shared Function CeReadFile(ByVal hFile As Integer, ByVal lpBuffer As Byte(), ByVal nNumberOfBytesToRead As Integer, ByRef lpNumberOfBytesRead As Integer, ByVal lpOverlapped As Integer) As Integer
    End Function

    <DllImport("rapi.dll", CharSet:=CharSet.Unicode)> _
    Private Shared Function CeWriteFile(ByVal hFile As Integer, ByVal lpBuffer As Byte(), ByVal nNumberofbytestoWrite As Integer, ByRef lpNumberofBytesWritten As Integer, ByVal lpOverlapped As Integer) As Integer
    End Function

    <DllImport("rapi.dll", CharSet:=CharSet.Unicode)> _
    Private Shared Function GetLastError() As Integer
    End Function

    <DllImport("rapi.dll", CharSet:=CharSet.Unicode)> _
    Private Shared Function CeSetEndOfFile(ByVal hFile As Integer) As Integer
    End Function

    <DllImport("rapi.dll", CharSet:=CharSet.Unicode)> _
    Private Shared Function CeGetFileSize(ByVal hFile As Integer, ByVal lpFileSizeHigh As Integer) As Integer
    End Function


    <DllImport("rapi.dll", CharSet:=CharSet.Unicode)> _
    Private Shared Function CeGetLastError() As Integer
    End Function


    <DllImport("rapi.dll", CharSet:=CharSet.Unicode)> _
    Private Shared Function CeCreateProcess(ByVal Filename As String, ByVal param As String, ByVal procAttr As Integer, ByVal threadAttr As Integer, ByVal boolh As Integer, _
        ByVal creFlags As Integer, ByVal env As Integer, ByVal curDir As String, ByVal si As Integer, ByRef pi As PROCESSINFO) As Integer
    End Function

    <DllImport("rapi.dll", CharSet:=CharSet.Unicode)> _
    Private Shared Function CeCreateDirectory(ByVal lpPathName As String, ByVal lpSecurityAttributes As Integer) As Integer
    End Function




    <DllImport("rapi.dll", CharSet:=CharSet.Unicode, SetLastError:=True)> _
    Private Shared Function CeFindFirstFile(ByVal s As String, ByRef results As CE_FIND_DATA) As Integer
    End Function

    Private progBar As ProgressBar
    Private m_infoLabel As Label 'Differ from C#
    Public Delegate Sub CopyFileCallBack(ByVal bytesCopied As Integer, ByVal totalBytes As Integer)

    Public Sub Rapi()

    End Sub

    Private Sub CallBack(ByVal bytesCopied As Integer, ByVal totalBytes As Integer)
        If Not progBar Is Nothing Then
            progressBar.Maximum = totalBytes
            '            progressBar.Value = bytesCopied
        End If
    End Sub

    Public Property progressBar() As ProgressBar
        Get
            Return progBar
        End Get
        Set(ByVal Value As ProgressBar)
            progBar = Value
        End Set
    End Property

    Public Property InfoLabel() As Label
        Get
            Return m_infoLabel
        End Get
        Set(ByVal Value As Label)
            m_infoLabel = Value
        End Set
    End Property
    Public Function PPCConnected() As Boolean
        Dim iConn As Integer
        iConn = CeRapiInit()

    End Function
    Public Function copyFileToPDA(ByVal deskTopFileName As String, ByVal PDAFileName As String) As Boolean
        If Not progressBar Is Nothing Then
            progressBar.Visible = True
        End If
        If Not InfoLabel Is Nothing Then
            InfoLabel.Text = "Copy desktop file: " + deskTopFileName + " to PDA as " + PDAFileName
            InfoLabel.Visible = True
            InfoLabel.Update()
        End If
        Dim b As Boolean = copyFileToPDA(deskTopFileName, PDAFileName, Nothing)
        If Not progressBar Is Nothing Then
            progressBar.Visible = False
        End If
        If Not InfoLabel Is Nothing Then
            InfoLabel.Visible = False
        End If
        Return b
    End Function
    Public Function GetFileCreationTime(ByVal PDAFileName As String) As DateTime
        Dim findData As New CE_FIND_DATA
        CeRapiInit()
        Dim FFileMod As Integer = CeFindFirstFile(PDAFileName, findData)
        CeRapiUninit()
        Return DateTime.FromFileTime(FileTimeToLong(findData.ftCreationTime))
    End Function
    Public Function GetFileModifyTime(ByVal PDAFileName As String) As DateTime
        Dim findData As New CE_FIND_DATA
        CeRapiInit()
        Dim FFileMod As Integer = CeFindFirstFile(PDAFileName, findData)
        CeRapiUninit()
        Return DateTime.FromFileTime(FileTimeToLong(findData.ftLastWriteTime))
    End Function
    Public Function GetFileReadTime(ByVal PDAFileName As String) As DateTime
        Dim findData As New CE_FIND_DATA
        CeRapiInit()
        Dim FFileMod As Integer = CeFindFirstFile(PDAFileName, findData)
        CeRapiUninit()
        Return DateTime.FromFileTime(FileTimeToLong(findData.ftLastAccessTime))
    End Function

    Public Function GetFileSize(ByVal PDAFileName As String) As Integer
        Dim handle As Integer
        CeRapiInit()
        handle = CeCreateFile(PDAFileName, GENERIC_READ, 0, 0, OPEN_EXISTING, FILE_ATTRIBUTE_NORMAL, 0)
        Dim fileSize As Integer = CeGetFileSize(handle, 0)
        CeRapiUninit()
        Return fileSize
    End Function

    Public Function copyFileToDesktop(ByVal deskTopFileName As String, ByVal PDAFileName As String) As Boolean
        If Not progressBar Is Nothing Then
            progressBar.Visible = True
        End If
        If Not InfoLabel Is Nothing Then
            InfoLabel.Text = "Copy PDAfile " + PDAFileName + " to Desktop as " + deskTopFileName
            InfoLabel.Visible = True
            InfoLabel.Update()
        End If
        Dim b As Boolean = copyFileToDesktop(deskTopFileName, PDAFileName, Nothing)

        If Not progressBar Is Nothing Then
            progressBar.Visible = False
        End If
        If Not InfoLabel Is Nothing Then
            InfoLabel.Visible = False
        End If
        Return b

    End Function


    Public Function copyFileToPDA(ByVal deskTopFileName As String, ByVal PDAFileName As String, ByVal cb As CopyFileCallBack) As Boolean
        Dim Handle As Integer
        Dim bufferSize As Integer = &H8000
        Dim lpBuffer() As Byte = New Byte(bufferSize) {}
        Dim lpNumberofBytesWritten As Integer

        Dim pRapiInit As RAPIINIT
        Dim hr As Long

        pRapiInit.cbSize = Len(pRapiInit)
        pRapiInit.heRapiInit = 0
        pRapiInit.hrRapiInit = 0
        hr = E_FAIL

        Try
            hr = CeRapiInit()
        Catch Zx As Exception
            Return False
        End Try

        If hr < 0 Then 'FAILED
            Return False
        End If

        Try
            Handle = CeCreateFile(PDAFileName, GENERIC_READ Or GENERIC_WRITE, 0, 0, CREATE_ALWAYS, FILE_ATTRIBUTE_NORMAL, 0)

            Dim fs As FileStream = New FileStream(deskTopFileName, FileMode.Open, FileAccess.Read)

            Dim fSize As Integer = CType(fs.Length, Integer)
            Dim bytesRead As Integer = 0
            Dim bytesToRead As Integer = bufferSize

            If fSize < bufferSize Then bytesToRead = fSize
            Dim r As BinaryReader = New BinaryReader(fs)

            While (bytesRead < fSize)
                lpBuffer = r.ReadBytes(bytesToRead)
                CeWriteFile(Handle, lpBuffer, bytesToRead, lpNumberofBytesWritten, 0)
                bytesRead += bytesToRead
                If fSize - bytesRead < bufferSize Then bytesToRead = fSize - bytesRead
                If Not cb Is Nothing Then
                    cb(bytesRead, fSize)
                Else
                    CallBack(bytesRead, fSize)
                End If
            End While

            CeCloseHandle(Handle)
            CeRapiUninit()
            r.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        End Try

        Return True

    End Function

    Public Function copyFileToDesktop(ByVal deskTopFileName As String, ByVal PDAFileName As String, ByVal cb As CopyFileCallBack) As Boolean
        Dim Handle As Integer
        Dim bufferSize As Integer = &H8000
        Dim lpBuffer() As Byte = New Byte(bufferSize) {}
        Dim outFile As System.IO.FileStream
        CeRapiInit()

        Try
            outFile = New System.IO.FileStream(deskTopFileName, System.IO.FileMode.Create, System.IO.FileAccess.Write)
            Dim lpNumberofBytesRead As Integer = bufferSize
            Handle = CeCreateFile(PDAFileName, GENERIC_READ, 0, 0, OPEN_EXISTING, FILE_ATTRIBUTE_NORMAL, 0)

            Dim fileSize As Integer = CeGetFileSize(Handle, 0)
            Dim bytesToRead As Integer = bufferSize
            Dim bytesRead As Integer = 0

            While lpNumberofBytesRead > 0
                CeReadFile(Handle, lpBuffer, bytesToRead, lpNumberofBytesRead, 0)
                outFile.Write(lpBuffer, 0, lpNumberofBytesRead)
                bytesRead += lpNumberofBytesRead
                If Not cb Is Nothing Then
                    cb(bytesRead, fileSize)
                Else
                    CallBack(bytesRead, fileSize)
                End If
            End While
            outFile.Close()
            CeCloseHandle(Handle)
        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try
        CeRapiUninit()
        Return True
    End Function
    Public Function CreateDirectory(ByVal Path As String) As Boolean
        CeRapiInit()
        Path = Left(Path, Len(Path) - 1)
        Dim i As Integer = CeCreateDirectory(Path, Nothing)
        CeRapiUninit()
        If i = 0 Then
            Return False
        Else
            Return True
        End If

    End Function

    Public Function RunPDAProgram(ByVal fileName As String, Optional ByVal CmdLine As String = "") As Boolean
        Dim pi As PROCESSINFO
        Dim i As Integer
        CeRapiInit()
        If CmdLine = String.Empty Then
            i = CeCreateProcess(fileName, Nothing, 0, 0, 0, 0, 0, Nothing, 0, pi)
        Else
            'use a command line
            i = CeCreateProcess(fileName, CmdLine, 0, 0, 0, 0, 0, Nothing, 0, pi)
        End If
        CeRapiUninit()

        If (i = 0) Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Function FileTimeToLong(ByVal ft As System.Runtime.InteropServices.ComTypes.FILETIME) As Long


        Dim lo_time As Double
        Dim hi_time As Double
        Dim FTime As Double

        'Low Order Bit
        If ft.dwLowDateTime < 0 Then
            lo_time = 2 ^ 31 + (ft.dwLowDateTime And &H7FFFFFFF)
        Else
            lo_time = ft.dwLowDateTime
        End If

        ' High Order Bit
        If ft.dwHighDateTime < 0 Then
            hi_time = 2 ^ 31 + (ft.dwHighDateTime And _
                &H7FFFFFFF)
        Else
            hi_time = ft.dwHighDateTime
        End If

        FTime = (lo_time + 2 ^ 32 * hi_time)
        FileTimeToLong = FTime
    End Function


    Public FILE_ATTRIBUTE_NORMAL As Short = &H80
    Public Const INVALID_HANDLE_VALUE As Short = -1
    Public GENERIC_READ As Integer = &H80000000
    Public Const GENERIC_WRITE As Integer = &H40000000
    Public Const CREATE_NEW As Short = 1
    Public Const CREATE_ALWAYS As Short = 2
    Public Const OPEN_EXISTING As Short = 3
    Public Const ERROR_FILE_EXISTS As Short = 80
    Public Const ERROR_INVALID_PARAMETER As Short = 87
    Public Const ERROR_DISK_FULL As Short = 112
    Public Const DllName As String = "rapi.dll"
    Public Const MAX_PATH As Integer = 260
    Public Const S_OK As Integer = 0
    Public Const ERROR_SUCCESS As Integer = 0
    Public Const ERROR_NO_MORE_ITEMS As Integer = 259
    Public Const E_FAIL As Integer = &H80004005
    Public Const RAPI_TRUE As Integer = 1
    Public Const RAPI_FALSE As Integer = 0

    <StructLayout(LayoutKind.Sequential, pack:=4, CharSet:=CharSet.Unicode)> _
    Public Structure CE_FIND_DATA
        Public dwFileAttributes As Integer
        Public ftCreationTime As System.Runtime.InteropServices.ComTypes.FILETIME
        Public ftLastAccessTime As System.Runtime.InteropServices.ComTypes.FILETIME
        Public ftLastWriteTime As System.Runtime.InteropServices.ComTypes.FILETIME
        Public nFileSizeHigh As Integer
        Public nFileSizeLow As Integer
        Public dwOID As Integer
        <MarshalAs(UnmanagedType.ByValTStr, sizeConst:=MAX_PATH)> _
        Public cFileName As String
    End Structure
    <StructLayout(LayoutKind.Sequential)> _
    Public Structure OSVERSIONINFO
        Public dwOSVersionInfoSize As Integer
        Public dwMajorVersion As Integer
        Public dwMinorVersion As Integer
        Public dwBuildNumber As Integer
        Public dwPlatformId As Integer
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=128)> _
        Public szCSDVersion As String
    End Structure

    <StructLayout(LayoutKind.Sequential)> _
    Public Structure RAPIINIT
        Dim cbSize As Integer
        Dim heRapiInit As Integer
        Dim hrRapiInit As Integer
    End Structure

    <StructLayout(LayoutKind.Sequential)> _
    Public Structure SECURITY_ATTRIBUTES
        Public nLength As Integer
        Public lpSecurityDescriptor As Integer
        Public bInheritHandle As Integer
    End Structure

    <StructLayout(LayoutKind.Sequential)> _
    Public Structure PROCESSINFO
        Public hProcess As IntPtr
        Public hThread As IntPtr
        Public dwProcessId As IntPtr
        Public dwThreadId As IntPtr
    End Structure


End Class
