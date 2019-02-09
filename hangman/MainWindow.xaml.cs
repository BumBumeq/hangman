using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace hangman
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private string[] words =
        {
            "Mieć węża w kieszeni",
            "Zjeść z kimś beczkę soli",
            "Koń trojański",
            "Ikarowe loty",
            "Słomiany zapał",
            "Powracać niczym bumerang",
            "Ciosać komuś kołki na głowie",
            "Pluć sobie w brodę",
            "Perlisty śmiech",
            "W gorącej wodzie kąpany",
            "Ranny ptaszek",
            "Czarna owca",
            "Rzucać komuś kłody pod nogi",
            "Stajnia Augiasza",
            "Mieć ptasi móżdżek",
            "Mieć głowę na karku",
            "Mieć duszę na ramieniu",
            "Szukać wiatru w polu"
        };

        private string choosen;
        private string convertedChoosen;

        private int nextError = 0;
        private Rectangle[] errorRectangles = new Rectangle[6];
        private Random randomGenerator;

        public MainWindow()
        {
            randomGenerator = new Random();
            InitializeComponent();
        }

        private void Initialize_Game(object sender, RoutedEventArgs e)
        {
            int randomNumber = randomGenerator.Next(0, words.Length);
            choosen = words[randomNumber];

            foreach (char letter in choosen)
            {
                if (letter == ' ')
                {
                    convertedChoosen += ' ';
                }
                else
                {
                    convertedChoosen += '-';
                }
            }

            this.word.Text = convertedChoosen;

            errorRectangles[0] = this.error0;
            errorRectangles[1] = this.error1;
            errorRectangles[2] = this.error2;
            errorRectangles[3] = this.error3;
            errorRectangles[4] = this.error4;
            errorRectangles[5] = this.error5;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.word.Text = "";
            (sender as Button).IsEnabled = false;

            string tempChoosen = choosen.ToLower();
            string tempConvertedChoosen = convertedChoosen;

            convertedChoosen = "";

            for (int i = 0; i < tempChoosen.Length; ++i)
            {
                if (tempChoosen[i] == ((sender as Button)?.Content.ToString().ToLower())[0])
                {
                    convertedChoosen += choosen[i];
                }
                else
                {
                    convertedChoosen += tempConvertedChoosen[i];
                }
            }

            this.word.Text = convertedChoosen;

            if (convertedChoosen == tempConvertedChoosen && nextError < 6)
            {
                errorRectangles[nextError].Fill = new SolidColorBrush(System.Windows.Media.Colors.Red);
                nextError++;
            }
        }
    }
}
