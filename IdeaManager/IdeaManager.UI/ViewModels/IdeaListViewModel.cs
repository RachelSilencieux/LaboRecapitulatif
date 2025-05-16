using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using IdeaManager.Core.Entities;
using IdeaManager.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IdeaManager.UI.ViewModels
{
    public partial class IdeaListViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<Idea> ideas = new();

        private readonly IIdeaService _ideaService;

        public IdeaListViewModel(IIdeaService ideaService)
        {
            _ideaService = ideaService;
            LoadIdeasAsync();
        }

        public async Task LoadIdeasAsync()
        {
            var fetchedIdeas = await _ideaService.GetAllIdeasAsync();
            Ideas.Clear();
            foreach (var idea in fetchedIdeas)
                Ideas.Add(idea);
        }

    }
}
