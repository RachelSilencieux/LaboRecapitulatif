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
        private readonly IIdeaService _ideaService;

        public IdeaListViewModel(IIdeaService ideaService)
        {
            _ideaService = ideaService;
            LoadAsync();
        }

        public IdeaListViewModel() { }

        [ObservableProperty]
        private ObservableCollection<Idea> ideas = new ObservableCollection<Idea>();

        [ObservableProperty]
        private string title;


        [ObservableProperty]
        private Idea selectedIdea;

        private async Task LoadAsync()
        {
            var ideas = await _ideaService.GetAllIdeasAsync();

            if (!string.IsNullOrEmpty(title))
            {
                ideas = ideas.Where(i => i.Title.Contains(title, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            if (ideas != null)
            {
                Ideas.Clear();
                foreach (var idea in ideas)
                {
                    Ideas.Add(idea);
                }
            }

        }
    }
}
