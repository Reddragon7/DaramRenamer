﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GroupRenamer
{
	/// <summary>
	/// AboutWindow.xaml에 대한 상호 작용 논리
	/// </summary>
	public partial class AboutWindow : Window
	{
		public AboutWindow ()
		{
			InitializeComponent ();
			Version version = Assembly.GetExecutingAssembly ().GetName ().Version;
			versionString.Text += string.Format ( "{0}.{1}{2}{3}", version.Major, version.Minor, version.Build, version.Revision );
		}

		private void buttonApply_Click ( object sender, RoutedEventArgs e )
		{
			DialogResult = true;
		}
	}
}
