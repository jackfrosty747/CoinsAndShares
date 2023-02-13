Namespace Dashboard
    Friend Class UDashboard : Implements IDataRefresh

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

        End Sub

        Friend Sub Initialise(commonObjects As CCommonObjects)

            For Each c In Controls
                Dim dashboardPanel = TryCast(c, IDashboardPanel)
                If dashboardPanel IsNot Nothing Then
                    dashboardPanel.Initialise(commonObjects)
                End If
            Next

        End Sub

        Private Sub RefreshData() Implements IDataRefresh.RefreshData

            If Not Visible Then
                Return
            End If

            For Each c In Controls
                Dim dashboardPanel = TryCast(c, IDashboardPanel)
                If dashboardPanel IsNot Nothing Then
                    dashboardPanel.RefreshData()
                End If
            Next

        End Sub

        Private Sub BtnHideDashboard_Click(sender As Object, e As EventArgs) Handles BtnHideDashboard.Click
            Hide()
        End Sub

        Private Sub UCurrency1_Load(sender As Object, e As EventArgs) Handles UCurrency1.Load

        End Sub
    End Class

End Namespace

