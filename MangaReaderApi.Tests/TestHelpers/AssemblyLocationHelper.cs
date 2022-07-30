using System;
namespace MangaReaderApi.Tests.TestHelpers
{
    public class AssemblyLocationHelper
    {
        public virtual string AssemblyLocation
        {
            get => AppDomain.CurrentDomain.BaseDirectory + @"../../../";
        }

        public string FindFileByRelativePath(string relativePathFile) =>
            AssemblyLocation + relativePathFile;
    }
}

