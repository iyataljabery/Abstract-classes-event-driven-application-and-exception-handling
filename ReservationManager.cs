//Created by Elliot Jost 03/13/2025 Create reservation codes and save, load and update reservation file

using System;

public class Reservation
{
    public string reservationCode { get; set; }
    public string travellerName { get; set; }
    public string citizenship { get; set; }
    public Flight flight { get; set; }
    public bool isActive { get; set; }
}

public class ReservationManager
{
    private static List<Reservation> reservations = new List<Reservation>();
    private static Random random = new Random();
    private const string FilePath = "reservations.dat";

    private static string createReservationCode()
    {
        char letter = (char)('A' + random.Next(0, 26));
        int numbers = random.Next(1000, 9999);
        return $"{letter}{numbers}"; 
    }

    private static Reservation MakeReservation(Flight flight, string name, string citizenship)
    {
        if (flight == null)
            throw new ArgumentException("No flight selected.");
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Traveller name cannot be empty.");
        if (string.IsNullOrWhiteSpace(citizenship))
            throw new ArgumentException("Citizenship cannot be empty.");
        if (flight.AvailableSeats = 0)
            throw new InvalidOperationException("Flight is fully booked.");

        string reservationCode = createReservationCode();
        Reservation newReservation = new Reservation(reservationCode, name, citizenship, flight, true);
        reservations.Add(newReservation);
        flight.availableSeats--;
        saveReservations();
        return newReservation;
    }
}

public static void UpdateReservation(string reservationCode, string newName, string newCitizenship, bool isActive)
{
    LoadReservations();
    var reservation = reservations.Find(res => res.reservationCode == reservationCode);
    if (reservation != null)
    {
        reservation.name = newName;
        reservation.citizenship = newCitizenship;
        reservation.isActive = isActive;
        SaveReservations();
    }
    else
    {
        throw new Exception("Reservation not found.");
    }
}

private static void SaveReservations()
{
    using (FileStream fs = new FileStream(FilePath, FileMode.Create))
    using (BinaryWriter writer = new BinaryWriter(fs))
    {
        foreach (var res in reservations)
        {
            writer.Write(res.ReservationCode);
            writer.Write(res.TravellerName);
            writer.Write(res.Citizenship);
            writer.Write(res.Flight.FlightCode);
            writer.Write(res.IsActive);
        }
    }
}

private static void LoadReservations()
{
    if (!File.Exists(FilePath)) return;
    reservations.Clear();
    using (FileStream fs = new FileStream(FilePath, FileMode.Open))
    using (BinaryReader reader = new BinaryReader(fs))
    {
        while (fs.Position < fs.Length)
        {
            var reservation = new Reservation
            {
                ReservationCode = reader.ReadString(),
                TravellerName = reader.ReadString(),
                Citizenship = reader.ReadString(),
                Flight = new Flight { FlightCode = reader.ReadString() },
                IsActive = reader.ReadBoolean()
            };
            reservations.Add(reservation);
        }
    }
}