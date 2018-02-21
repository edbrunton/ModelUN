using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MUNApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /*string path = @"c:\temp\MyTest.txt";
        if (!File.Exists(path))
        {
            // Create a file to write to.
            using (StreamWriter sw = File.CreateText(path))
            {
                sw.WriteLine("Hello");
                sw.WriteLine("And");
                sw.WriteLine("Welcome");
            }
        }

        // Open the file to read from.
        using (StreamReader sr = File.OpenText(path))
        {
            string s = "";
            while ((s = sr.ReadLine()) != null)
            {
                Console.WriteLine(s);
            }
        }
*/
    static class mySharedData{
        static CompleteCommittee myCommittee;
        public static CompleteCommittee MyCommittee { get => myCommittee; set => myCommittee = value; }
    }
   public enum votes
    {
        majority, superMajority, no, noObjections
    }
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {

            CompleteCommittee temp = mySharedData.MyCommittee;
            if (temp == null)
            {
                mySharedData.MyCommittee= temp = new CompleteCommittee();
            }
           
            
            this.InitializeComponent();           

        }

        private async System.Threading.Tasks.Task BeginBtn_ClickAsync(object sender, RoutedEventArgs e)
        {
            var dialog = new MessageDialog("You are about to over write all previous committees, do you wish to proceed?", "WARNING");
            dialog.Commands.Add(new UICommand("Yes, Overwrite Old Data", new UICommandInvokedHandler(reviewOutCome)));
            dialog.Commands.Add(new UICommand("Abort", new UICommandInvokedHandler(reviewOutCome)));
           // dialog.Commands.Add(new UICommand(translate("Never"), new UICommandInvokedHandler(reviewOutCome)));
            dialog.DefaultCommandIndex = 0;
            dialog.CancelCommandIndex = 1;

            /*  string path = @"MyTest.txt";
              if (!File.Exists(path))
              {
                  // Create a file to write to.
                  using (StreamWriter sw = File.CreateText(path))
                  {
                      sw.WriteLine("Hello");
                      sw.WriteLine("And");
                      sw.WriteLine("Welcome");
                  }
              }

              //Open the file to read from.
              using (StreamReader sr = File.OpenText(path))
              {
                  string s = "";
                  while ((s = sr.ReadLine()) != null)
                  {
                      // Console.WriteLine(s);
                  }
              }*/

       /*  string test = "Testing 1-2-3";

            // convert string to stream
            byte[] byteArray = Encoding.ASCII.GetBytes(test);
            MemoryStream stream = new MemoryStream(byteArray);

            // convert stream to string
            StreamReader reader = new StreamReader(stream);
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(stream))
            {
                file.WriteLine("Hello world");
            }*/
            await dialog.ShowAsync();
                
            }
        private void reviewOutCome(IUICommand command)
        {
            if(command.Label.CompareTo("Yes, Overwrite Old Data") == 0)
            {
                this.Frame.Navigate(typeof(CommitteePage));
            }
        }
        private void beginBtn_Click(object sender, RoutedEventArgs e)
        {
            BeginBtn_ClickAsync(sender, e);
        }
        private void resumeBtn_Click(object sender, RoutedEventArgs e)
        {

        }
        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(EditPage));
        }
    }
    
}
