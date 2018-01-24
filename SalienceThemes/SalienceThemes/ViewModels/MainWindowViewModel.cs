﻿using Lexalytics;
using SalienceThemes.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SalienceThemes.ViewModels
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        Path _path;
        Salience Engine = null;
        Input _input;
        Themes _themes;

        public MainWindowViewModel()
        {
            _path = new Path { LicensePath = "C:/Program Files (x86)/Lexalytics/License.v5", DataPath = "C:/Program Files (x86)/Lexalytics/data" };
            _input = new Input { InputText = "This is an example of input text, which has been hard-coded." };
            _themes = new Themes { };
            try
            {
                Engine = new Salience(Path.LicensePath, Path.DataPath);
            }
            catch (SalienceException e)
            {
                // not sure how to handle this yet
            }
        }

        public Path Path
        {
            get { return _path; }
            set { _path = value; }
        }
        
        public string LicensePath
        {
            get { return Path.LicensePath; }
            set
            {
                if (Path.LicensePath != value)
                {
                    Path.LicensePath = value;
                    RaisePropertyChanged("LicensePath");
                }
            }
        }

        public string DataPath
        {
            get { return Path.DataPath; }
            set
            {
                if (Path.DataPath != value)
                {
                    Path.DataPath = value;
                    RaisePropertyChanged("DataPath");
                }
            }
        }

        public Input Input
        {
            get { return _input; }
            set { _input = value; }
        }

        public string InputText
        {
            get { return Input.InputText; }
            set
            {
                if (Input.InputText != value)
                {
                    Input.InputText = value;
                    RaisePropertyChanged("InputText");
                }
            }
        }

        public Themes Themes
        {
            get { return _themes; }
            set { _themes = value; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void AnalyseText()
        {
            int nRet = Engine.PrepareText(InputText);
            if (nRet == 0)
            {
                List<SalienceTheme> myThemes = Engine.GetDocumentThemes(String.Empty);
                foreach (SalienceTheme aTheme in myThemes)
                {

                }
             }
            else
            {
                // there was an error, in which case this needs to be handled somehow
            }
        }
    }
}