Imports System.Data.SqlClient ' Importa namespace para SQL Server

Public Class Form1
    ' Evento do botão que carregará os dados
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        CarregarDados() ' Carrega dados no DataGridView
    End Sub

    ' Método para carregar dados no DataGridView
    Private Sub CarregarDados()
        Dim connString As String = "Data Source=localhost;Initial Catalog=Financeiro;Integrated Security=True"
        Dim query As String = "SELECT * FROM Transacoes"

        Using conn As New SqlConnection(connString)
            Try
                conn.Open()
                Dim adapter As New SqlDataAdapter(query, conn)
                Dim tabela As New DataTable()
                adapter.Fill(tabela)
                DataGridView1.DataSource = tabela ' Exibe a tabela no DataGridView
            Catch ex As Exception
                MessageBox.Show("Erro ao carregar os dados: " & ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    ' Botão para adicionar um registro ao banco de dados
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim connString As String = "Data Source=localhost;Initial Catalog=Financeiro;Integrated Security=True"
        Dim query As String = "INSERT INTO Transacoes (Nome, CPF, Valor, DataTransacao, Descricao, TipoTransacao) VALUES (@Nome, @CPF, @Valor, @DataTransacao, @Descricao, @TipoTransacao)"

        Using conn As New SqlConnection(connString)
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@Nome", TextBox1.Text)
                cmd.Parameters.AddWithValue("@CPF", TextBox2.Text)
                cmd.Parameters.AddWithValue("@Valor", Convert.ToDecimal(TextBox3.Text))
                cmd.Parameters.AddWithValue("@DataTransacao", Convert.ToDateTime(TextBox4.Text)) ' Converte a data corretamente
                cmd.Parameters.AddWithValue("@Descricao", TextBox6.Text)
                cmd.Parameters.AddWithValue("@TipoTransacao", TextBox5.Text)

                Try
                    conn.Open()
                    cmd.ExecuteNonQuery()
                    MessageBox.Show("Registro adicionado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    CarregarDados() ' Atualiza o DataGridView
                Catch ex As Exception
                    MessageBox.Show("Erro ao adicionar o registro: " & ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
    End Sub

    ' Botão para editar um registro selecionado no DataGridView
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If DataGridView1.SelectedRows.Count = 0 Then
            MessageBox.Show("Selecione um registro para editar!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim id As Integer = Convert.ToInt32(DataGridView1.SelectedRows(0).Cells("ID").Value)
        Dim connString As String = "Data Source=localhost;Initial Catalog=Financeiro;Integrated Security=True"
        Dim query As String = "UPDATE Transacoes SET Nome = @Nome, CPF = @CPF, Valor = @Valor, DataTransacao = @DataTransacao, TipoTransacao = @TipoTransacao WHERE ID = @ID"

        Using conn As New SqlConnection(connString)
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@Nome", TextBox1.Text)
                cmd.Parameters.AddWithValue("@CPF", TextBox2.Text)
                cmd.Parameters.AddWithValue("@Valor", Convert.ToDecimal(TextBox3.Text))
                cmd.Parameters.AddWithValue("@DataTransacao", Convert.ToDateTime(TextBox4.Text))
                cmd.Parameters.AddWithValue("@Descricao", TextBox5.Text)
                cmd.Parameters.AddWithValue("@TipoTransacao", TextBox5.Text)
                cmd.Parameters.AddWithValue("@ID", id)

                Try
                    conn.Open()
                    cmd.ExecuteNonQuery()
                    MessageBox.Show("Registro editado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    CarregarDados() ' Atualiza o DataGridView
                Catch ex As Exception
                    MessageBox.Show("Erro ao editar o registro: " & ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
    End Sub

    ' Botão para excluir um registro selecionado no DataGridView
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If DataGridView1.SelectedRows.Count = 0 Then
            MessageBox.Show("Selecione um registro para excluir!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim id As Integer = Convert.ToInt32(DataGridView1.SelectedRows(0).Cells("ID").Value)
        Dim connString As String = "Data Source=localhost;Initial Catalog=Financeiro;Integrated Security=True"
        Dim query As String = "DELETE FROM Transacoes WHERE ID = @ID"

        Using conn As New SqlConnection(connString)
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@ID", id)

                Try
                    conn.Open()
                    cmd.ExecuteNonQuery()
                    MessageBox.Show("Registro excluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    CarregarDados() ' Atualiza o DataGridView
                Catch ex As Exception
                    MessageBox.Show("Erro ao excluir o registro: " & ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
    End Sub

End Class
