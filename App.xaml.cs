using System.Windows;
using IndumentariaIntimaWPF.Data;
using System.Data.Entity;
using System;

namespace IndumentariaIntimaWPF
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            Database.SetInitializer<ApplicationDbContext>(null);
            using (var context = new ApplicationDbContext())
            {
                context.Database.Initialize(force: false); // Cambiar force a false
            }
            base.OnStartup(e);
        }
    }
}




//public partial class App : Application
//{
//    protected override void OnStartup(StartupEventArgs e)
//    {
//        Database.SetInitializer<ApplicationDbContext>(null);
//        using (var context = new ApplicationDbContext())
//        {
//            context.Database.Initialize(force: false); // Cambiar force a false
//        }
//        base.OnStartup(e);
//    }
//}
