using System.Windows;
using System.Windows.Input;
using WPFMatLabPlotter;
using GenerativeAI.Models;
using System.IO;
using System.Text;
using MathWorks.MATLAB.NET.Arrays;
namespace MatLab_OptimizationAlgorithms
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Newton_Raphson.Algorithms algorithmsplot_controller = new Newton_Raphson.Algorithms();
        private bool _isExist = false;
        string apiKey = "AIzaSyAp-CQLbPnzkOUenlQEPQc-bxo3hfBONZk";
        string responsAI = "";
        GenerativeModel model;

        public MainWindow()
        {
            model = new GenerativeModel(apiKey);
            InitializeComponent();
        }
        private async Task<string> GetNewFormatAI(string text)
        {
            //or var model = new GeminiProModel(apiKey)
            string prompt = $"Уравнение: {{{text}}}\n что с этим уравнением нужно сделать:\n{{{File.ReadAllText("C:\\Users\\Omar\\source\\repos\\MatLab_OptimizationAlgorithms\\prompt.txt", Encoding.UTF8)}}}";
            string res = await model.GenerateContentAsync(prompt);
            return res;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (_isExist)
            {
               _isExist = false;
                MainPlot.DestroyGraph();
            }
            else
            {
                _isExist = true;
                Mouse.OverrideCursor = Cursors.Wait;

                //1. Call Matlab to draw plot.
               

                Mouse.OverrideCursor = null;
            }
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //responsAI = await GetNewFormatAI(functionInput.Text);
            //formatingResult.Content = responsAI;
            File.WriteAllText("C:\\Users\\Omar\\source\\repos\\MatLab_OptimizationAlgorithms\\outputAI.txt",responsAI, Encoding.UTF8);

        }
    }
}