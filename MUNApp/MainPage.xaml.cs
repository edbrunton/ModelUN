using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
   public enum votes
    {
        majority, superMajority, no, noObjections
    }
    public class CompleteCommittee
    {
        List<People> peopleList;
        List<CommitteeSession> committeeSession;
        List<ModeratedCaucus> moderatedCaucus;
        List<UnModeratedCaucus> unmodCacus;
        List<LimitsOfDebate> limitsOfDebate;
        List<AgendaItems> agendaItems;
        protected class AgendaItems
        {
            List<Resolution> resolutionsPassed;
            List<Resolution> resolutionsOnFloor;
            List<Resolution> draftResolutions;
            string description;
        }
        protected class Resolution
        {

        }
        protected class ReorderAgendaItems : ProceduralMotion
        {
            List<int> order;
            public ReorderAgendaItems(Country motioningCountry)
            {
                this.name = "Changing the Order of Agenda Items";
                this.motioningCounty = motioningCountry;
                this.second = true;
                this.debatable = false;
                this.voteType = votes.majority;
                this.description = "This motion can be used to change the order in which the topic items are discussed.";
                this.priority = 7;
                this.ruleNumber = 7.7;
            }
        }
        protected class ClosureofDebateOnTopic : ProceduralMotion
        {
            AgendaItems itemToClose;
            public ClosureofDebateOnTopic(Country motioningCountry)
            {
                this.name = "Closure of Debate on a Topic";
                this.motioningCounty = motioningCountry;
                this.second = true;
                this.debatable = true;
                this.voteType = votes.majority;
                this.description = "This motion will close debate on the whole topic area and move the body into voting procedures on all resolutions and amendments on the floor. After voting, the body will then move into the next topic area as specified by the agenda.";
                this.priority = 8;
                this.ruleNumber = 7.8;
            }
        }
        protected class ClosureofDebateOnDraftResolution : ProceduralMotion
        {
            Resolution itemToClose;
            public ClosureofDebateOnDraftResolution(Country motioningCountry)
            {
                this.name = "Closure of Debate on a Resolution";
                this.motioningCounty = motioningCountry;
                this.second = true;
                this.debatable = true;
                this.voteType = votes.majority;
                this.description = "This motion will close debate on a specified resolution and move the body into voting procedures.If the motion passes, the body will vote on the resolution then continue debating the topic area"; 
                this.priority = 9;
                this.ruleNumber = 7.9;
            }
        }
        protected class AdjournmentofMeeting : ProceduralMotion
        {
            public AdjournmentofMeeting(Country motioningCountry)
            {
                this.name = "Adjournment of the Meeting";
                this.motioningCounty = motioningCountry;
                this.second = true;
                this.debatable = false;
                this.voteType = votes.superMajority;
                this.description = "This motion will be accepted when all business of the committee has been completed and that the committee will not reconvene until the next annual session.";
                this.priority = 13;
                this.ruleNumber = 7.14;
            }
        }
        protected class People
        {
            DateTime timeAdded;
        }
        protected class CommitteeSession
        {

        }
        protected class ModeratedCaucus
        {

        }
        protected class ModeratedCaucusMotion : ProceduralMotion
        {
            ModeratedCaucus limitsRaised;
            public ModeratedCaucusMotion(Country motioningCountry)
            {
                this.name = "Moderated Caucus";
                this.motioningCounty = motioningCountry;
                this.second = true;
                this.debatable = true;
                this.voteType = votes.majority;
                this.description = "This motion will suspend formal debate, where the Chairperson recognizes  each speaker. The delegate who  makes the motion must specify the  length of the caucus and the amount  of time each speaker has. ";
                this.priority = 11;
                this.ruleNumber = 7.12;
            }
        }
        protected class UnModeratedCaucus
        {

        }
        protected class UnModeratedCaucusMotion : ProceduralMotion
        {
            UnModeratedCaucus limitsRaised;
            public UnModeratedCaucusMotion(Country motioningCountry)
            {
                this.motioningCounty = motioningCountry;
                this.name = "Unmoderated Caucus";
                this.second = true;
                this.debatable = false;
                this.voteType = votes.majority;
                this.description = "This motion will suspend formal debate for a specified time for informal negotiations and discussions.";
                this.priority = 10;
                this.ruleNumber = 7.11;
            }
        }
        protected class LimitsOfDebate
        {
            int pointsOfInquiry;
            double speakingTime;
            public LimitsOfDebate(int pointsOfInquiry, double speakingTime)
            {
                if (pointsOfInquiry < 2)
                {
                    this.pointsOfInquiry = 2;
                }
                else
                {
                    this.pointsOfInquiry = pointsOfInquiry;
                }
                if (speakingTime < 3)
                {
                    this.speakingTime = 3;
                }
                else
                {
                    this.speakingTime = speakingTime;
                }
            }
        }
        protected class LimitsOfDebateMotion: ProceduralMotion
        {
            LimitsOfDebate limitsRaised;
            public LimitsOfDebateMotion(Country motioningCountry)
            {
                this.motioningCounty = motioningCountry;
                this.name = "Limits on Debate";
                this.second = true;
                this.debatable = true;
                this.voteType = votes.majority;
                this.description = "This motion may be used to place limits on debate for speaking time and number of Points of Inquiry";
                this.priority = 5;
                this.ruleNumber = 7.3;
             }
        }
        protected class SupsensionoftheMeeting
        {

        }
        protected class SupsensionoftheMeetingMotion : ProceduralMotion
        {
            SupsensionoftheMeeting supsension;
            public SupsensionoftheMeetingMotion(Country motioningCountry)
            {
                this.motioningCounty = motioningCountry;
                this.name = "Suspension of the meeting";
                this.second = true;
                this.debatable = false;
                this.voteType = votes.majority;
                this.description = "This motion will suspend formal debate for a specified amount of time, usually to closing debate for the day or for lunch.";
                this.priority = 6;
                this.ruleNumber = 7.4;
            }
        }
        protected class SubmissionofProposal : Rule
        {
            public SubmissionofProposal(Country countrySubmitting)
            {
                this.name = "Suspension of the meeting";
                this.second = false;
                this.debatable = false;
                this.voteType = votes.no;
                this.description = "This is not a motion, but rather the act of bringing your resolution to the dais staff. You will submit the resolution and it will be checked for formatting and content. Once checking is complete, the Chairperson will then inform the body that a delegate can motion for consideration of draft resolution (9.3).";
                this.priority = 14;
                this.ruleNumber = 9.2;
            }
        }
        protected class Country
        {
            string name;
            People person;
            public string Name { get => name; set => name = value; }
        }
        protected class Rule
        {
            protected bool debatable;
            protected bool second;
            protected votes voteType;
            protected string description;
            protected double ruleNumber;
            protected string name;
            protected string shortResponse;
            protected string chairScriptResponse;
            protected string longFormRule;
            protected int priority;
            public Rule()
            {

            }
            public Rule(bool second, bool debatable, votes voteType, string description)
            {
                this.second = second;
                this.debatable = debatable;
                this.voteType = voteType;
                this.description = description;
            }
        }
        protected class Point: Rule
        {

            protected Country motioningCounty;
            public Point()
            {
                voteType = votes.no;
                debatable = false;
                second = false;
            }
        }
        protected class PointOfOrder: Point
        {
              public PointOfOrder(Country aCountry)
            {
                motioningCounty = aCountry;
                name = "Point of Order";
                shortResponse = String.Format("On Order {0}", aCountry.Name);
                description = "This point should be used when a delegate believes that the body is proceeding contrary to the rules.";
                ruleNumber = 8.1;
                priority = 1;
            }
          /*  public PointOfOrder()
            {
                name = "Point of Order";
                response = "On Order";
                description = "This point should be used when a delegate believes that the body is proceeding contrary to the rules.";
                ruleNumber = 8.1;
            }*/
}
protected class PointOfInformation : Point
        {
            public PointOfInformation(Country aCountry)
            {
                name = "Point of Information";
                shortResponse = String.Format("On Information {0}", aCountry.Name);
                description = "This point should be used when a delegate is unsure of the correct proceedings, rules, or any other information the chair can provide.";
                ruleNumber = 8.2;
                priority = 2;
            }
        }
        protected class PointOfInquiry : Point
        {
            public PointOfInquiry(Country aCountry)
            {
                name = "Point of Inquiry";
                shortResponse = String.Format("On Inquiry {0}", aCountry.Name);
                description = "After a delegate has yielded time to Points of Inquiry or questions, delegate may be recognized to ask a Point of Inquiry to the speaker.";
                ruleNumber = 8.3;
                priority = 3;
            }
        }
        protected class DiplomaticCourtesy : Point
        {
            public DiplomaticCourtesy(Country aCountry)
            {
                name = "Diplomatic Courtesy";
                shortResponse = String.Format("On Diplomatic Courtesy {0}", aCountry.Name);
                description = "Delegates must exercise diplomatic courtesy to all other delegates and secretariat members at all times.";
                ruleNumber = 7.1;
                priority = 4;
            }
        }
        protected class ProceduralMotion: Rule
        {
            protected Country motioningCounty;
            public ProceduralMotion()
            {
            }
        }
        protected class Seat
        {

        }
        
    }
    public sealed partial class MainPage : Page
    {
        CompleteCommittee CompleteCommittee;
        public MainPage()
        {
            this.InitializeComponent();
            if(!(Convert.ToString(ApplicationData.Current.RoamingSettings.Values["openTimes"]) == ""))
            {

            }
            string path = @"c:\temp\MyTest.txt";
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
                   // Console.WriteLine(s);
                }
            }

        }

        private async System.Threading.Tasks.Task BeginBtn_ClickAsync(object sender, RoutedEventArgs e)
        {
            var dialog = new MessageDialog("You are about to over write all previous committees, do you wish to proceed?", "WARNING");
            dialog.Commands.Add(new UICommand("Yes, Overwrite Old Data", new UICommandInvokedHandler(reviewOutCome)));
            dialog.Commands.Add(new UICommand("Abort", new UICommandInvokedHandler(reviewOutCome)));
           // dialog.Commands.Add(new UICommand(translate("Never"), new UICommandInvokedHandler(reviewOutCome)));
            dialog.DefaultCommandIndex = 0;
            dialog.CancelCommandIndex = 1;
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

        }
    }
    
}
