using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FormAssistControl.Model.Entities;
using FormAssistControl.View;
using FormAssistControl.ViewModel;
using Xamarin.Forms;

namespace FormAssistControl
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = new StudentDirectoryVM();

            lvStudents.ItemSelected += LvStudentsOnItemSelected;
        }

        private void LvStudentsOnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Student selectedStudent = (Student) e.SelectedItem;
            if (selectedStudent == null)
                return;

            Navigation.PushAsync(new StudentDetailPage(selectedStudent));
            lvStudents.SelectedItem = null;
        }
    }
}
