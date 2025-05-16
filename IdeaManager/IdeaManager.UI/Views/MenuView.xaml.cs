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
using System.Windows.Shapes;
using IdeaManager.Core.Interfaces;
using IdeaManager.UI.ViewModels;

namespace IdeaManager.UI.Views
{
    /// <summary>
    /// Logique d'interaction pour MenuView.xaml
    /// </summary>
    public partial class MenuView : Window
    {
        public MenuView()
        {
            InitializeComponent();
        }

        private void IdeaList_Click(object sender, RoutedEventArgs e)
        {
            IdeaListView ideaListView = new IdeaListView();
            ideaListView.Show();
            this.Close();
        }

        private void IdeaForm_Click(object sender, RoutedEventArgs e)
        {
            IdeaFormView ideaFormView = new IdeaFormView();
            ideaFormView.Show();
            this.Close();
        }

    }
}
