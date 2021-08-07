Imports System.Data.OleDb
Imports msyql.data
Imports MySql.Data.MySqlClient
Imports Microsoft.VisualBasic.ApplicationServices
Imports Microsoft.Win32

Public Class Form1

    Dim sqlConn As New MySqlConnection
    ' Public conn As New MySqlConnection("host=localhost;user=root;password=;port=3306;")
    Dim sqlCmd As New MySqlCommand
    Dim sqlRd As MySqlDataReader

    Dim sqlDt As New DataTable
    Dim DtA As New MySqlDataAdapter

    Dim server As String = "127.0.0.1"
    Dim username As String = "root"
    Dim password As String = ""
    Dim database As String = "myconnectorvb"

    Private bitmap As Bitmap ' for printing

    Private Sub updateTable()
        sqlConn.ConnectionString = "server=" & server & ";user id=" & username & ";" &
            "password=" & password & ";database=" & database & ""


        Dim connStr As String = "Server=127.0.0.1;Database=myconnectorvb;Uid=root;Pwd=;SslMode=none"
        Dim conn As New MySqlConnection(connStr)
        Try

            'sqlConn.Open()
            'conn.Open()
            'sqlCmd.Connection = sqlConn
            'sqlCmd.Connection = conn

            conn.Open()
            sqlCmd.Connection = conn
            sqlCmd.CommandText = "SELECT * From myconnectorvb"
            sqlRd = sqlCmd.ExecuteReader

            sqlDt.Load(sqlRd)

            sqlRd.Close()

            'sqlConn.Close()
            'conn.Close()


            DataGridView1.DataSource = sqlDt
        Catch ex As Exception

            MsgBox("error could Not connect to database " + ex.Message, MsgBoxStyle.Exclamation
                   )

        End Try




    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        updateTable()
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Dim iExit As DialogResult
        iExit = MsgBox("Confirm if you want to exit", MsgBoxStyle.YesNo)

        If iExit = vbYes Then
            Application.Exit()
        Else
            Exit Sub
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class
