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
            "mieć węża w kieszeni",
            "zjeść z kimś beczkę soli",
            "koń trojański",
            "ikarowe loty",
            "słomiany zapał",
            "powracać niczym bumerang",
            "ciosać komuś kołki na głowie",
            "pluć sobie w brodę",
            "perlisty śmiech",
            "w gorącej wodzie kąpany",
            "ranny ptaszek",
            "czarna owca",
            "rzucać komuś kłody pod nogi",
            "stajnia augiasza",
            "mieć ptasi móżdżek",
            "mieć głowę na karku",
            "mieć duszę na ramieniu",
            "szukać wiatru w polu"
        };

        private string choosen;
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

            this.word.Text = "";

            foreach (char letter in choosen)
            {
                if (letter == ' ')
                {
                    this.word.Text += ' ';
                }
                else
                {
                    this.word.Text += '-';
                }
            }
        }
    }
}
