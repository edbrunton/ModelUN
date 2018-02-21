using System;
using System.Collections.Generic;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MUNApp
{
    public class CompleteCommittee
    {
        private List<Country> countryList;
        private List<CommitteeSession> committeeSession;
        private List<ModeratedCaucus> moderatedCaucus;
        private List<UnModeratedCaucus> unmodCacus;
        private List<LimitsOfDebate> limitsOfDebate;
        private List<AgendaItems> agendaItems;
        
        public CompleteCommittee(List<Country> countryList, List<CommitteeSession> committeeSession, List<ModeratedCaucus> moderatedCaucus, List<UnModeratedCaucus> unmodCacus, List<LimitsOfDebate> limitsOfDebate, List<AgendaItems> agendaItems)
        {
            this.countryList = countryList;
            this.committeeSession = committeeSession;
            this.moderatedCaucus = moderatedCaucus;
            this.unmodCacus = unmodCacus;
            this.limitsOfDebate = limitsOfDebate;
            this.agendaItems = agendaItems;
        }
        public CompleteCommittee()
        {
            this.countryList = new List<Country>();
            this.committeeSession = new List<CommitteeSession>();
            this.moderatedCaucus = new List<ModeratedCaucus>();
            this.unmodCacus = new List<UnModeratedCaucus>();
            this.limitsOfDebate = new List<LimitsOfDebate>();
            this.agendaItems = new List<AgendaItems>();
        }
        public List<CommitteeSession> CommitteeSession1 { get => committeeSession; set => committeeSession = value; }
        public List<ModeratedCaucus> ModeratedCaucus1 { get => moderatedCaucus; set => moderatedCaucus = value; }//todo: make all subclasses public
        public List<UnModeratedCaucus> UnmodCacus { get => unmodCacus; set => unmodCacus = value; }
        public List<LimitsOfDebate> LimitsOfDebate1 { get => limitsOfDebate; set => limitsOfDebate = value; }
        public List<AgendaItems> AgendaItems1 { get => agendaItems; set => agendaItems = value; }
        public List<Country> CountryList { get => countryList; set => countryList = value; }
        public List<People> PeopleList { get; internal set; }

        public class AgendaItems
        {
            List<Resolution> resolutionsPassed;
            List<Resolution> resolutionsOnFloor;
            List<Resolution> draftResolutions;
            string description;

            public string Description { get => description; set => description = value; }
        }
        public class Resolution
        {

        }
        public class ReorderAgendaItems : ProceduralMotion
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
            public static string GetInfo()
            {
                return (new ReorderAgendaItems(new Country("fake"))).name;
            }
        }
        public class ClosureofDebateOnTopic : ProceduralMotion
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
            public static string GetInfo()
            {
                return (new ClosureofDebateOnTopic(new Country("fake"))).name;
            }
        }
        public class ClosureofDebateOnDraftResolution : ProceduralMotion
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
            public static string GetInfo()
            {
                return (new ClosureofDebateOnDraftResolution(new Country("fake"))).name;
            }
        }
        public class AdjournmentofMeeting : ProceduralMotion
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
            public static string GetInfo()
            {
                return (new AdjournmentofMeeting(new Country("fake"))).name;
            }
        }
        public class People
        {
            string name;
            string school;
            Country country;

            public People(string name, string school, Country country)
            {
                this.name = name;
                this.school = school;
                this.country = country;
            }

            public string School { get => school; set => school = value; }
            public string Name { get => name; set => name = value; }
            public Country Country { get => country; set => country = value; }
           
        }
        public class CommitteeSession
        {

        }
        public class ModeratedCaucus
        {

        }
        public class ModeratedCaucusMotion : ProceduralMotion
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
            public static string GetInfo()
            {
                return (new ModeratedCaucusMotion(new Country("fake"))).name;
            }
        }
        public class UnModeratedCaucus
        {

        }
        public class UnModeratedCaucusMotion : ProceduralMotion
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
            public static string GetInfo()
            {
                return (new UnModeratedCaucusMotion(new Country("fake"))).name;
            }

        }
        public class LimitsOfDebate
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
        public class LimitsOfDebateMotion: ProceduralMotion
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
            public static string GetInfo()
            {
                return (new LimitsOfDebateMotion(new Country("fake"))).name;
            }
        }
        public class SuspensionoftheMeeting
        {

        }
        public class SupsensionoftheMeetingMotion : ProceduralMotion
        {
            SuspensionoftheMeeting supsension;
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
            public static string GetInfo()
            {
                return (new SupsensionoftheMeetingMotion(new Country("fake"))).name;
            }
        }
        public class SubmissionofProposal : Rule
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
            public static string GetInfo()
            {
                return (new SubmissionofProposal(new Country("fake"))).name;
            }
        }
        public class ConsiderationofDraftResolution : Rule
        {
            public ConsiderationofDraftResolution(Country countrySubmitting)
            {
                this.name = "Consideration of Draft Resolution";
                this.second = true;
                this.debatable = false;
                this.voteType = votes.majority;
                this.description = "Following the draft resolution’s submission to the dais and after it has been distributed to the body, this motion allows the body to officially begin substantive debate on it. If the motion passes the sponsors of the resolution will be invited to explain the resolution to the body and take Points of Inquiry.";
                this.priority = 15;
                this.ruleNumber = 9.3;
            }
            public static string GetInfo()
            {
                return (new ConsiderationofDraftResolution(new Country("fake"))).name;
            }
        }
        public class ConsiderationofUnfriendlyAmendment : Rule
        {
            public ConsiderationofUnfriendlyAmendment(Country countrySubmitting)
            {
                this.name = "Consideration of Unfriendly Amendments";
                this.second = true;
                this.debatable = false;
                this.voteType = votes.majority;
                this.description = "This motion will be entertained after the Chairperson approves the amendment via rule 9.2. The Chairperson will then present the amendment to the body, this must be completed before closure of debate is motioned for, Rule 7.9 or 7.10.";
                this.priority = 16;
                this.ruleNumber = 9.4;
            }
            public static string GetInfo()
            {
                return (new ConsiderationofUnfriendlyAmendment(new Country("fake"))).name;
            }
        }
        public class ConsiderationofFriendlyAmendment : Rule
        {
            public ConsiderationofFriendlyAmendment(Country countrySubmitting)
            {
                this.name = "Friendly Amendments";
                this.second = false;
                this.debatable = false;
                this.voteType = votes.no;
                this.description = "A Friendly Amendment is automatically put into a resolution. To be considered friendly, it needs to have the approval of all the sponsors of the resolution.";
                this.priority = 17;
                this.ruleNumber = 9.5;
            }
            public static string GetInfo()
            {
                return (new ConsiderationofFriendlyAmendment(new Country("fake"))).name;
            }
        }
        public class Country
        {
            
            string name;
            People person;
            DateTime dateTime;
            private string v;

            public Country(string v)
            {
                this.name = v;
                dateTime = DateTime.Now;
            }

            public string Name { get => name; set => name = value; }
            public People Person { get => person; set => person = value; }
            public DateTime DateTime { get => dateTime; set => dateTime = value; }
        }
        public class Rule
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
        public class Point: Rule
        {

            protected Country motioningCounty;
            public Point()
            {
                voteType = votes.no;
                debatable = false;
                second = false;
            }
        }
        public class PointOfOrder: Point
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
            public static string GetInfo()
            {
                return (new PointOfOrder(new Country("fake"))).name;
            }
        }
        public class PointOfInformation : Point
        {
            public PointOfInformation(Country aCountry)
            {
                name = "Point of Information";
                shortResponse = String.Format("On Information {0}", aCountry.Name);
                description = "This point should be used when a delegate is unsure of the correct proceedings, rules, or any other information the chair can provide.";
                ruleNumber = 8.2;
                priority = 2;
            }
            public static string GetInfo()
            {
                return (new PointOfInformation(new Country("fake"))).name;
            }
        }
        public class PointOfInquiry : Point
        {
            public PointOfInquiry(Country aCountry)
            {
                name = "Point of Inquiry";
                shortResponse = String.Format("On Inquiry {0}", aCountry.Name);
                description = "After a delegate has yielded time to Points of Inquiry or questions, delegate may be recognized to ask a Point of Inquiry to the speaker.";
                ruleNumber = 8.3;
                priority = 3;
            }
            public static string GetInfo()
            {
                return (new PointOfInquiry(new Country("fake"))).name;
            }
        }
        public class DiplomaticCourtesy : Point
        {
            public DiplomaticCourtesy(Country aCountry)
            {
                name = "Diplomatic Courtesy";
                shortResponse = String.Format("On Diplomatic Courtesy {0}", aCountry.Name);
                description = "Delegates must exercise diplomatic courtesy to all other delegates and secretariat members at all times.";
                ruleNumber = 7.1;
                priority = 4;
            }
            public static string GetInfo()
            {
                return (new DiplomaticCourtesy(new Country("fake"))).name;
            }
        }
        public class ProceduralMotion: Rule
        {
            protected Country motioningCounty;
            public ProceduralMotion()
            {
            }
        }
        public class Seat
        {

        }
        
    }
    
}
