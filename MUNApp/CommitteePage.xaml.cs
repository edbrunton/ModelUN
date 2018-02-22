using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using static MUNApp.CompleteCommittee;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MUNApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CommitteePage : Page
    {
        public CommitteePage()
        {
            this.InitializeComponent();
            try
            {
                AgendaItems currentTopic = mySharedData.MyCommittee.AgendaItems1[0];
                currentTopicBlock.Text = currentTopic.Description;

            }
            catch (Exception)
            {
                currentTopicBlock.Text = "Warning: no info loaded!";
             //   throw;
            }
            
                string temp = PointOfOrder.GetInfo();
            List<Button> list = new List<Button>();
            button0.Content = (new TextBlock().Text = PointOfOrder.GetInfo());
            button1.Content = PointOfInformation.GetInfo();
            button2.Content = PointOfInquiry.GetInfo();
            button3.Content = DiplomaticCourtesy.GetInfo();
            button4.Content = LimitsOfDebateMotion.GetInfo();
            button5.Content = SupsensionoftheMeetingMotion.GetInfo();
            button6.Content = ReorderAgendaItems.GetInfo();
            button7.Content = ClosureofDebateOnTopic.GetInfo();
            button8.Content = ClosureofDebateOnDraftResolution.GetInfo();
            button9.Content = UnModeratedCaucusMotion.GetInfo();
            button10.Content = ModeratedCaucusMotion.GetInfo();
            button11.Content = AdjournmentofMeeting.GetInfo();
            button12.Content = SubmissionofProposal.GetInfo();
            button13.Content = ConsiderationofDraftResolution.GetInfo();
            button14.Content = ConsiderationofUnfriendlyAmendment.GetInfo();
            button14.Content = ConsiderationofFriendlyAmendment.GetInfo();
            button15.Content = AddanAgendaTopic.GetInfo();
            button16.Content = "Go Back";
            button17.Content = "Vote on Motions";
            button18.Content = "View Available Amendments";
            button19.Content = "View Available Resolutions";

        }

        private void button0_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button7_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button8_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button9_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button10_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button11_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button12_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button13_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button14_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button15_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button16_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button17_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button18_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button19_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
