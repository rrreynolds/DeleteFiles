﻿using System;
using System.IO;
using Westwind.Utilities.System;

namespace DeleteFiles
{
    public class DeleteFilesCommandLineParser : CommandLineParser
    {
        public string FullPath { get; set; }
        public bool Recursive { get; set; }
        public bool DisplayOnly { get; set; }
        public bool UseRecycleBin { get; set; }
        public bool RemoveEmptyFolders { get; set; }
        public int Days { get; set; }
        public int Seconds { get; set; }

        public string FilePath { get; set; }
        public string FileSpec { get; set; }


        public DeleteFilesCommandLineParser(string[] args = null, string cmdLine = null)
            : base(args, cmdLine)
        {
        }

        public override void Parse()
        {
            // first argument is path
            FullPath = Args[0];
            if (!string.IsNullOrEmpty(FullPath))
            {
                FilePath = Path.GetDirectoryName(FullPath);
                FilePath = Path.GetFullPath(FilePath);
                FileSpec = Path.GetFileName(FullPath);
            }

            DisplayOnly = ParseParameterSwitch("-l");
            Recursive = ParseParameterSwitch("-r");
            RemoveEmptyFolders = ParseParameterSwitch("-f");
            UseRecycleBin = ParseParameterSwitch("-y");
            Days = ParseIntParameterSwitch("-d", -1);
            Seconds = ParseIntParameterSwitch("-s", -1);
        }
    }
}