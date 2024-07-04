using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Maui;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net.NetworkInformation;

public class StaffContactDirectory
{
    private readonly string _connectionString;

    public StaffContactDirectory(string connectionString)
    {
        _connectionString = connectionString;
    }
    
}

namespace StaffDirectory
{
    public partial class MainPage : ContentPage
    {
        private StaffContactDirectory directory;

        public MainPage()
        {
            InitializeComponent();
            directory = new StaffContactDirectory(); // Initialize StaffContactDirectory instance
            LoadStaff(); // Load staff members initially
        }

        private void LoadStaff()
        {
            var staffList = directory.GetStaff(); // Get list of staff members from database
            staffListView.ItemsSource = staffList; // Set ListView's ItemsSource to the list of staff
        }
        public void UpdateStaff(Staff staff)
        {

        }

        private void AddStaff_Clicked(object sender, EventArgs e)
        {
            Staff newStaff = new Staff
            {
                Name = nameEntry.Text,
                Phone = phoneEntry.Text,
                Department = departmentEntry.Text,
                AddressStreet = streetEntry.Text,
                AddressCity = cityEntry.Text,
                AddressState = stateEntry.Text,
                AddressZip = zipEntry.Text,
                AddressCountry = countryEntry.Text
            };

            directory.AddStaff(newStaff); // Add new staff member to the database
            LoadStaff(); // Reload the ListView with updated staff list
        }

        private void UpdateStaff_Clicked(object sender, EventArgs e)
        {
            if (staffListView.SelectedItem != null)
            {
                Staff selectedStaff = (Staff)staffListView.SelectedItem;
                selectedStaff.Name = nameEntry.Text;
                selectedStaff.Phone = phoneEntry.Text;
                selectedStaff.Department = departmentEntry.Text;
                selectedStaff.AddressStreet = streetEntry.Text;
                selectedStaff.AddressCity = cityEntry.Text;
                selectedStaff.AddressState = stateEntry.Text;
                selectedStaff.AddressZip = zipEntry.Text;
                selectedStaff.AddressCountry = countryEntry.Text;

                UpdateStaff(selectedStaff); // Update selected staff member in the database
                LoadStaff(); // Reload the ListView with updated staff list
            }
        }

        private void DeleteStaff_Clicked(object sender, EventArgs e)
        {
            if (staffListView.SelectedItem != null)
            {
                Staff selectedStaff = (Staff)staffListView.SelectedItem;
                directory.DeleteStaff(selectedStaff.Id); // Delete selected staff member from the database
                LoadStaff(); // Reload the ListView with updated staff list
            }
        }
    }
}








