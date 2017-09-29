using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App2
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TodoItemPage : ContentPage
	{
        public TodoItem item { set; get; }
        public TodoItemPage(TodoItem todoItem)
        {
            item = todoItem;

            InitializeComponent();
            //texto.Text = todoItem.Name; es otra manera de ponerlo usado el x:Name



            indicador.SetBinding(ActivityIndicator.IsRunningProperty, "IsLoading");
            indicador.BindingContext = img;


			#if __IOS__


			Padding = new Thickness(0, 30, 0, 0);
            Title = "Mostrar";

#endif
			/*
			var label = new Label();
            label.SetBinding(Label.TextProperty, "Company");
			label.BindingContext = new { Name = "John Doe", Company = "Xamarin" };
			Debug.WriteLine(label.Text); //prints "John Doe"*/


		}
        protected override void OnAppearing()
        {
            base.OnAppearing();


			if (string.IsNullOrEmpty(item.Name))
			{
				
				item.Name = Application.Current.Properties["namex"].ToString();
                item.Imagen = Application.Current.Properties["imagex"].ToString();
                BindingContext = item;
            }else{
                BindingContext = item;
            }
			


            save.Clicked += Handle_Clicked;

           
        }




        private async void Handle_Clicked(object sender, System.EventArgs e)
        {
            
				

           
				Application.Current.Properties["namex"] = item.Name;
				Application.Current.Properties["donex"] = item.Done;
				Application.Current.Properties["imagex"] = item.Imagen;
               
			await  Application.Current.SavePropertiesAsync();


			await DisplayAlert("Guardar", "Guardado con exito", "ok");
            
        }
    }
}