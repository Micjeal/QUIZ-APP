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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace QUIZ_APP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private List<questionbankDb> questions;
        private int currentquestionindex;
        private int score = 0;

        private DispatcherTimer timer;
        private int timeleft;



        public MainPage()
        {
            this.InitializeComponent();
            loadthequestion();
            setthequestion();
        }

        private void loadthequestion()
        {
            questions = new List<questionbankDb>
            {
                new questionbankDb
                {
                    questions = "what is uganda city"
                      , option1 = "nairobi"
                      , option2 = "kenya"
                      , option3 = "kampala"
                      , option4 = "mbarara",
                       correctAns = 3
                },
                new questionbankDb
                {
                    questions = "what is kenya city"
                      , option1 = "nairobi"
                      , option2 = "kenya"
                      , option3 = "kampala"
                      , option4 = "mbarara",
                       correctAns = 4
                },
                new questionbankDb
                {
                    questions = "what is dubai city"
                      , option1 = "nairobi"
                      , option2 = "kenya"
                      , option3 = "kampala"
                      , option4 = "mbarara",
                       correctAns = 2
                },
                 new questionbankDb
                {
                    questions = "what is mbarara city"
                      , option1 = "nairobi"
                      , option2 = "kenya"
                      , option3 = "kampala"
                      , option4 = "mbarara",
                       correctAns = 1
                },



            };
        }

        private void setthequestion()
        {
            if (currentquestionindex < questions.Count)
            {

                var current = questions[currentquestionindex];
                Qtntxt.Text = current.questions ;
                option1.Content = current.option1;
                option2.Content = current.option2;
                option3.Content = current.option3;


                timeleft = 9;
                timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromSeconds(5);

                timer.Tick += Timer_Tick;
                timer.Start();

            }
            else
            {
                Qtntxt.Text = "end of  quiz";
                option1.IsEnabled = false;
                option2.IsEnabled = false;
                option3.IsEnabled = false;
                option4.IsEnabled = false;
                txtscore.Text = score.ToString() + "/4";

            }
        }

        private void Timer_Tick(object sender, object e)
        {
            timeleft--;
            timerbx.Text = timeleft.ToString();
            if (timeleft <= 0)
            {
                option1.IsEnabled = false;
                option2.IsEnabled = false;
                option3.IsEnabled = false;
                option4.IsEnabled = false;

                timer.Stop();
                currentquestionindex = 0;
                setthequestion();

            }
        }

        private void submitbtn_Click(object sender, RoutedEventArgs e)
        {
            if (option1.IsChecked == false || option2.IsChecked == false 
                || option3.IsChecked == false || option4.IsChecked == false)
            {

                return;
            }
            else
            {
                var current = questions[currentquestionindex];
                var correntans = current.correctAns;

                if(option1.IsChecked == true&&correntans == 3 ||
                    option2.IsChecked == true&&correntans == 4 || 
                    option3.IsChecked == true&correntans == 1||
                    option4.IsChecked == true&&correntans ==2)
                {
                    score++;
                    txtresult.Text = "correct";


                }
                else
                {
                    txtresult.Text = "wrong ans";
                }
                timer.Stop();
                currentquestionindex++;
                setthequestion();
             }
         }

        }
    }

