using System;
using System.Collections.Generic;
using Vipets.Models;
using Vipets.Services;
using Vipets.Util;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Vipets.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewEmployeePage : ContentPage
    {
        public NewEmployeePage()
        {
            InitializeComponent();
        }

        private void SaveClicked(object sender, EventArgs e)
        {
            try
            {
                SaveEmployee();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private async void SaveEmployee()
        {
            var result = await VipetsApiClient.CurrentUsers.SaveEmployee(GetEmployee());
            if (!result.Success)
            {
                await DisplayAlert("ERROR", "Error saving data", "OK");
                CleanFields();
                return;
            }
            else
            {
                await DisplayAlert("Success", "New Employee saved successfully!", "OK");
            }
        }

        private User GetEmployee()
        {
            User employee = new User();
            employee.email = employeeEmail.Text;
            employee.name = employeeName.Text;
            employee.surname = employeeSurname.Text;
            employee.petshops = new List<Petshop>() { Singleton<AppProperties>.Instance().GetLoggedUser().PetshopSession };
            return employee;
        }


        private void CleanFields()
        {
            employeeEmail.Text = string.Empty;
            employeeName.Text = string.Empty;
            employeeSurname.Text = string.Empty;
        }

    }
}