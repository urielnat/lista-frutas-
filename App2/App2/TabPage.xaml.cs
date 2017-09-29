using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace App2
{
    public partial class TabPage : TabbedPage
    {

        public TodoItem item =new TodoItem(); 

        public TabPage()
        {
	
            InitializeComponent();


           

		    Children.Add(new MainPage2());
            Children.Add(new TodoItemPage(item));

        }

      

           
        }

    }

