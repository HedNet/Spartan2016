using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RiaAgentInstaller2
{
    public partial class LanguageSelector : Form
    {
        public static enum Languages {English,German,Spanish,French,Italian }
        public static Languages ChousenLanguage = Languages.English;

        public LanguageSelector()
        {
            InitializeComponent();
        }

        private void buttonEnglish_Click(object sender, EventArgs e)
        {
            string name = ((Button)sender).Name;
            switch (name.ToLower())
            {
                case "buttonitalian": ChousenLanguage = Languages.English; break;
                case "buttongerman": ChousenLanguage = Languages.English; break;
                case "buttonspanish": ChousenLanguage = Languages.English; break;
                case "buttonfrench": ChousenLanguage = Languages.English; break;
                default: ChousenLanguage = Languages.English; break;
            }
        }
    }
}
