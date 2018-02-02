using Lexalytics;
using SalienceThemes.Models;
using SalienceThemes.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Input;

namespace SalienceThemes.ViewModels
{
    class TextAnalysisViewModel : INotifyPropertyChanged
    {
        private PathInput _pathInput;
        private Salience Engine = null;
        private Input _input;
        private Themes _themes;
        private NamedEntities _namedEntities;
        private Summary _summary;
        private Import _import;
        private int _theValue;
        private string _textToAnalyse;

        public TextAnalysisViewModel()
        {
            _pathInput = new PathInput { LicensePath = Strings.Label_LicensePath, DataPath = Strings.Label_DataPath };
            _input = new Input { InputText = Strings.Label_InputText_SampleString };
            _themes = new Themes();
            _summary = new Summary();
            _namedEntities = new NamedEntities();
            _import = new Import();
            _textToAnalyse = InputText;
            try
            {
                Engine = new Salience(PathInput.LicensePath, PathInput.DataPath);
            }
            catch (SalienceException e)
            {
                //not sure how to handle this yet
            }
        }

        public Themes Themes
        {
            get { return _themes; }
            set { _themes = value; }
        }

        public NamedEntities NamedEntities
        {
            get { return _namedEntities; }
            set { _namedEntities = value; }
        }

        public Summary Summary
        {
            get { return _summary; }
            set { _summary = value; }
        }

        #region Getters and Setters
        public int TheValue
        {
            get { return _theValue; }
            set
            {
                if (_theValue != value)
                {
                    _theValue = value;
                    RaisePropertyChanged("ImportFileName");
                }
            }
        }

        public string TextToAnalyse
        {
            get { return _textToAnalyse; }
            set
            {
                if (_textToAnalyse != value)
                {
                    _textToAnalyse = value;
                    RaisePropertyChanged("ImportFileName");
                }
            }
        }
        #endregion

        public void Delete_Theme(Theme theme)
        {
            _themes.Remove(theme);
        }

        public bool HasResults => Themes.Count > 0;

        #region ImportMembers
        public Import Import
        {
            get { return _import; }
            set { _import = value; }
        }

        public string ImportText
        {
            get { return Import.ImportText; }
            set
            {
                if (Import.ImportText != value)
                {
                    Import.ImportText = value;
                    RaisePropertyChanged("ImportText");
                }
            }
        }

        public string ImportFileName
        {
            get { return Import.ImportFileName; }
            set
            {
                if (Import.ImportFileName != value)
                {
                    Import.ImportFileName = value;
                    RaisePropertyChanged("ImportFileName");
                }
            }
        }
        #endregion

        #region PathMembers
        public PathInput PathInput
        {
            get { return _pathInput; }
            set { _pathInput = value; }
        }

        public string LicensePath
        {
            get { return PathInput.LicensePath; }
            set
            {
                if (PathInput.LicensePath != value)
                {
                    PathInput.LicensePath = value;
                    RaisePropertyChanged("LicensePath");
                }
            }
        }

        public string DataPath
        {
            get { return PathInput.DataPath; }
            set
            {
                if (PathInput.DataPath != value)
                {
                    PathInput.DataPath = value;
                    RaisePropertyChanged("DataPath");
                }
            }
        }
        #endregion

        #region InputMembers
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
        #endregion

        #region PropertyChangedHandler
        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region ClearButton
        public void ClearExecute()
        {
            InputText = String.Empty;
            Themes.Clear();
        }

        public bool CanClearExecute()
        {
            return true;
        }

        public ICommand Clear
        {
            get { return new RelayCommand(ClearExecute, CanClearExecute); }
        }
        #endregion

        #region ProcessButton
        public void ProcessExecute()
        {
            Themes.Clear();
            int nRet = Engine.PrepareText(TextToAnalyse);
            if (nRet == 0)
            {
                // Get themes
                List<SalienceTheme> myThemes = Engine.GetDocumentThemes(String.Empty);
                foreach (SalienceTheme aTheme in myThemes)
                {
                    Themes.Add(new Theme(aTheme.sNormalizedTheme, aTheme.fScore, aTheme.nThemeType, aTheme.fSentiment, aTheme.nEvidence));
                }

                // Get named entities
                List<SalienceEntity> myEntities = Engine.GetNamedEntities(String.Empty);
                foreach (SalienceEntity anEntity in myEntities)
                {
                    NamedEntities.Add(new NamedEntity(anEntity.sNormalizedForm, anEntity.sType, anEntity.fSentimentScore, anEntity.nEvidence, anEntity.nCount));
                }

                // Get summary
                SalienceSummary mySummary = Engine.GetSummary(3, String.Empty);
                Summary.SummaryText = mySummary.sSummary;
            }
            else
            {
                // there was an error, in which case this needs to be handled somehow
            }
        }

        public bool CanProcessExecute()
        {
            return true;
        }

        public ICommand Process
        {
            get { return new RelayCommand(ProcessExecute, CanProcessExecute); }
        }
        #endregion

        #region ImportButton
        public void ImportExecute()
        {
            // Create dialog only filtering text files
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog
            {
                DefaultExt = ".txt",
                Filter = "Text Document (*.txt)|*.txt"
            };

            // Display dialog
            Nullable<bool> result = dlg.ShowDialog();

            // Get selected file name and extract into a string
            if (result == true)
            {
                ImportFileName = dlg.FileName;
                ImportText = File.ReadAllText(ImportFileName);
                TextToAnalyse = ImportText;
            }
         }

        public bool CanImportExecute()
        {
            return true;
        }

        public ICommand ImportFile
        {
            get { return new RelayCommand(ImportExecute, CanImportExecute); }
        }
        #endregion
    }
}
