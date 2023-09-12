using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace programming009.LibraryManagement
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
        }

        //DB first design
        /*
         *  UML diagram 
         * 
         *  Books      Authors   Branches
         *   Id           Id       Id
         *  Name         Name      Name
         *  Price       Surname   Address
         *  Genre       
         *  
         *      AuthorBooks
         *         Id
         *       AuthorId
         *       BookId
         */

        //Layered Architecture
        /*
         *  [  Presentation ] 
         *   [  Business  ] MVVM,  ViewModel
         *     [  Core  ] Repository, UnitOfWork
         *       [ DB ]  
         */
    }
}
