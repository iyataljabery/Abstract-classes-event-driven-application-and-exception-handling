//Created by Ethan Jones, 03-13-2025, This searchs for flights from Orgin, destination and day.

using System;
using System.Collections.Generic;
using System.Windows.Forms;

public partial class FindFlightsForm : Form
{
    public FindFlightsForm()
    {
        InitializeComponent();
    }

    private void btnSearch_Click(object sender, EventArgs e)
    {
        string origin = cmbOrigin.SelectedItem?.ToString();
        string destination = cmbDestination.SelectedItem?.ToString();
        string day = cmbDay.SelectedItem?.ToString();

        if (string.IsNullOrEmpty(origin) || string.IsNullOrEmpty(destination) || string.IsNullOrEmpty(day))
        {
            MessageBox.Show("Please select all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        List<Flight> flights = FlightManager.FindFlights(origin, destination, day);
        lstFlights.Items.Clear();

        foreach (var flight in flights)
        {
            ListViewItem item = new ListViewItem(new[]
            {
                flight.Code, flight.Airline, flight.Day, flight.Time, flight.Cost.ToString("C")
            });
            lstFlights.Items.Add(item);
        }
    }
}
