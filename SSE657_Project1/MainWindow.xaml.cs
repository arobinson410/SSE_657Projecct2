﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SSE657_Project1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Character c = new Character();
            c.changeClass("Warlock");
            c.changeStat(Character.AbilityScore.Charisma, 20);
            MainWindowVM mainWindowVM = new MainWindowVM(c);
            this.DataContext = mainWindowVM;
            InitializeComponent();

            
        }
    }
}
