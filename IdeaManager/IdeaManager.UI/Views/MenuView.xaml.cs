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
using IdeaManager.Data.Db;
using IdeaManager.Data.Repositories;
using IdeaManager.Services.Services;
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
            var dbContext = new IdeaDbContext();

            var ideaRepository = new IdeaRepository(dbContext);
            var userRepository = new UserRepository(dbContext);
            var voteRepository = new VoteRepository(dbContext);
            var projectRepository = new ProjectRepository(dbContext);

            var unitOfWork = new UnitOfWork(dbContext, ideaRepository, userRepository, voteRepository, projectRepository);

            IIdeaService ideaService = new IdeaService(unitOfWork);

            var viewModel = new IdeaListViewModel(ideaService);

            var ideaListView = new IdeaListView(viewModel);
            ideaListView.Show();
            this.Close();
        }



        private void IdeaForm_Click(object sender, RoutedEventArgs e)
        {
            var dbContext = new IdeaDbContext();

            var ideaRepository = new IdeaRepository(dbContext);
            var userRepository = new UserRepository(dbContext);
            var voteRepository = new VoteRepository(dbContext);
            var projectRepository = new ProjectRepository(dbContext);

            var unitOfWork = new UnitOfWork(dbContext, ideaRepository, userRepository, voteRepository, projectRepository);

            IIdeaService ideaService = new IdeaService(unitOfWork);

            var viewModel = new IdeaFormViewModel(ideaService);

            var ideaFormView = new IdeaFormView(viewModel);
            ideaFormView.Show();
            this.Close();
        }

    }
}
