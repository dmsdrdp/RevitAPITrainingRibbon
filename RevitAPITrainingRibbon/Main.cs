using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace RevitAPITrainingRibbon
{
    [Transaction(TransactionMode.Manual)]
    public class Main : IExternalApplication
    {
        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }

        public Result OnStartup(UIControlledApplication application)
        {
            string tabName = "Revit API Training";
            application.CreateRibbonTab(tabName);
            string utilsFolderPath = @"C:\Program Files\RevitAPITraining";

            var panel = application.CreateRibbonPanel(tabName, "Стены"); //панель "стены"
            var panel2 = application.CreateRibbonPanel(tabName, "Объемы"); // панель "объемы"

            var button = new PushButtonData("Система", "Изменение типов стен", Path.Combine(utilsFolderPath, "RevitApiTrainingUI.dll"), "RevitApiTrainingUI.Main"); //кнопки
            var button2 = new PushButtonData("Система", "Подсчтет труб, стен, дверей", Path.Combine(utilsFolderPath, "Buttons.dll"), "Buttons.Main");

            Uri uriImage = new Uri(@"C:\Program Files\RevitAPITraining\Images\RevitAPITrainingUI_32.png", UriKind.Absolute);     // иконки
            Uri uriImage2 = new Uri(@"C:\Program Files\RevitAPITraining\Images\RevitAPITrainingUI_32_2.png", UriKind.Absolute);
            BitmapImage largeImmage = new BitmapImage(uriImage);
            BitmapImage largeImmage2 = new BitmapImage(uriImage2);
            button.LargeImage = largeImmage;
            button2.LargeImage = largeImmage2;

            panel.AddItem(button);
            panel2.AddItem(button2);

            return Result.Succeeded;
        }   
    }
}
