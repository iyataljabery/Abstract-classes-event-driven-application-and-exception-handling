// Made by Ethan Jones, 03-13-2025, This is the Main menu with navigation buttons

using System;
using System.Windows.Forms;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();
    }

    private void btnFindFlights_Click(object sender, EventArgs e)
    {
        new FindFlightsForm().Show();
    }

    private void btnMakeReservation_Click(object sender, EventArgs e)
    {
        new MakeReservationForm().Show();
    }

    private void btnFindReservations_Click(object sender, EventArgs e)
    {
        new FindReservationsForm().Show();
    }

    private void btnModifyReservation_Click(object sender, EventArgs e)
    {
        new ModifyReservationForm().Show();
    }

    private void btnExit_Click(object sender, EventArgs e)
    {
        Application.Exit();
    }
}
