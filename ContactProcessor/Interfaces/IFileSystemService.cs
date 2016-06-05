using System;
using ContactProcessor.Models;

namespace ContactProcessor.Interfaces
{
    public interface IFileSystemService : IDisposable
    {

        DisplayInputViewModel ReadFile(string file);
        DisplayInputViewModel WriteToFile(ContactViewModel model);
    }
}