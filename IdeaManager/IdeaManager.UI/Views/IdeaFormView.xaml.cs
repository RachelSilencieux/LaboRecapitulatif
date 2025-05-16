using IdeaManager.Data.Repositories;
using IdeaManager.Services.Services;
using IdeaManager.UI.ViewModels;
using IdeaManager.Core.Interfaces;
using System.Windows;

namespace IdeaManager.UI.Views
{
    public partial class IdeaFormView : Window
    {
        public IdeaFormView(IdeaFormViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
