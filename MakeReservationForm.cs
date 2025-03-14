//Created by Elliot Jost 03/13/2025 Creating a reservation for a flight

using System;
using System.Collections.Generic;
using System.Windows.Forms;

//A reservation code is generated and assigned to the traveller’s name and citizenship. 

public partial class MakeReservationForm : Form
{
	public MakeReservationForm()
	{
        InitializeComponent();
	}
}

private void MakeReservationClicked(object sender, EventArgs e)
{
	string selectedFlight = Flight flight;
	string name = name;
	string citizenship = ;

	try
	{
		var reservation = ReservationManager.MakeReservation(selectedFlight, name, citizenship);
        MessageBox.Show($"Reservation Successful!\nReservation Code: {ReservationManager}");

    }
    catch (Exception ex)
	{
        MessageBox.Show();
    }
}