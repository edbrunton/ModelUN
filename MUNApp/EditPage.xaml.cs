﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using MUNApp;
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MUNApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class EditPage : Page
    {
        public EditPage()
        {
           
            this.InitializeComponent();
        //    ItemCollection temp = mainGrid.IsItemsHost;
            List<CompleteCommittee.People> members = mySharedData.MyCommittee.PeopleList;
            for(int i =0; i< members.Count; i ++)
            {
               
            }
        }
    }
}