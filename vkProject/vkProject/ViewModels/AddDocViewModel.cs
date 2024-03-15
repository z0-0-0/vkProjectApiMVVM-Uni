using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ReactiveUI;
using vkProj.Models;

namespace vkProject.ViewModels;

public class AddDocViewModel : ViewModelBase, IRoutableViewModel
{
    private string _fileContent;
    public string UrlPathSegment { get; } = Guid.NewGuid().ToString().Substring(0, 5);
    public IScreen HostScreen { get; }

    public AddDocViewModel(
        IScreen hostScreen,
        VkFile doc,
        string content
    )
    {
        HostScreen = hostScreen;
        Files = new ObservableCollection<VkFile>(new List<VkFile>() { doc });
        FileContent = content;
    }


    public string FileContent
    {
        get => _fileContent;
        private set => this.RaiseAndSetIfChanged(ref _fileContent, value);
    }

    public ObservableCollection<VkFile> Files { get; set; }
}