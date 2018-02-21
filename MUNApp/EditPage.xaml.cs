using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using MUNApp;
using static MUNApp.CompleteCommittee;
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MUNApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class EditPage : Page
    {
        string delegateName = "Delegate Name";
        string countryName = "Country Name";
        string highSchool = "High School";
        public EditPage()
        {
           
            this.InitializeComponent();
            //    ItemCollection temp = mainGrid.IsItemsHost;

            List<CompleteCommittee.Country> members = mySharedData.MyCommittee.CountryList;
            string completetext = delegateName + "," +  countryName + "," + highSchool;
            for(int i =0; i< members.Count; i ++)
            {
                string title = members[i].Name + "," + members[i].Person.Name + "," + members[i].Person.School + "\n";
                completetext += title;  
            }
            inputBox.Document.SetText(Windows.UI.Text.TextSetOptions.None, completetext);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            inputBox.Document.GetText(Windows.UI.Text.TextGetOptions.AdjustCrlf, out string completetext);
            int indexName = completetext.IndexOf(delegateName);
            int indexCountry = completetext.IndexOf(countryName);
            int indexSchool = completetext.IndexOf(highSchool);
            List<int> items = new List<int>();
            items.Add(indexName);
            items.Add(indexCountry);
            items.Add(indexSchool);
            items.Sort();
            int realNameIndex = items.IndexOf(indexName);
            int realCountryIndex = items.IndexOf(indexCountry);
            int realSchoolIndex= items.IndexOf(indexSchool);
            List<People> peopleList = new List<People>();
            List<Country> countryList = new List<Country>();
            string[] lines = completetext.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
            int i = 0;
            while(!lines[i].Contains(delegateName))
            {
                i++;
            }
            i++;
            for (int k = i;  k< lines.Length; k++)
            {
                string[] parts = lines[k].Split(new[] { "," }, StringSplitOptions.None);
                if(parts.Length == 3)
                {
                    People temp = new People(parts[realNameIndex], parts[realSchoolIndex], new Country(parts[realCountryIndex]));
                    temp.Country.Person = temp;
                    peopleList.Add(temp);
                    countryList.Add(temp.Country);
                }
            }
            mySharedData.MyCommittee.CountryList = countryList;
            mySharedData.MyCommittee.PeopleList = peopleList;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
    }
}
