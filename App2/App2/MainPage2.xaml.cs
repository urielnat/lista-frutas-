using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App2
{
    public partial class MainPage2 : ContentPage
    {
      


		public MainPage2()
        {
            InitializeComponent();
            var  list = new ListView()
            {
                RowHeight = 100
            };
            list.ItemsSource = new TodoItem[] {
                new TodoItem { Name = "Comprar pera",Imagen="https://i.ytimg.com/vi/3fHynPXZAT8/maxresdefault.jpg" },
                new TodoItem { Name = "Comprar naranjas", Done=true,Imagen="http://pngimg.com/uploads/orange/orange_PNG800.png"} ,
                new TodoItem { Name = "Comprar mangos",Imagen ="http://www.danper.com/media_danper/uploads/producto/frutas/mango-peruano-sabor-tropical.jpg" },
                new TodoItem { Name = "Comprar manzana", Done=true,Imagen="http://static.commentcamarche.net/sante-medecine.commentcamarche.net/pictures/9dA3Z9lr-photo-pomme-2.png" },
                new TodoItem { Name = "Comprar platano", Done=true,Imagen="https://www.importancia.org/wp-content/uploads/platano.jpg" } //para ios solo png si es recurso
                //si se usa un recurso es necesario ponerlo en las carpetas respectivas de cada dispositivo, si se usa una url no hay problema
                };



            list.ItemTemplate = new DataTemplate(typeof(ImageCell));

            //asignar al template los valores mediante binding
            list.ItemTemplate.SetBinding(TextCell.TextProperty,"Name");
            list.ItemTemplate.SetBinding(TextCell.DetailProperty,"Done");
            list.ItemTemplate.SetBinding(ImageCell.ImageSourceProperty,"Imagen");
        


         

            list.ItemSelected += async (sender, e) =>
            {

				/*
				var todoItem = (TodoItem)e.SelectedItem;
				   await DisplayAlert("Tapped!", todoItem.Name + " was tapped.", "OK");

				await DisplayAlert("Tapped!", (e.SelectedItem as TodoItem).Done + " was tapped.", "OK");*/

				var todoItem = (TodoItem)e.SelectedItem;
            var todoPage = new TodoItemPage(todoItem); // so the new page shows correct data
#if __IOS__
                await this.Navigation.PushAsync(todoPage);//no modal (con backbutton)
#endif

#if __ANDROID__

                await this.Navigation.PushModalAsync(todoPage);
#endif



            };

            showSave.Clicked += (sender, e) =>
                DisplayAlert("salio",Application.Current.Properties["namex"] as string,"ok");


				




         Content = new StackLayout{
           VerticalOptions = LayoutOptions.FillAndExpand,
                Children = { list,showSave // , para agregar otro elemento  
                }
};
		}


    }
}
