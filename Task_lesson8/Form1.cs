using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_lesson8
{
    public partial class Form1 : Form, IStringContainerWiev
    {
        private IController _stringContainerController;
        private IStringContainerModelEventer _model;


        public Form1()
        {
            InitializeComponent();
            OutputListBox.Items.Clear();
        }

        private void DoActionButton_Click(object sender, EventArgs e)
        {
            _stringContainerController.AddString(InputTextBox.Text);
        }

        private void InformStringAddedEvent()
        {
            if (_model != null)
            {
                string newString = _model.GetLastString();
                if (newString != null)
                {
                    OutputListBox.Items.Add(newString);
                }
            }
        }

        #region IStringContainerWiev

        public IController StringContainerController 
        {
            set 
            { 
                _stringContainerController = value; 
            }
        }

        public IStringContainerModelEventer StringContainerModelEventer 
        {
            set
            {
                if (value != null)
                {
                    _model = value;
                    _model.StringAdded += InformStringAddedEvent;
                }
            }
        }

        #endregion

    }
}
